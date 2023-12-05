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
            //��ʾѡ�����
            UIManager.Instance.ShowPanel<ChoosePanel>();
            //�����Լ�
            UIManager.Instance.HidePanel<MenuPanel>();
        });
    }
}
   

  
    
    

