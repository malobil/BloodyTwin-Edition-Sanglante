using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro ;
using Photon.Realtime;
using Photon.Pun;

public class RoomPreview : MonoBehaviour
{
    private TextMeshProUGUI textComp
    {
        get { return GetComponentInChildren<TextMeshProUGUI>(); }
    }

    private RoomInfo previewedRoom;

    public void SetupRoomInfos(RoomInfo room)
    {
        previewedRoom = room;
        textComp.text = room.Name;  
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(previewedRoom.Name);
    }

    public RoomInfo GetRoomInfo()
    {
        return previewedRoom;
    }
}
