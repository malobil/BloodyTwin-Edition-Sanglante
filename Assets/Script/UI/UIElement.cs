using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum UIType { Survivor}

public abstract class UIElement : MonoBehaviour
{
    [SerializeField] private UIType m_uiType = UIType.Survivor ;
    [SerializeField] private GameObject m_linkedUI = null;

    public UIType AssociateType { get => m_uiType; }

    public virtual void Initialize()
    {
        
    }

    public virtual void Deserialize()
    {

    }

    public virtual void UpdateFillAmount(Image targetUI, float newValue)
    {
        targetUI.fillAmount = newValue;
    }

    public virtual void Show()
    {
        gameObject.SetActive(m_linkedUI);
    }
}
