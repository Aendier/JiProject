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
    protected virtual void Awake()
    {
        oL = hightLightItem.gameObject.AddComponent<Outline>();
        oL.effectDistance = new Vector2(5, 5);
        oL.effectColor = Color.black;
        oL.enabled = false;
    }

    public abstract void OnEnter();
    

    public virtual void OnChoose() 
    {
        if(oL != null)
        {
            oL.enabled = true;
        }
    }

    public virtual void OnCancleChoose()
    {
        if (oL != null)
        {
            oL.enabled = false;
        }
    }
    public abstract void ChangeValue(float value);
}

public enum OptionType
{
    Button,
    Slider
}
