using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapPanel : BasePanel
{
    public Toggle SwitchTog;

    public Button checkRouteBtn;
    public Button historicalRouteBtn;
    public Button otherSettingBtn;

    public Slider richnessSld;


    public override void Init()
    {
        //checkRouteBtn.onClick.AddListener(() =>
        //{
        //    if (checkRouteBtn != null)
        //        checkRouteBtn.ShowMe();
        //    else
        //        phonePanel = UIManager.Instance.ShowPanel<PhonePanel>();
        //    HideMe(null);
        //});
    }

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }
}
