using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SliderOption : PanelOption
{
    private Slider slider;
    private float changedCount;
    protected override void Awake()
    {
        slider = GetComponent<Slider>();
        hightLightItem = TransformHelper.GetChild(transform, "Handle");
        base.Awake();
        changedCount = 0;
    }

    public override void OnEnter()
    {
        PanelController.intstance.state = ChooseState.Slide;
    }

    public override void ChangeValue(float value)
    {
        if (slider != null)
        {
            changedCount+= value;
            slider.value += value/100;
            if (Mathf.Abs(changedCount) >=  Mathf.Abs(value * 3))
            {
                MissionSystem.instance.EndMission(slider.name);
            }
        }
    }
}
