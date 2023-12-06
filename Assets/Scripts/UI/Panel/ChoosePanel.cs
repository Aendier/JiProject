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

    private PhonePanel phonePanel;
    private ACPanel acPanel;
    private NaviPanel naviPanel;
    private MusicPanel musicPanel;
    private RadioPanel radioPanel;

    public override void Init()
    {
        phoneBtn.onClick.AddListener(() =>
        {
            if (phonePanel != null)
                phonePanel.ShowMe();
            else
                phonePanel = UIManager.Instance.ShowPanel<PhonePanel>();
            HideMe(null);
        });

        ACBtn.onClick.AddListener(() =>
        {
            if (acPanel != null)
                acPanel.ShowMe();
            else
                acPanel = UIManager.Instance.ShowPanel<ACPanel>();
            HideMe(null);
        });

        NaviBtn.onClick.AddListener(() =>
        {
            if (naviPanel != null)
                naviPanel.ShowMe();
            else
                naviPanel = UIManager.Instance.ShowPanel<NaviPanel>();
            HideMe(null);
        });

        MusicBtn.onClick.AddListener(() =>
        {
            if (musicPanel != null)
                musicPanel.ShowMe();
            else
                musicPanel = UIManager.Instance.ShowPanel<MusicPanel>();
            HideMe(null);
        });

        RadioBtn.onClick.AddListener(() =>
        {
            if (radioPanel != null)
                radioPanel.ShowMe();
            else
                radioPanel = UIManager.Instance.ShowPanel<RadioPanel>();
            HideMe(null);
        });
    }

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

}
