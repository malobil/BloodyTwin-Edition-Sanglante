using Photon.Pun;
using System.Collections;
using UnityEngine;

public class Survivor : Character
{
    [SerializeField] private GameObject m_lightTorch = null;

    private bool m_canUseTorchLight = true;
    private bool m_isChargingTorchLight = false;
    private bool m_isSprinting = false;
    private bool m_canSprint = true;
    private bool m_isTired = false;

    private float m_currentTorchLightBattery = 0f;
    private float m_currentSprintLeftDuration = 0f;

    private SurvivorUI m_survivorUI;

    public override void OnInit()
    {
        base.OnInit();

        if (!photonView.IsMine)
        {
            return;
        }

        m_currentTorchLightBattery = m_characterData.Survivor.LightTorchBatteryTime;
        m_currentSprintLeftDuration = m_characterData.Survivor.SprintMaxDuration;

        m_survivorUI = UIManager.Instance.GetUI(UIType.Survivor) as SurvivorUI;
        m_survivorUI.Show();
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        DecreaseTorchBattery();
        ChargeUpTorchBattery();
        UpdateSprintDuration();
    }

    public override void SetupControls()
    {
        base.SetupControls();
        m_controls.Survivor.ToggleLightTorch.performed += ctx => ToggleLight();
        m_controls.Survivor.ChargeUpLightTorch.performed += ctx => BeginChargeUpTorch();
        m_controls.Survivor.ChargeUpLightTorch.canceled += ctx => EndChargeUpTorch();
        m_controls.Survivor.Interact.performed += ctx => Interact();
        m_controls.Survivor.Sprint.performed += ctx => StartSprint();
        m_controls.Survivor.Sprint.canceled += ctx => StopSprint();
    }

    void DecreaseTorchBattery()
    {
        if (m_lightTorch.activeSelf)
        {
            m_currentTorchLightBattery -= Time.deltaTime * m_characterData.Survivor.TorchLightDecreaseRatio;
            m_survivorUI.UpdateFillAmount(m_survivorUI.TorchLightUI, m_currentTorchLightBattery / m_characterData.Survivor.LightTorchBatteryTime);

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
                m_survivorUI.UpdateFillAmount(m_survivorUI.TorchLightUI, m_currentTorchLightBattery / m_characterData.Survivor.LightTorchBatteryTime);
                m_canUseTorchLight = true;
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

    private void UpdateSprintDuration()
    {
        if(m_isSprinting)
        {
            m_currentSprintLeftDuration -= Time.deltaTime * m_characterData.Survivor.SprintDecreaseRatio;
            m_survivorUI.UpdateFillAmount(m_survivorUI.SprintUI, m_currentSprintLeftDuration / m_characterData.Survivor.SprintMaxDuration);

            if(m_currentSprintLeftDuration <= 0)
            {
                StopSprint();
                m_currentSprintLeftDuration = 0f;
                m_canSprint = false;
                m_isTired = true;
            }
        }
        else
        {
            if(m_currentSprintLeftDuration < m_characterData.Survivor.SprintMaxDuration)
            {
                m_currentSprintLeftDuration += Time.deltaTime * m_characterData.Survivor.SprintIncreaseRatio;
                m_survivorUI.UpdateFillAmount(m_survivorUI.SprintUI, m_currentSprintLeftDuration / m_characterData.Survivor.SprintMaxDuration);
            }
            else
            {
                m_currentSprintLeftDuration = m_characterData.Survivor.SprintMaxDuration;

                if(m_isTired)
                {
                    m_isTired = false;
                    m_canSprint = true;
                }
            }
            
        }
    }

    private void StartSprint()
    {
        if(m_canSprint)
        {
            m_currentMoveSpeed = m_characterData.Survivor.SprintMoveSpeed;
            m_isSprinting = true;
        }
    }

    private void StopSprint()
    {
        m_currentMoveSpeed = m_characterData.MoveSpeed;
        m_isSprinting = false;
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
