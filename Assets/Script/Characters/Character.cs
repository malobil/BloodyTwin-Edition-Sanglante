using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class Character : MonoBehaviourPun
{
    [SerializeField] protected CharactersData Cdatas;
    [SerializeField] protected Transform m_Camera;
    [SerializeField] protected Camera m_CameraComp;

    protected GameControls controls;
    protected Rigidbody Rb { get { return GetComponent<Rigidbody>(); }}
    protected Player associatePlayerInfo;
    protected float xCameraRotation;

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
        SetupPlayerInfos();
    }

    public virtual void OnUpdate()
    {
        Move();
        CameraControl();
    }

    public virtual void SetupControls()
    {
        controls = new GameControls();
        EnableControls();
    }

    public virtual void EnableControls()
    {
        controls.Enable();
    }

    public virtual void DisableControls()
    {
        controls.Disable();
    }

    public virtual void Move()
    {
        Vector2 inputs = controls.General.Move.ReadValue<Vector2>();
        Vector3 movement = new Vector3(inputs.x, Rb.velocity.y, inputs.y);
        movement = (movement.z * transform.forward * Cdatas.MoveSpeed) + (movement.x * transform.right *Cdatas.MoveSpeed)  ;
        Rb.velocity = movement;
    }

    public virtual void CameraControl()
    {
        float mouseX = controls.General.MouseDelta.ReadValue<Vector2>().x * Cdatas.CameraSensitivity * Time.deltaTime;
        float mouseY = controls.General.MouseDelta.ReadValue<Vector2>().y * Cdatas.CameraSensitivity * Time.deltaTime;
        transform.Rotate(Vector3.up * mouseX);

        xCameraRotation -= mouseY;
        xCameraRotation = Mathf.Clamp(xCameraRotation, -90f, 90f);

        m_Camera.localRotation = Quaternion.Euler(xCameraRotation, m_Camera.localRotation.y, m_Camera.localRotation.z);
    }

    public virtual void Interact()
    {
        RaycastHit hit;

        if(Physics.Raycast(m_Camera.position,m_Camera.forward,out hit, Cdatas.range))
        {
            InteractableObject interactableHit = hit.transform.GetComponentInParent<InteractableObject>();

            if (interactableHit != null)
            {
                interactableHit.OnInteract();
            }
        }
    }

    public virtual void SetupPlayerInfos()
    {
        if(photonView.IsMine)
        {
            associatePlayerInfo = PhotonNetwork.LocalPlayer ;
            Debug.Log(associatePlayerInfo.NickName);
        }
        else
        {
            m_CameraComp.enabled = false;
            this.enabled = false;
        }
    }

    public CharactersData GetDatas()
    {
        return Cdatas;
    }
}
