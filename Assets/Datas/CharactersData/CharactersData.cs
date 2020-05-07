﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Character data", menuName = "Create a new character")]
public class CharactersData : ScriptableObject
{
    public float MoveSpeed = 5f;
    public float CameraSensitivity = 5f;
}