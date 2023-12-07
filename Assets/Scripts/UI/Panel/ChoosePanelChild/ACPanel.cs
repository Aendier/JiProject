using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ACPanel : BasePanel
{
    public Toggle switchTog;

    public ScrollOption airOutSettingBtn;
    public ScrollOption otherSettingBtn;

    public Slider airVolumeSld;
    public Slider richnessSld;
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
