using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleOption : PanelOption
{
    private Toggle toggle;

    protected override void Awake()
    {
        toggle = GetComponent<Toggle>();
        hightLightItem = TransformHelper.GetChild(transform, "Background");
        base.Awake();
    }
    public override void ChangeValue(float value)
    {
        
    }

    public override void OnEnter()
    {
        toggle.isOn = !toggle.isOn;
        MissionSystem.instance.EndMission(toggle.name);
    }
}
