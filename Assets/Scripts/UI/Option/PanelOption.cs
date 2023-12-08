using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public abstract  class PanelOption : MonoBehaviour
{
    protected Transform hightLightItem;
    protected Outline oL;

    public event Action onChoose;
    public event Action onCancleChoose;
    public event Action onEnter;
    protected virtual void Awake()
    {
        oL = hightLightItem.gameObject.AddComponent<Outline>();
        oL.effectDistance = new Vector2(3, 3);
        oL.effectColor = Color.black;
        oL.enabled = false;
    }

    public virtual void OnEnter()
    {
        onEnter?.Invoke();
    }
    

    public virtual void OnChoose() 
    {
        if(oL != null)
        {
            oL.enabled = true;
        }
        onChoose?.Invoke();
    }

    public virtual void OnCancelChoose()
    {
        if (oL != null)
        {
            oL.enabled = false;
        }
        onCancleChoose?.Invoke();
    }
    public abstract void ChangeValue(float value);
}

