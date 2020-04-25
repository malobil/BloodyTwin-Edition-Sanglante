using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    public static NetworkManager Singleton { get; private set; }

    private string playerNickName = "Player" ;
    public string playerVersion = "0.0.1";

    private void Awake()
    {
        if(!Singleton)
        {
            Singleton = this;
        }
        else
        {
            Destroy(this); 
        }
    }

    private void Start()
    {
        playerNickName = "Player" + Random.Range(0, 9999);
        ConnectPlayer();
    }

    void ConnectPlayer()
    {
        PhotonNetwork.GameVersion = playerVersion;
        PhotonNetwork.NickName = playerNickName;
        PhotonNetwork.ConnectUsingSettings();
    }

    public void ChangePlayerNickName(string newNickName)
    {
        playerNickName = newNickName;
        PhotonNetwork.NickName = newNickName;
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
