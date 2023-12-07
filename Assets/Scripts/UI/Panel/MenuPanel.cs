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
    public override void Init()
    {
        Debug.Log("init");
        Debug.Log(choosePanelBtn);
        choosePanelBtn.onEnter += () =>
        {
            Debug.Log("enter");
            PanelController.intstance.SetCurrentPanel(UIManager.Instance.ShowPanel<ChoosePanel>(), false);
            HideMe(null);
        };
    }
}
   

  
    
    

