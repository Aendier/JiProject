using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollOption : PanelOption
{
    protected override void Awake()
    {
        hightLightItem = transform;
        base.Awake();
    }
    public override void ChangeValue(float value)
    {
        
    }

    public override void OnEnter()
    {
        PanelController.intstance.state = ChooseState.Scroll;
        base.OnEnter();
    }
}
