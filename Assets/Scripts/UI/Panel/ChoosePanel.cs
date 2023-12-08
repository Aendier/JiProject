using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoosePanel : BasePanel
{
    public ButtonOption phoneBtn;
    public ButtonOption ACBtn;
    public ButtonOption MapBtn;
    public ButtonOption MusicBtn;
    public ButtonOption RadioBtn;

    protected override void Awake()
    {
        base.Awake();
        options = new PanelOption[][]
        {
            new PanelOption[]{phoneBtn},
            new PanelOption[]{ACBtn},
            new PanelOption[]{MapBtn},
            new PanelOption[]{MusicBtn},
            new PanelOption[]{RadioBtn}
        };
    }

    public override void Init()
    {
        phoneBtn.onEnter += () =>
        {
            PanelController.intstance.SetCurrentPanel(UIManager.Instance.ShowPanel<PhonePanel>());
        };
        ACBtn.onEnter += () =>
        {
            PanelController.intstance.SetCurrentPanel(UIManager.Instance.ShowPanel<ACPanel>());
        };
        MapBtn.onEnter += () =>
        {
            PanelController.intstance.SetCurrentPanel(UIManager.Instance.ShowPanel<MapPanel>());
        };
        MusicBtn.onEnter += () =>
        {
            PanelController.intstance.SetCurrentPanel(UIManager.Instance.ShowPanel<MusicPanel>());
        };
        RadioBtn.onEnter += () =>
        {
            PanelController.intstance.SetCurrentPanel(UIManager.Instance.ShowPanel<RadioPanel>());
        };
    }

    protected override void Start()
    {
        base.Start();
    }

}
