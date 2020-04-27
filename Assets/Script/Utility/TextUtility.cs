using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public static class TextUtility
{
    public static void ChangeTextColor(TextMeshProUGUI targetText, Color newColor)
    {
        targetText.color = newColor;
    }
}
