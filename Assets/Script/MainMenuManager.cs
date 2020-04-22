﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;
using Photon.Realtime;

public class MainMenuManager : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private TextMeshProUGUI roomName;
    [SerializeField]
    private RoomUI roomUIPrefab ;
    [SerializeField]
    private Transform roomUIParent;

    private List<RoomUI> allRoomInfos = new List<RoomUI>();


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateARoom()
    {
        RoomOptions options = new RoomOptions();
        options.MaxPlayers = 4;
        PhotonNetwork.JoinOrCreateRoom(roomName.text, options, TypedLobby.Default);
    }

    public override void OnCreatedRoom()
    {
        base.OnCreatedRoom();
        Debug.Log("Room created");
      
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        
       foreach(RoomInfo infos in roomList)
        {
            int index = allRoomInfos.FindIndex(x => x.GetRoomInfo().Name == infos.Name);
            Debug.Log(infos.Name);
            if (index != -1)
            {
                DeleteExistingRoom(index);
            }
            else
            {
                CreateNewRoom(infos);
            }
        }
    }

    private void DeleteExistingRoom(int index)
    {
        Destroy(allRoomInfos[index].gameObject);
        allRoomInfos.RemoveAt(index);
        Debug.Log("delete");
    }

    private void CreateNewRoom(RoomInfo infos)
    {
        RoomUI newRoom = Instantiate(roomUIPrefab, roomUIParent);
        newRoom.SetupRoomInfos(infos);
        allRoomInfos.Add(newRoom);
        Debug.Log("Created");
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        base.OnCreateRoomFailed(returnCode, message);
        Debug.Log("Failed to create room : " + message);
    }
}
