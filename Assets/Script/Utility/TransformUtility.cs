using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TransformUtility
{
    public static void DestroyChildren(Transform t, bool destroyImmediately = false)
    {
        foreach(Transform child in t)
        {
            if(destroyImmediately)
            {
                MonoBehaviour.DestroyImmediate(child.gameObject);
            }
            else
            {
                MonoBehaviour.Destroy(child.gameObject);
            }
        }
    }

    public static List<Transform> GetChilds(Transform parent, bool getChildsChild)
    {
        List<Transform> childList = new List<Transform>();

        foreach(Transform child in parent)
        {
            childList.Add(child);

            if(getChildsChild)
            {
                foreach(Transform childChilds in child)
                {
                    childList.Add(childChilds);
                }
            }
        }

        return childList;
    }

    public static Transform GetNeareastObject(List<Transform> objectList, Transform startPoint, float maxRange = 9999f)
    {
        float neareastDist = 9999f;
        Transform nearestObject = null ;

        for(int i = 0; i < objectList.Count; i++)
        {
            float newDist = Vector3.Distance(objectList[i].position, startPoint.position);

            if (newDist < neareastDist && newDist <= maxRange)
            {
                nearestObject = objectList[i];
                neareastDist = newDist;
            }
        }

        return nearestObject;
    }
}
