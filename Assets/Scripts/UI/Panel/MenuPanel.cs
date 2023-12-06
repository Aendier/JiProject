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
    private ChoosePanel choosePanel;
    public override void Init()
    {
        btnMenu.onClick.AddListener(() =>
        {
            Debug.Log("ChooseBtn OnClick");
            //��ʾѡ�����
            if (choosePanel != null)
            {
                choosePanel.ShowMe();
            }
            else 
            {
                choosePanel = UIManager.Instance.ShowPanel<ChoosePanel>();
            }
            //�����Լ�
            HideMe(null);
        });
    }
}
   

  
    
    

