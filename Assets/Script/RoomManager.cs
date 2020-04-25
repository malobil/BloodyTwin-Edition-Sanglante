using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
using TMPro;

public class RoomManager : MonoBehaviourPunCallbacks
{
    public RoomCreationUI roomCreation;
    public RoomUI inRoom;
    [SerializeField] private GameObject m_RoomUI ;
    [SerializeField] private GameObject m_RoomListUI ;

    private List<RoomPreview> existingRooms = new List<RoomPreview>();
    private List<PlayerPreview> existingPlayers = new List<PlayerPreview>();


    #region Photon callbacks

    public override void OnCreatedRoom()
    {
        Debug.Log("Room created");
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Room creation failed : " + returnCode);
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        foreach(RoomInfo room in roomList)
        {
            int idx = existingRooms.FindIndex(x => room.Name == x.GetRoomInfo().Name);

            if(idx == -1 && room.IsVisible && room.IsOpen && room.MaxPlayers > 0)
            {
                ShowRoomPreview(room);
            }
            else if(idx != -1)
            {
                if (room.MaxPlayers <= 0)
                {
                    GameObjectUtility.DestroyGameObject(existingRooms[idx].gameObject);
                    existingRooms.RemoveAt(idx);
                }
            }
        }
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Room joined");
        existingRooms.Clear();
        TransformUtility.DestroyChildren(roomCreation.m_RoompPreviewParent);
        GameObjectUtility.ShowGameObject(m_RoomUI);
        GameObjectUtility.HideGameObject(m_RoomListUI);

        foreach(KeyValuePair<int,Player> inRoomPlayer in PhotonNetwork.CurrentRoom.Players)
        {
            ShowPlayer(inRoomPlayer.Value);
        }
    }

    public override void OnLeftRoom()
    {
        Debug.Log("Room leaved");
        GameObjectUtility.HideGameObject(m_RoomUI);
        GameObjectUtility.ShowGameObject(m_RoomListUI);
        TransformUtility.DestroyChildren(inRoom.m_PlayerPreviewParent);
        existingPlayers.Clear();
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        base.OnPlayerEnteredRoom(newPlayer);
        ShowPlayer(newPlayer);
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        base.OnPlayerLeftRoom(otherPlayer);
        HidePlayer(otherPlayer);
    }

    #endregion

    #region Room
    public void CreateRoom()
    {
        if(!PhotonNetwork.IsConnectedAndReady || !PhotonNetwork.InLobby)
        {
            return;
        }

        RoomOptions roomOpt = new RoomOptions();
        roomOpt.MaxPlayers = 4;
        roomOpt.IsOpen = true;
        roomOpt.IsVisible = true;
        PhotonNetwork.CreateRoom(roomCreation.m_RoomNamingUI.text, roomOpt,TypedLobby.Default);
    }

    public void LeaveRoom()
    {
        if(PhotonNetwork.CurrentRoom != null)
        {
            PhotonNetwork.LeaveRoom(true);
        }
    }

    void ShowRoomPreview(RoomInfo roomToShow)
    {
        RoomPreview newPreview = Instantiate(roomCreation.m_RoompPreviewPrefab, roomCreation.m_RoompPreviewParent);
        newPreview.SetupRoomInfos(roomToShow);
        existingRooms.Add(newPreview);
    }

    #endregion

    #region Player

    public void ChangePlayerNickName()
    {
        NetworkManager.Singleton.ChangePlayerNickName(roomCreation.m_PlayerNickNameText.text);
    }

    void ShowPlayer(Player playerToShow)
    {
        PlayerPreview newPreview = Instantiate(inRoom.m_PlayerPreviewPrefab, inRoom.m_PlayerPreviewParent);
        newPreview.SetupPlayerInfos(playerToShow);
        existingPlayers.Add(newPreview);
    }

    void HidePlayer(Player playerToHide)
    {
        int idx = existingPlayers.FindIndex(x => x.GetPlayerInfo().NickName == playerToHide.NickName);

        if(idx != -1)
        {
            GameObjectUtility.DestroyGameObject(existingPlayers[idx].gameObject);
            existingPlayers.RemoveAt(idx);
        }
    }

    #endregion
}

[System.Serializable]
public class RoomCreationUI
{
    public TextMeshProUGUI m_RoomNamingUI;
    public TextMeshProUGUI m_PlayerNickNameText;
    public RoomPreview m_RoompPreviewPrefab;
    public Transform m_RoompPreviewParent;
}

[System.Serializable]
public class RoomUI
{
    public TextMeshProUGUI m_RoomNameUI;
    public PlayerPreview m_PlayerPreviewPrefab;
    public Transform m_PlayerPreviewParent;
}