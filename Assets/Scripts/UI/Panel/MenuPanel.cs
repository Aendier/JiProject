using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using JetBrains.Annotations;

public class MenuPanel : BasePanel
{
    public Button btnMenu;

    public override void Init()
    {
        btnMenu.onClick.AddListener(() =>
        {
            //显示选择面板
            UIManager.Instance.ShowPanel<ChoosePanel>();
            //隐藏自己
            UIManager.Instance.HidePanel<MenuPanel>();
        });
    }
}
   

  
    
    

