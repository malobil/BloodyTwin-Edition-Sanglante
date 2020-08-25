using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doll : InteractableObject
{
    public override void OnInteract()
    {
        base.OnInteract();
        GameManager.Instance.RemoveDoll();
    }
}
