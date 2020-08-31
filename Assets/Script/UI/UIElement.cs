using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UIElement : MonoBehaviour
{
    public virtual void Initialize()
    {
        
    }

    public virtual void Deserialize()
    {

    }

    protected virtual void ShowChildUI(GameObject uiToShow)
    {
        uiToShow.SetActive(true);
    }

    protected virtual void HideChildUI(GameObject uiToHide)
    {
        uiToHide.SetActive(false);
    }
}
