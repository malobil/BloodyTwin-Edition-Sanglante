﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public abstract class Furnitures : MonoBehaviourPun
{
    protected GameControls controls;
    protected Rigidbody Rb { get { return GetComponent<Rigidbody>(); } }
    protected float xCameraRotation;
    protected Transform m_Camera;
    protected Ghost associateGhost;

    protected bool canMove = true;

    // Start is called before the first frame update
    void Start()
    {
        OnInit();
    }

    // Update is called once per frame
    void Update()
    {
        OnUpdate();
    }

    public virtual void OnInit()
    {
        SetupControls();
        this.enabled = false;
    }

    public virtual void OnUpdate()
    {
        Move();
        CameraControl();
    }

    public virtual void SetupControls()
    {
        controls = new GameControls();
        controls.Ghost.Possess.performed += ctx => UnPossess();
        controls.Ghost.Eject.performed += ctx => Eject();
    }

    public virtual void Move()
    {
        Vector2 inputs = controls.General.Move.ReadValue<Vector2>();
        Vector3 movement = new Vector3(inputs.x, Rb.velocity.y, inputs.y);
        movement = (movement.z * transform.forward * associateGhost.GetDatas().MoveSpeed) + (movement.x * transform.right * associateGhost.GetDatas().MoveSpeed);
        movement.y = controls.Ghost.GoUp.ReadValue<float>() - controls.Ghost.GoDown.ReadValue<float>();
        movement.y *= 5f;
        Rb.velocity = movement;
    }

    public virtual void CameraControl()
    {
        float mouseX = controls.General.MouseDelta.ReadValue<Vector2>().x * associateGhost.GetDatas().CameraSensitivity * Time.deltaTime;
        float mouseY = controls.General.MouseDelta.ReadValue<Vector2>().y * associateGhost.GetDatas().CameraSensitivity * Time.deltaTime;
        transform.Rotate(Vector3.up * mouseX);

        xCameraRotation -= mouseY;
        xCameraRotation = Mathf.Clamp(xCameraRotation, -90f, 90f);

        m_Camera.localRotation = Quaternion.Euler(xCameraRotation, m_Camera.localRotation.y, m_Camera.localRotation.z);
    }

    public virtual void Possess(Ghost ghost,Transform newCamera)
    {
        photonView.RequestOwnership();
        transform.rotation = ghost.transform.rotation;
        canMove = true;
        associateGhost = ghost ;
        m_Camera = newCamera;
        m_Camera.position = transform.position;
        m_Camera.SetParent(transform);
        this.enabled = true;
        controls.Enable();
        photonView.RPC("RPC_Possess", RpcTarget.All);
    }

    public virtual void Eject()
    {
        canMove = false;
        Rb.AddForce(m_Camera.forward * associateGhost.GetDatas().ejectionForce,ForceMode.Impulse);
        Debug.Log("Eject");
        UnPossess();
    }

    [PunRPC]
    public virtual void RPC_Possess()
    {
        Rb.useGravity = false;
        Rb.constraints = RigidbodyConstraints.FreezeRotation;
    }

    [PunRPC]
    public virtual void RPC_UnPossess()
    {
        Rb.useGravity = true;
        Rb.constraints = RigidbodyConstraints.None;
    }

    public virtual void UnPossess()
    {
        associateGhost.UnPossess(this);
        photonView.RPC("RPC_UnPossess", RpcTarget.All);
        controls.Disable();
        this.enabled = false;
    }
}
