using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirOutSettingPanel : BasePanel
{
    public ButtonOption btn1;
    public ButtonOption btn2;
    public ButtonOption btn3;
    protected override void Awake()
    {
        base.Awake();
        options = new PanelOption[][]
        {
            new PanelOption[]{btn1,btn2,btn3}
        };

    }
    public override void Init()
    {
        btn1.onEnter += () =>
        {
            MissionSystem.instance.EndMission(transform.parent.name + "-" + transform.name + "-" + btn1.name);
        };
        btn2.onEnter += () =>
        {
            MissionSystem.instance.EndMission(transform.parent.name + "-" + transform.name + "-" + btn2.name);
        };
        btn3.onEnter += () =>
        {
            MissionSystem.instance.EndMission(transform.parent.name + "-" + transform.name + "-" + btn3.name);
        };
    }
}
