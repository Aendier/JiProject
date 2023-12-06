using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TransformHelper
{
    public static Transform GetChild(Transform parentTF, string childName)
    {
        //在子物体中查找
        Transform childTF = parentTF.Find(childName);
        if (childTF != null) return childTF;
        //将问题交给子物体
        for (int i = 0; i < parentTF.childCount; i++)
        {
            childTF = GetChild(parentTF.GetChild(i), childName);
            if (childTF != null) return childTF;
        }
        return null;

    }
}
