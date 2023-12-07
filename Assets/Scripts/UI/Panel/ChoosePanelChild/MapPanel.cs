using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapPanel : BasePanel
{
    public Toggle SwitchTog;

    public ScrollOption checkRouteBtn;
    public ScrollOption historicalRouteBtn;
    public ScrollOption otherSettingBtn;

    public Slider richnessSld;


    public override void Init()
    {
        //选择
        checkRouteBtn.onChoose += () =>
        {
            UIManager.Instance.ShowPanel<CheckRoutePanel>();
        };

        historicalRouteBtn.onChoose += () =>
        {
            UIManager.Instance.ShowPanel<HistoryPanel>();
        };

        otherSettingBtn.onChoose += () =>
        {
            UIManager.Instance.ShowPanel<MapOtherSettingPanel>();
        };

        //进入
        checkRouteBtn.onEnter += () =>
        {
            PanelController.intstance.SetCurrentPanel(UIManager.Instance.ShowPanel<CheckRoutePanel>(), false);
            UIManager.Instance.GetPanel<CheckRoutePanel>().ShowMe();
        };

        historicalRouteBtn.onEnter += () =>
        {
            PanelController.intstance.SetCurrentPanel(UIManager.Instance.ShowPanel<HistoryPanel>(), false);
            UIManager.Instance.GetPanel<HistoryPanel>().ShowMe();
        };

        otherSettingBtn.onEnter += () =>
        {
            PanelController.intstance.SetCurrentPanel(UIManager.Instance.ShowPanel<MapOtherSettingPanel>(), false);
            UIManager.Instance.GetPanel<MapOtherSettingPanel>().ShowMe();
        };


        //取消选择
        checkRouteBtn.onCancleChoose += () =>
        {
            UIManager.Instance.GetPanel<CheckRoutePanel>().HideMe(null);
        };

        historicalRouteBtn.onCancleChoose += () =>
        {
            UIManager.Instance.GetPanel<HistoryPanel>().HideMe(null);
        };

        otherSettingBtn.onCancleChoose += () =>
        {
            UIManager.Instance.GetPanel<MapOtherSettingPanel>().HideMe(null);
        };

    }
}
