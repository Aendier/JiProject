using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicPanel : BasePanel
{
    public Slider volumeSlider;
    public Toggle switchToggle;

    public Button myFavoriteBtn;
    public Button playModeBtn;
    public Button otherSettingBtn;

    private MyFavoritePanel myFavoritePanel;
    private PlayModePanel playModePanel;
    private MusicOtherSettingPanel musicOtherSettingPanel;

    public override void Init()
    {
        myFavoriteBtn.onClick.AddListener(() =>
        {
            if (myFavoritePanel != null)
                myFavoritePanel.ShowMe();
            else
                myFavoritePanel = UIManager.Instance.ShowPanel<MyFavoritePanel>();
            HideMe(null);
        });

        playModeBtn.onClick.AddListener(() =>
        {
            if (playModePanel != null)
                playModePanel.ShowMe();
            else
                playModePanel = UIManager.Instance.ShowPanel<PlayModePanel>();
            HideMe(null);
        });

        otherSettingBtn.onClick.AddListener(() =>
        {
            if (musicOtherSettingPanel != null)
                musicOtherSettingPanel.ShowMe();
            else
                musicOtherSettingPanel = UIManager.Instance.ShowPanel<MusicOtherSettingPanel>();
            HideMe(null);
        });
    }

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }
}
