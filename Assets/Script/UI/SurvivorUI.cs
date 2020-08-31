using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurvivorUI : UIElement
{
    public override void Initialize()
    {
        ShowChildUI(gameObject);
    }
}
