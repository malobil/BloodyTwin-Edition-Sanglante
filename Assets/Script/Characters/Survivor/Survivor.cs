using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Survivor : Character
{
    [SerializeField] private GameObject m_lightTorch = null;

    private bool canUseLight = true;
    private float currentLightTorchBatteryTime;

    public override void OnInit()
    {
        base.OnInit();
        currentLightTorchBatteryTime = Cdatas.lightTorchBatteryTime ;
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        DecreaseLightTorchBattery();
        
        if(controls.Survivor.ChargeUpLightTorch.ReadValue<float>() > 0)
        {
            ChargeUpLightTorch();
        }
    }

    public override void SetupControls()
    {
        base.SetupControls();
        controls.Survivor.ToggleLightTorch.performed += ctx => HandleLightTorch();
        controls.Survivor.Interact.performed += ctx => Interact();
    }

    void DecreaseLightTorchBattery()
    {
        if (m_lightTorch.activeSelf && currentLightTorchBatteryTime > 0)
        {
            currentLightTorchBatteryTime -= Time.deltaTime;
        }
        else if (m_lightTorch.activeSelf && currentLightTorchBatteryTime <= 0)
        {
            canUseLight = false;
            photonView.RPC("RPC_TurnOffLight", RpcTarget.All);
        }
    }

    void ChargeUpLightTorch()
    {
        if(currentLightTorchBatteryTime < Cdatas.lightTorchBatteryTime)
        {
            currentLightTorchBatteryTime += Time.deltaTime;
        }
    }

    void HandleLightTorch()
    {
        if(canUseLight)
        {
            if(m_lightTorch.activeSelf)
            {
                photonView.RPC("RPC_TurnOnLight", RpcTarget.All);
            }
            else
            {
                photonView.RPC("RPC_TurnOffLight", RpcTarget.All);
            }
        }
        else
        {
            //Le moment ou le joueur n'a plus de batterie
        }
    }

    [PunRPC]
    void RPC_TurnOnLight()
    {
        GameObjectUtility.ShowGameObject(m_lightTorch);
    }

    [PunRPC]
    void RPC_TurnOffLight()
    {
        GameObjectUtility.HideGameObject(m_lightTorch);
    }
}
