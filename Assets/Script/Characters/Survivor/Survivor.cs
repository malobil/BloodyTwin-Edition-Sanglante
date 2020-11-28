using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Survivor : Character
{
    [SerializeField] private GameObject m_lightTorch = null;

    private bool m_canUseTorchLight = true;
    private float m_currentTorchLightBattery = 0f;

    public override void OnInit()
    {
        base.OnInit();
        UIManager.Instance.ShowUI(UIType.Survivor);
        m_currentTorchLightBattery = m_characterData.Survivor.LightTorchBatteryTime;
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        DecreaseTorchBattery();
    }

    public override void SetupControls()
    {
        base.SetupControls();
        m_controls.Survivor.ToggleLightTorch.performed += ctx => ToggleLightTorch();
        m_controls.Survivor.Interact.performed += ctx => Interact();
    }

    void ToggleLightTorch()
    {
        m_photonView.RPC("RPC_TurnOnLight", RpcTarget.All);
    }

    void DecreaseTorchBattery()
    {
        if(m_lightTorch.activeSelf)
        {
            m_currentTorchLightBattery -= Time.deltaTime * 2f;
            UIManager.Instance.UpdateUIFillAmount(UIType.Survivor, m_currentTorchLightBattery/m_characterData.Survivor.LightTorchBatteryTime);
        }
    }

    [PunRPC]
    void RPC_TurnOnLight()
    {
        if (m_canUseTorchLight)
        {
            if (m_lightTorch.activeSelf)
            {
                TurnOffLight();
            }
            else
            {
                TurnOnLight();
            }
        }
        else
        {
            //Le moment ou le joueur n'a plus de batterie
        }
    }

    void TurnOnLight()
    {
        GameObjectUtility.ShowGameObject(m_lightTorch);
    }

    void TurnOffLight()
    {
        GameObjectUtility.HideGameObject(m_lightTorch);
    }
}
