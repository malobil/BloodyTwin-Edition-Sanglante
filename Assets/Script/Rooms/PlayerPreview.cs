using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
using TMPro;

public class PlayerPreview : MonoBehaviourPunCallbacks
{
    [SerializeField] private TextMeshProUGUI textComp = null;


    private Player previewedPlayer;

    public void SetupPlayerInfos(Player player)
    {
        previewedPlayer = player;
        textComp.text = player.NickName;
    }


    public Player GetPlayerInfo()
    {
        return previewedPlayer;
    }
}
