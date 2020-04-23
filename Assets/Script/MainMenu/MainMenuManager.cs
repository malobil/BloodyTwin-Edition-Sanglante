using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    public static MainMenuManager Singleton { get; private set; }

    [SerializeField]
    private GameObject m_RoomCreationUI;

    [SerializeField]
    private GameObject m_RoomUI;

    private void Awake()
    {
        if(Singleton)
        {
            Destroy(this);
        }
        else
        {
            Singleton = this;
        }
    }

    public void ShowRoomCreationUI()
    {
        m_RoomCreationUI.SetActive(true);
    }

    public void HideRoomCreationUI()
    {
        m_RoomCreationUI.SetActive(false);
    }

    public void ShowRoomUI()
    {
        m_RoomUI.SetActive(true);
    }

    public void HideRoomUI()
    {
        m_RoomUI.SetActive(false);
    }
}
