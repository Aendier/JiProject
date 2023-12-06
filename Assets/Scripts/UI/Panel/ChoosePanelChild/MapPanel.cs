using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapPanel : BasePanel
{
    public Toggle SwitchTog;

    public ButtonOption checkRouteBtn;
    public ButtonOption historicalRouteBtn;
    public ButtonOption otherSettingBtn;

    public Slider richnessSld;

    private CheckRoutePanel checkRoutePanel;
    private HistoryPanel historyPanel;
    private MapOtherSettingPanel otherSettingPanel;


    public override void Init()
    {

        checkRouteBtn.onChoose += () =>
        {
            if (checkRoutePanel != null)
                checkRoutePanel.ShowMe();
            else
                checkRoutePanel = UIManager.Instance.ShowPanel<CheckRoutePanel>();
        };
        

        historicalRouteBtn.onChoose += () =>
        {
            if (historyPanel != null)
                historyPanel.ShowMe();
            else
                historyPanel = UIManager.Instance.ShowPanel<HistoryPanel>();
        };

        otherSettingBtn.onChoose += () =>
        {
            if (otherSettingPanel != null)
                otherSettingPanel.ShowMe();
            else
                otherSettingPanel = UIManager.Instance.ShowPanel<MapOtherSettingPanel>();
        };
    }

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }
}
