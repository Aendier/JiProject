using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicPanel : BasePanel
{
    public SliderOption volumeSlider;
    public ToggleOption switchToggle;

    public ScrollOption myFavoriteBtn;
    public ScrollOption playModeBtn;
    public ScrollOption otherSettingBtn;

    protected override void Awake()
    {
        base.Awake();
        options = new PanelOption[][]
        {
            new PanelOption[] { switchToggle, myFavoriteBtn, playModeBtn, otherSettingBtn},
            new PanelOption[] { volumeSlider }

        };
    }
    public override void Init()
    {
        myFavoriteBtn.onChoose += () =>
        {
            UIManager.Instance.ShowPanel<MyFavoritePanel>();
        };
        playModeBtn.onChoose += () =>
        {
            UIManager.Instance.ShowPanel<PlayModePanel>();
        };
        otherSettingBtn.onChoose += () =>
        {
            UIManager.Instance.ShowPanel<MusicOtherSettingPanel>();
        };

        myFavoriteBtn.onEnter += () =>
        {
            PanelController.intstance.SetCurrentPanel(UIManager.Instance.ShowPanel<MyFavoritePanel>(), false);
            UIManager.Instance.ShowPanel<MyFavoritePanel>();
        };
        playModeBtn.onEnter += () =>
        {
            PanelController.intstance.SetCurrentPanel(UIManager.Instance.ShowPanel<PlayModePanel>(), false);
            UIManager.Instance.ShowPanel<PlayModePanel>();
        };
        otherSettingBtn.onEnter += () =>
        {
            PanelController.intstance.SetCurrentPanel(UIManager.Instance.ShowPanel<MusicOtherSettingPanel>(), false);
            UIManager.Instance.ShowPanel<MusicOtherSettingPanel>();
        };

        myFavoriteBtn.onCancleChoose += () =>
        {
            UIManager.Instance.GetPanel<MyFavoritePanel>().HideMe(null);
        };
        playModeBtn.onCancleChoose += () =>
        {
            UIManager.Instance.GetPanel<PlayModePanel>().HideMe(null);
        };
        otherSettingBtn.onCancleChoose += () =>
        {
            UIManager.Instance.GetPanel<MusicOtherSettingPanel>().HideMe(null);
        };
    }
}
