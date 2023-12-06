using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public abstract  class PanelOption : MonoBehaviour
{
    public OptionType type;

    protected Transform hightLightItem;
    protected Outline oL;
    protected virtual void Awake()
    {
        oL = hightLightItem.gameObject.AddComponent<Outline>();
        oL.effectColor = Color.red;
        oL.enabled = false;
    }

    public abstract void OnEnter();
    

    public virtual void OnChoose() 
    {
        oL.enabled = true;
    }

    public virtual void OnCancleChoose()
    {
        oL.enabled = false;
    }
}

public enum OptionType
{
    Button,
    Slider
}
