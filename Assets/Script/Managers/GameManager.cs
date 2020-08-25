using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;

public class GameManager : MonoBehaviourPunCallbacks, IPunOwnershipCallbacks
{
    public static GameManager Instance 
    { 
        get ; 
        private set; 
    }

    [SerializeField] private GameObject m_KillerPrefab = null ;
    [SerializeField] private GameObject m_GhostPrefab = null ;
    [SerializeField] private GameObject m_SurvivorOnePrefab = null ;
    [SerializeField] private GameObject m_SurvivorTwoPrefab = null;
    [SerializeField] private GameObject m_DollPrefab= null;
    [SerializeField] private Transform m_DollSpawnPointParent = null ;

    [SerializeField] private Transform m_SurvivorOneSpawnPoint = null ;
    [SerializeField] private Transform m_SurvivorTwoSpawnPoint = null ;
    [SerializeField] private Transform m_KillerSpawnPoint = null ;
    [SerializeField] private Transform m_GhostSpawnPoint = null;

    [SerializeField] private int m_dollToSpawn = 5;

    private int m_dollLeft = 0;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.AllocateViewID(photonView);
        SpawnDoll();
        SpawnCharacter(PhotonNetwork.LocalPlayer);
    }

    void SpawnCharacter(Player playerInfo)
    {
        string role = GetCharacterRole(playerInfo);
        GameObject prefabPlayer;
        Transform spawnPoint ;
       
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

    void SpawnDoll()
    {
        List<Transform> tempDollSpawnPoints = TransformUtility.GetChilds(m_DollSpawnPointParent,false) ;

        for(int i = 0; i < m_dollToSpawn; i++)
        {
            int rdmIdx = Random.Range(0, tempDollSpawnPoints.Count - 1);

            GameObject spawnedDoll = PhotonNetwork.Instantiate(m_DollPrefab.name, tempDollSpawnPoints[rdmIdx].position, Quaternion.identity);

            if (GetCharacterRole(PhotonNetwork.LocalPlayer) != "Survivor")
            {
                GameObjectUtility.HideGameObject(spawnedDoll);
            }

            if (PhotonNetwork.LocalPlayer.IsMasterClient) //if is server 
            {
                photonView.RPC("RPC_AddDoll", RpcTarget.All);
            }

            tempDollSpawnPoints.RemoveAt(rdmIdx);
        }
    }

    [PunRPC]
    public void RPC_AddDoll()
    {
        m_dollLeft++;
    }

    [PunRPC]
    public void RPC_RemoveDoll() //sync variable (server side)
    {
        m_dollLeft--;
        Debug.LogError(m_dollLeft);
    }

    public void RemoveDoll()
    {
        photonView.RPC("RPC_RemoveDoll", RpcTarget.All);
    }

    public string GetCharacterRole(Player playerInfo)
    {
        return (string)playerInfo.CustomProperties["Role"];
    }

    public void RequestOwnership(Player playerRequest)
    {
        photonView.TransferOwnership(playerRequest);
    }

    public void OnOwnershipRequest(PhotonView targetView, Player requestingPlayer)
    {
        if (targetView != photonView)
            return;

        photonView.TransferOwnership(requestingPlayer);
    }

    public void OnOwnershipTransfered(PhotonView targetView, Player previousOwner)
    {
        if (targetView != photonView)
            return;
    }
}
