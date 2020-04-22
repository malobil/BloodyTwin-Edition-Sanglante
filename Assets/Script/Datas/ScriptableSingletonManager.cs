using System.Linq;
using UnityEngine;

public abstract class ScriptableSingletonManager<T> : ScriptableObject where T : ScriptableObject
{
    public static T _instance = null;

    public static T Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = Resources.FindObjectsOfTypeAll<T>().FirstOrDefault();
            }
            return _instance;
        }
    }
}
