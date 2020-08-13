﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Ghost : Character
{
    public override void SetupControls()
    {
        base.SetupControls();
        controls.Ghost.Possess.performed += ctx => Possess();
    }

    public override void Move()
    {
        Vector2 inputs = controls.General.Move.ReadValue<Vector2>();
        Vector3 movement = new Vector3(inputs.x, Rb.velocity.y, inputs.y);
        movement = (movement.z * transform.forward * Cdatas.MoveSpeed) + (movement.x * transform.right * Cdatas.MoveSpeed);
        movement.y = controls.Ghost.GoUp.ReadValue<float>() - controls.Ghost.GoDown.ReadValue<float>();
        movement.y *= Cdatas.MoveSpeed;
        Rb.velocity = movement;
    }

    private void Possess()
    {
        Furnitures[] allFurnitures = FindObjectsOfType<Furnitures>();
        List<Transform> furnituresTransform = new List<Transform>() ;

        for(int i = 0; i < allFurnitures.Length; i++)
        {
            furnituresTransform.Add(allFurnitures[i].transform);
        }

        Transform nearestFurnitures = TransformUtility.GetNeareastObject(furnituresTransform, transform, Cdatas.range);

        if (nearestFurnitures != null)
        {
            transform.position = nearestFurnitures.position;
            GameObjectUtility.HideGameObject(gameObject);
            nearestFurnitures.GetComponent<Furnitures>().Possess(this, m_Camera);
            photonView.RPC("RPC_HideMe", RpcTarget.All);
            DisableControls();
        }
    }

    [PunRPC]
    void RPC_ShowMe()
    {
        GameObjectUtility.ShowGameObject(gameObject);
    }

    [PunRPC]
    void RPC_HideMe()
    {
        GameObjectUtility.HideGameObject(gameObject);
    }

    public void UnPossess(Furnitures unpossedObj)
    {
        transform.position = unpossedObj.transform.position ;
        transform.rotation = unpossedObj.transform.rotation;
        m_Camera.position = transform.position;
        m_Camera.SetParent(transform);
        GameObjectUtility.ShowGameObject(gameObject);
        photonView.RPC("RPC_ShowMe", RpcTarget.All);
        EnableControls();
    }
}