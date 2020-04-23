using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Realtime;

public class PlayerUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI m_PlayerNameText;

    private Player linkedPlayerInfos;

    public void Setup(Player playerInfos)
    {
        linkedPlayerInfos = playerInfos;
        m_PlayerNameText.text = linkedPlayerInfos.NickName;
    }

    public Player GetPlayerInfo()
    {
        return linkedPlayerInfos;
    }
}
