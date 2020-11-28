using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SurvivorUI : UIElement
{
    [SerializeField] private Image m_torchLight = null;

    public override void UpdateFillAmount(float newValue)
    {
        m_torchLight.fillAmount = newValue ;
    }
}
