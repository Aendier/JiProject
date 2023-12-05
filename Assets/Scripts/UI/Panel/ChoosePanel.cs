using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoosePanel : BasePanel
{
    public Button phoneBtn;
    public Button ACBtn;
    public Button NaviBtn;
    public Button MusicBtn;
    public Button RadioBtn;

    public override void Init()
    {
        phoneBtn.onClick.AddListener(() =>
        {
            UIManager.Instance.ShowPanel<PhonePanel>();
            UIManager.Instance.HidePanel<ChoosePanel>();
        });
        ACBtn.onClick.AddListener(() =>
        {
            UIManager.Instance.ShowPanel<ACPanel>();
            UIManager.Instance.HidePanel<ChoosePanel>();
        });
        NaviBtn.onClick.AddListener(() =>
        {
            UIManager.Instance.ShowPanel<NaviPanel>();
            UIManager.Instance.HidePanel<ChoosePanel>();
        });
        MusicBtn.onClick.AddListener(() =>
        {
            UIManager.Instance.ShowPanel<MusicPanel>();
            UIManager.Instance.HidePanel<ChoosePanel>();
        });
        RadioBtn.onClick.AddListener(() =>
        {
            UIManager.Instance.ShowPanel<RadioPanel>();
            UIManager.Instance.HidePanel<ChoosePanel>();
        });
    }

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

}
