﻿using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class Character : MonoBehaviourPun
{
	[SerializeField] protected CharactersData m_characterData;
	[SerializeField] protected Transform m_Camera;
	[SerializeField] protected Camera m_CameraComp;

	protected GameControls m_controls;
	protected Rigidbody m_rbComp;
	protected Player m_associatePlayerInfo;
	protected float m_xCameraRotation;
	protected PhotonView m_photonView;

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
		m_rbComp = GetComponent<Rigidbody>();
		m_photonView = GetComponent<PhotonView>();
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
		m_controls = new GameControls();
		EnableControls();
	}

	public virtual void EnableControls()
	{
		m_controls.Enable();
	}

	public virtual void DisableControls()
	{
		m_controls.Disable();
	}

	public virtual void Move()
	{
		Vector2 inputs = m_controls.General.Move.ReadValue<Vector2>();
		Vector3 movement = new Vector3(inputs.x, 0f, inputs.y);
		movement = (movement.z * transform.forward * m_characterData.MoveSpeed) + (movement.x * transform.right *m_characterData.MoveSpeed) ;
		movement.y = m_rbComp.velocity.y;
		m_rbComp.velocity = movement;
	}

	public virtual void CameraControl()
	{
		float mouseX = m_controls.General.MouseDelta.ReadValue<Vector2>().x * m_characterData.CameraSensitivity ;
		float mouseY = m_controls.General.MouseDelta.ReadValue<Vector2>().y * m_characterData.CameraSensitivity ;
		transform.Rotate(Vector3.up * mouseX);

		m_xCameraRotation -= mouseY;
		m_xCameraRotation = Mathf.Clamp(m_xCameraRotation, -90f, 90f);

		m_Camera.localRotation = Quaternion.Euler(m_xCameraRotation, m_Camera.localRotation.y, m_Camera.localRotation.z);
	}

	public virtual void Interact()
	{
		RaycastHit hit;

		if(Physics.Raycast(m_Camera.position,m_Camera.forward,out hit, m_characterData.range))
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
			m_associatePlayerInfo = PhotonNetwork.LocalPlayer ;
			Debug.Log(m_associatePlayerInfo.NickName);
		}
		else
		{
			m_CameraComp.gameObject.SetActive(false);
			this.enabled = false;
		}
	}

	public CharactersData GetDatas()
	{
		return m_characterData;
	}
}
