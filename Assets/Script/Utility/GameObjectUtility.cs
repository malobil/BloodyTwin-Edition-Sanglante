using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameObjectUtility
{
    public static void ToggleGameObject(GameObject toToggle)
    {
        if(toToggle.activeSelf)
        {
            toToggle.SetActive(false);
        }
        else
        {
            toToggle.SetActive(true);
        }
    }

    public static void ShowGameObject(GameObject toShow)
    {
        toShow.SetActive(true);
    }

    public static void HideGameObject(GameObject toHide)
    {
        toHide.SetActive(false);
    }

    public static void DestroyGameObject(GameObject toDestroy)
    {
        MonoBehaviour.Destroy(toDestroy);
    }
}
