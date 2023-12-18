using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonOption : PanelOption
{
    protected override void Awake()
    {
        hightLightItem = transform;
        base.Awake();
    }

    public override void OnEnter()
    {
        PanelController.intstance.state = ChooseState.Selecting;
        MissionSystem.instance.RecordMission(transform.name);
        base.OnEnter();
    }

    public override void ChangeValue(float value)
    {

    } 
}
