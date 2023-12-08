using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using JetBrains.Annotations;

public class MenuPanel : BasePanel
{
    public ButtonOption choosePanelBtn;

    protected override void Awake()
    {
        options = new PanelOption[][]{
            new PanelOption[] { choosePanelBtn}
        };
        base.Awake();

        Debug.Log("666");
        Debug.Log(options[0][0].name);
    }
    public override void Init()
    {

        choosePanelBtn.onEnter += () =>
        {
            Debug.Log("enter");
            MissionSystem.instance.StartMission();
            PanelController.intstance.SetCurrentPanel(UIManager.Instance.ShowPanel<ChoosePanel>(), false);
            HideMe(null);
        };
    }
}
   

  
    
    

