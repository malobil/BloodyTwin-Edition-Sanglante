using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Realtime;

public class RoomUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI m_RoomName;

    private RoomInfo roomInfo;

    public void SetupRoomInfos(RoomInfo newRoomInfos)
    {
        roomInfo = newRoomInfos;
        m_RoomName.text = roomInfo.PlayerCount + "/" + roomInfo.MaxPlayers + " - " + roomInfo.Name;
    }

    public RoomInfo GetRoomInfo()
    {
        return roomInfo;
    }
}
