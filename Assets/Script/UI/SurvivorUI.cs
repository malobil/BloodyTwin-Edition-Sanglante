using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SurvivorUI : UIElement
{
    [SerializeField] private Image m_torchLight = null;
    [SerializeField] private Image m_sprint = null;

    public Image TorchLightUI { get => m_torchLight; }
    public Image SprintUI { get => m_sprint; }
}
