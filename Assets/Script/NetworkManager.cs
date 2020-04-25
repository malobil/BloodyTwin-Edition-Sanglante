using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    private void Start()
    {
        ConnectPlayer();
    }

    void ConnectPlayer()
    {
        PhotonNetwork.GameVersion = "0.0.1";
        PhotonNetwork.NickName = "malobilu";
        PhotonNetwork.ConnectUsingSettings();
     
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected");
        PhotonNetwork.JoinLobby();
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log("Disconnected due to : " + cause.ToString(""));
    }
}
