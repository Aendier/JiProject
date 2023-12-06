using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonOption : PanelOption
{
    private Button btn;
    // Start is called before the first frame update
    protected override void Awake()
    {
        hightLightItem = transform;
        btn = GetComponent<Button>();
        base.Awake();
    }

    public override void OnEnter()
    {
        PanelController.intstance.state = ChooseState.Selecting;
        btn.onClick?.Invoke();
    }

}
