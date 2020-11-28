using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum CharacterType { Ghost, Killer, Survivor}

[CreateAssetMenu(fileName = "New character datas", menuName = "Create new character datas")]
public class CharactersData : ScriptableObject
{
    public CharacterType dataType;

    public float MoveSpeed = 5f;
    public float CameraSensitivity = 5f;
    public float range = 5f;
    public float ejectionForce = 10f ;

    public SurvivorData Survivor;
    public KillerData Killer;
    public GhostData Ghost;

    
}

[Serializable]
public class SurvivorData
{
    public float LightTorchBatteryTime = 10f;
    public float TimeToFullyChargeUp = 5f;
}

[Serializable]
public class KillerData
{
    public float KillerTest = 0;
}

[Serializable]
public class GhostData
{
    public float GhostTest = 0;
}
