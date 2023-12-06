using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TransformHelper
{
    public static Transform GetChild(Transform parentTF, string childName)
    {
        //���������в���
        Transform childTF = parentTF.Find(childName);
        if (childTF != null) return childTF;
        //�����⽻��������
        for (int i = 0; i < parentTF.childCount; i++)
        {
            childTF = GetChild(parentTF.GetChild(i), childName);
            if (childTF != null) return childTF;
        }
        return null;

    }
}
