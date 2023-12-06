using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleOption : PanelOption
{
    private Toggle toggle;

    public override void ChangeValue(float value)
    {
        hightLightItem = TransformHelper.GetChild(transform, "Background");
    }

    public override void OnEnter()
    {
        toggle.isOn = !toggle.isOn;
    }
}
