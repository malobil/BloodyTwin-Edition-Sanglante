using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class TestConnection : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.GameVersion = NetworkManager.gameVersion ;
        PhotonNetwork.NickName = NetworkManager.nickName;
        PhotonNetwork.ConnectUsingSettings();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        Debug.Log(PhotonNetwork.LocalPlayer.NickName + " is connected");
        PhotonNetwork.JoinLobby();
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log(PhotonNetwork.LocalPlayer.NickName + "Disconected because :" + cause.ToString(""));
    }

    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();
        Debug.Log("lobby joined");
    }
}
