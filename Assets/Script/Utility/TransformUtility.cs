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
