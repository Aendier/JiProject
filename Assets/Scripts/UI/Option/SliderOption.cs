using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SliderOption : PanelOption
{
    private Slider slider;

    protected virtual void Awake()
    {
        slider = GetComponent<Slider>();
        hightLightItem = TransformHelper.GetChild(transform, "Handle");
        base.Awake();
    }

    public override void OnEnter()
    {
        PanelController.intstance.state = ChooseState.Slide;
    }

    public void ChangeValue(float value)
    {
        if (slider != null)
        {
            slider.value += value;
        }
    }
}
