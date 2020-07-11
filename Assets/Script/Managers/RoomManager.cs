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
    public int sceneToLoadIdx = 2;
    public SurvivorsUI survivorUI ;
    public SpectatorsUI spectsUI ;
    public KillerUI killerUI ;
    public GhostUI ghostUI ;

    [SerializeField] private GameObject m_RoomUI = null ;
    [SerializeField] private GameObject m_RoomListUI = null ;

    private List<RoomPreview> existingRooms = new List<RoomPreview>() ;
    private List<PlayerPreview> existingPlayers = new List<PlayerPreview>() ;

    private ExitGames.Client.Photon.Hashtable playerRole = new ExitGames.Client.Photon.Hashtable() ;

    #region Photon callbacks

    public override void OnCreatedRoom()
    {
        Debug.Log("Room created");
        GameObjectUtility.ShowGameObject(inRoom.m_LaunchButton);
    }

    public override void OnMasterClientSwitched(Player newMasterClient)
    {
        base.OnMasterClientSwitched(newMasterClient);
        Debug.Log("New master : " + newMasterClient.NickName);

        if(newMasterClient == PhotonNetwork.LocalPlayer)
        {
            GameObjectUtility.ShowGameObject(inRoom.m_LaunchButton);
        }
        else if(newMasterClient != PhotonNetwork.LocalPlayer)
        {
            GameObjectUtility.HideGameObject(inRoom.m_LaunchButton);
        }
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
        TransformUtility.DestroyChildren(roomCreation.m_RoompPreviewParent);
        existingRooms.Clear();
        GameObjectUtility.ShowGameObject(m_RoomUI);
        GameObjectUtility.HideGameObject(m_RoomListUI);

        JoinSpectators();

        foreach (KeyValuePair<int,Player> players in PhotonNetwork.CurrentRoom.Players)
        {
            SetupNewPlayer(players.Value);
            ShowPlayerRole(players.Value,(string)players.Value.CustomProperties["Role"]);
        }

       
    }

    public override void OnLeftRoom()
    {
        Debug.Log("Room leaved");
        GameObjectUtility.HideGameObject(m_RoomUI);
        GameObjectUtility.ShowGameObject(m_RoomListUI);
        GameObjectUtility.HideGameObject(inRoom.m_LaunchButton);
        TransformUtility.DestroyChildren(survivorUI.m_UIParent);
        TransformUtility.DestroyChildren(killerUI.m_UIParent);
        TransformUtility.DestroyChildren(ghostUI.m_UIParent);
        TransformUtility.DestroyChildren(spectsUI.m_UIParent);
        existingPlayers.Clear();
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        SetupNewPlayer(newPlayer);
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        base.OnPlayerLeftRoom(otherPlayer);
        HidePlayer(otherPlayer);
    }

    public override void OnPlayerPropertiesUpdate(Player targetPlayer, ExitGames.Client.Photon.Hashtable changedProps)
    {
        if (targetPlayer != null)
        {
            if (changedProps.ContainsKey("Role"))
            {
                ShowPlayerRole(targetPlayer,(string)changedProps["Role"]);
            }
        }
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
        roomOpt.BroadcastPropsChangeToAll = true;
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

    #region InRoom

    public void JoinSpectators()
    {
        playerRole["Role"] = "Spectator";
        PhotonNetwork.SetPlayerCustomProperties(playerRole);
    }

    public void JoinKiller()
    {
        foreach (KeyValuePair<int, Player> players in PhotonNetwork.CurrentRoom.Players)
        {
            if((string)players.Value.CustomProperties["Role"] == "Killer")
            {
                return;
            }
        }

        playerRole["Role"] = "Killer";
        PhotonNetwork.SetPlayerCustomProperties(playerRole);
    }

    public void JoinGhost()
    {
        foreach (KeyValuePair<int, Player> players in PhotonNetwork.CurrentRoom.Players)
        {
            if ((string)players.Value.CustomProperties["Role"] == "Ghost")
            {
                return;
            }
        }

        playerRole["Role"] = "Ghost";
        PhotonNetwork.SetPlayerCustomProperties(playerRole);
    }

    public void JoinSurvivor()
    {
        int survivorCount = 0;
        foreach (KeyValuePair<int, Player> players in PhotonNetwork.CurrentRoom.Players)
        {
            if ((string)players.Value.CustomProperties["Role"] == "Killer")
            {
                survivorCount++;
            }
        }

        if(survivorCount >= 2)
        {
            return;
        }

        playerRole["Role"] = "Survivor";
        PhotonNetwork.SetPlayerCustomProperties(playerRole);
    }

    void SetupNewPlayer(Player playerToSetup)
    {
        PlayerPreview newPlayer = Instantiate(inRoom.m_PlayerPreviewPrefab,transform);
        newPlayer.SetupPlayerInfos(playerToSetup);
        existingPlayers.Add(newPlayer);
    }

    void ShowPlayerRole(Player playerToShow, string newRole)
    {
        int idx = existingPlayers.FindIndex(x => x.GetPlayerInfo() == playerToShow);

        if(idx != -1)
        {
            PlayerPreview newPreview;
            newPreview = existingPlayers[idx];

            switch (newRole)
            {
                case "Spectator":
                    newPreview.transform.SetParent(spectsUI.m_UIParent);
                    break;
                case "Killer":
                    newPreview.transform.SetParent(killerUI.m_UIParent);
                    break;
                case "Ghost":
                    newPreview.transform.SetParent(ghostUI.m_UIParent);
                    break;
                case "Survivor":
                    newPreview.transform.SetParent(survivorUI.m_UIParent);
                    break;
            }
        }
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

    public void LaunchGame()
    {
        if(PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.CurrentRoom.IsOpen = false;
            PhotonNetwork.CurrentRoom.IsVisible = false;
            PhotonNetwork.LoadLevel(sceneToLoadIdx);
        }
    }
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
    
    public GameObject m_LaunchButton;
}

[System.Serializable]
public class KillerUI
{
    public GameObject m_JoinButton;
    public Transform m_UIParent;
}

[System.Serializable]
public class GhostUI
{
    public GameObject m_JoinButton;
    public Transform m_UIParent;
}

[System.Serializable]
public class SurvivorsUI
{
    public GameObject m_JoinButton;
    public Transform m_UIParent;
}

[System.Serializable]
public class SpectatorsUI
{
    public GameObject m_JoinButton;
    public Transform m_UIParent;
}