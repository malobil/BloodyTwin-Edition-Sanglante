#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CharactersData))]
public class CharactersDataCustomEditor : Editor
{
    private CharactersData scriptTarget
    {
        get => (CharactersData)target;
    }
    

    

    public override void OnInspectorGUI()
    {
        EnableStandardEditor();

        switch(scriptTarget.dataType)
        {
            case CharacterType.Ghost:
                EnableGhostEditor();
                break;

            case CharacterType.Killer:
                EnableKillerEditor();
                break;

            case CharacterType.Survivor:
                EnableSurvivorEditor();
                break;
        }
    }

    void EnableStandardEditor()
    {
        scriptTarget.dataType = (CharacterType)EditorGUILayout.EnumPopup("Character type", scriptTarget.dataType);
        scriptTarget.MoveSpeed = EditorGUILayout.FloatField("Move speed", scriptTarget.MoveSpeed);
        scriptTarget.CameraSensitivity = EditorGUILayout.FloatField("Camera sensitivity", scriptTarget.CameraSensitivity);
        scriptTarget.range = EditorGUILayout.FloatField("Interaction range", scriptTarget.range);
    }

    void EnableSurvivorEditor()
    {
        GUILayout.BeginVertical();
        GUILayout.Space(10f);

        GUILayout.Label("Survivor settings", EditorStyles.boldLabel);
        scriptTarget.lightTorchBatteryTime = EditorGUILayout.FloatField("Torch Battery", scriptTarget.lightTorchBatteryTime);

        GUILayout.EndVertical();
    }

    void EnableGhostEditor()
    {
        GUILayout.BeginVertical();
        GUILayout.Space(10f);

        GUILayout.Label("Ghost settings", EditorStyles.boldLabel);
        scriptTarget.ejectionForce = EditorGUILayout.FloatField("Ejection force", scriptTarget.ejectionForce);

        GUILayout.EndVertical();
    }

    void EnableKillerEditor()
    {

    }
}
#endif
