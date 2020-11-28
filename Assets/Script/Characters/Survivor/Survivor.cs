using Photon.Pun;
using UnityEngine;

public class Survivor : Character
{
    [SerializeField] private GameObject m_lightTorch = null;

    private bool m_canUseTorchLight = true;
    private bool m_isChargingTorchLight = false;

    private float m_currentTorchLightBattery = 0f;

    public override void OnInit()
    {
        base.OnInit();

        if (!photonView.IsMine)
        {
            return;
        }

        UIManager.Instance.ShowUI(UIType.Survivor);
        m_currentTorchLightBattery = m_characterData.Survivor.LightTorchBatteryTime;
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        DecreaseTorchBattery();
        ChargeUpTorchBattery();
    }

    public override void SetupControls()
    {
        base.SetupControls();
        m_controls.Survivor.ToggleLightTorch.performed += ctx => ToggleLight();
        m_controls.Survivor.ChargeUpLightTorch.performed += ctx => BeginChargeUpTorch();
        m_controls.Survivor.ChargeUpLightTorch.canceled += ctx => EndChargeUpTorch();
        m_controls.Survivor.Interact.performed += ctx => Interact();
    }

    void DecreaseTorchBattery()
    {
        if (m_lightTorch.activeSelf)
        {
            m_currentTorchLightBattery -= Time.deltaTime * m_characterData.Survivor.TorchLightDecreaseRatio;
            UIManager.Instance.UpdateUIFillAmount(UIType.Survivor, m_currentTorchLightBattery / m_characterData.Survivor.LightTorchBatteryTime);

            if (m_currentTorchLightBattery <= 0)
            {
                m_photonView.RPC("RPC_HideLight", RpcTarget.All);
                m_canUseTorchLight = false;
            }
        }
    }

    void BeginChargeUpTorch()
    {
        m_isChargingTorchLight = true;
    }

    void EndChargeUpTorch()
    {
        m_isChargingTorchLight = false;
    }

    void ChargeUpTorchBattery()
    {
        if(m_isChargingTorchLight)
        {
            if (m_currentTorchLightBattery < m_characterData.Survivor.LightTorchBatteryTime)
            {
                m_currentTorchLightBattery += Time.deltaTime * m_characterData.Survivor.TorchLightIncreaseRatio;
                UIManager.Instance.UpdateUIFillAmount(UIType.Survivor, m_currentTorchLightBattery / m_characterData.Survivor.LightTorchBatteryTime);
            }
        }
    }

    void ToggleLight()
    {
        if (m_canUseTorchLight)
        {
            if (m_lightTorch.activeSelf)
            {
                m_photonView.RPC("RPC_HideLight", RpcTarget.All);
            }
            else
            {
                m_photonView.RPC("RPC_ShowLight", RpcTarget.All);
            }
        }
        else
        {
            //Le moment ou le joueur n'a plus de batterie
        }
    }

    [PunRPC]
    void RPC_ShowLight()
    {
        GameObjectUtility.ShowGameObject(m_lightTorch);
    }

    [PunRPC]
    void RPC_HideLight()
    {
        GameObjectUtility.HideGameObject(m_lightTorch);
    }


}
