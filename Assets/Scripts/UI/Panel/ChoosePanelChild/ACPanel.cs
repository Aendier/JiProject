using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ACPanel : BasePanel
{
    public Toggle switchTog;

    public Button AirOutSettingBtn;
    public Button otherSettingBtn;

    public Slider airVolumeSld;
    public Slider richnessSld;
    public override void Init()
    {
        AirOutSettingBtn.onClick.AddListener(() =>
        {
            UIManager.Instance.ShowPanel<AirOutSettingPanel>();
        });
        otherSettingBtn.onClick.AddListener(() =>
        {
            UIManager.Instance.ShowPanel<AcOtherSettingPanel>();
        });
    }

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }
}
