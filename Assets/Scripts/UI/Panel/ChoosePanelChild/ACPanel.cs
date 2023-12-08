using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ACPanel : BasePanel
{
    public ToggleOption switchTog;

    public ScrollOption airOutSettingBtn;
    public ScrollOption otherSettingBtn;

    public SliderOption airVolumeSld;
    public SliderOption richnessSld;
    protected override void Awake()
    {
        base.Awake();
        options = new PanelOption[][]
        {
            new PanelOption[] { switchTog, airOutSettingBtn, otherSettingBtn},
            new PanelOption[] { airVolumeSld, richnessSld }
            //new PanelOption[] {  }
        };
    }
    public override void Init()
    {
        airOutSettingBtn.onChoose += () =>
        {
            UIManager.Instance.ShowPanel<AirOutSettingPanel>();
        };
        otherSettingBtn.onChoose += () =>
        {
            UIManager.Instance.ShowPanel<AcOtherSettingPanel>();
        }; 

        airOutSettingBtn.onEnter += () =>
        {
            PanelController.intstance.SetCurrentPanel(UIManager.Instance.ShowPanel<AirOutSettingPanel>(),false);
            UIManager.Instance.GetPanel<AirOutSettingPanel>().ShowMe() ;
        };
        otherSettingBtn.onEnter += ()=>
        {
            PanelController.intstance.SetCurrentPanel(UIManager.Instance.ShowPanel<AcOtherSettingPanel>(), false);
            UIManager.Instance.GetPanel<AcOtherSettingPanel>().ShowMe();
        };

        airOutSettingBtn.onCancleChoose += () =>
        {
            UIManager.Instance.GetPanel<AirOutSettingPanel>().HideMe(null);
        };
        otherSettingBtn.onCancleChoose += () =>
        {
            UIManager.Instance.GetPanel<AcOtherSettingPanel>().HideMe(null);
        };
    }
}
