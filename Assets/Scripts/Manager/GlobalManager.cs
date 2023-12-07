using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalManager : MonoBehaviour
{
    public static GlobalManager instance;
    void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        //UIManager.Instance.ShowPanel<MenuPanel>();
        PanelController.intstance.Init();
        PanelController.intstance.SetCurrentPanel(UIManager.Instance.ShowPanel<MenuPanel>());
    }
}
