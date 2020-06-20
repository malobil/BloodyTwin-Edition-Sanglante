using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CharacterType { Ghost, Killer, Survivor}

[CreateAssetMenu(fileName = "New character datas", menuName = "Create new character datas")]
public class CharactersData : ScriptableObject
{
    [SerializeField] private CharacterType dataType;

    public float MoveSpeed = 5f;
    public float CameraSensitivity = 5f;
    public float range = 5f;
    public float ejectionForce = 10f ;

    /// <summary>
    /// Survivor datas
    /// </summary>
    public float lightTorchBatteryTime = 10f;
    public float timeToFullyChargeUp = 5f;
}
