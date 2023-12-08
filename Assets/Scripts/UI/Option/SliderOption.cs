using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SliderOption : PanelOption
{
    private Slider slider;
    private int changedCount;
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
            changedCount++;
            slider.value += value/100;
            if (changedCount >= 3)
            {
                MissionSystem.instance.EndMission(slider.name);
            }
        }
    }
}
