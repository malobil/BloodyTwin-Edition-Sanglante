using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New network datas", menuName = "Create New network datas")]
public class NetworkManager : ScriptableSingletonManager<NetworkManager>
{
    [SerializeField]
    private string m_gameVersion ;
    [SerializeField]
    private string m_nickName;

    public static string gameVersion { get { return Instance.m_gameVersion; } }
    public static string nickName { get { return Instance.m_nickName; } }
}
