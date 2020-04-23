using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
using TMPro;

public class RoomManager : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private TextMeshProUGUI roomName;
    [SerializeField]
    private PlayerUI playerUIPrefab;
    [SerializeField]
    private Transform playerUIParent;

    private List<PlayerUI> allPlayersInfos = new List<PlayerUI>();

    private void Awake()
    {
        GetCurrentRoomPlayer();
    }

    void GetCurrentRoomPlayer()
    {
        foreach(KeyValuePair<int,Player> playerInfo in PhotonNetwork.CurrentRoom.Players)
        {
            CreateNewPlayer(playerInfo.Value);
        }
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        base.OnPlayerEnteredRoom(newPlayer);
        CreateNewPlayer(newPlayer);
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        base.OnPlayerLeftRoom(otherPlayer);

            int index = allPlayersInfos.FindIndex(x => x.GetPlayerInfo().NickName == otherPlayer.NickName);

            if (index != -1)
            {
                DeleteExistingPlayer(index);
            }
        
    }

    private void CreateNewPlayer(Player newPlayer)
    {
        PlayerUI newPlayerUI = Instantiate(playerUIPrefab, playerUIParent);
        newPlayerUI.Setup(newPlayer);
        allPlayersInfos.Add(newPlayerUI);
        Debug.Log("Created");
    }

    private void DeleteExistingPlayer(int idx)
    {
        Destroy(allPlayersInfos[idx].gameObject);
        allPlayersInfos.RemoveAt(idx);
    }

    public void OnClick_LeaveRoom()
    {
        MainMenuManager.Singleton.HideRoomUI();
        MainMenuManager.Singleton.ShowRoomCreationUI();
        PhotonNetwork.LeaveRoom();
    }
}
