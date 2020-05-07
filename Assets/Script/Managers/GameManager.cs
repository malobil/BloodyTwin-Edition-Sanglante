using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;

public class GameManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameObject m_KillerPrefab;
    [SerializeField] private GameObject m_GhostPrefab;
    [SerializeField] private GameObject m_SurvivorOnePrefab;
    [SerializeField] private GameObject m_SurvivorTwoPrefab;

    [SerializeField] private Transform m_SurvivorOneSpawnPoint;
    [SerializeField] private Transform m_SurvivorTwoSpawnPoint;
    [SerializeField] private Transform m_KillerSpawnPoint;
    [SerializeField] private Transform m_GhostSpawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        SpawnCharacter(PhotonNetwork.LocalPlayer);
    }

    void SpawnCharacter(Player playerInfo)
    {
        string role = (string)playerInfo.CustomProperties["Role"];
        GameObject prefabPlayer;
        Transform spawnPoint ;
        Debug.Log(role);
        
        switch(role)
        {
            case "Killer":
                prefabPlayer = m_KillerPrefab;
                spawnPoint = m_KillerSpawnPoint;
                break;
            case "Survivor":
                prefabPlayer = m_SurvivorOnePrefab;
                spawnPoint = m_SurvivorOneSpawnPoint;
                break;
            case "Ghost":
                prefabPlayer = m_GhostPrefab;
                spawnPoint = m_GhostSpawnPoint;
                break;
            default:
                prefabPlayer = m_SurvivorTwoPrefab;
                spawnPoint = m_SurvivorTwoSpawnPoint;
                break;
        }

        PhotonNetwork.Instantiate(prefabPlayer.name, spawnPoint.position, Quaternion.identity);
    }
}
