using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class PanelOption : MonoBehaviour
{
    private Button btn;
    private void Start()
    {
        btn = GetComponent<Button>();
    }
    public virtual void OnEnter()
    {
        btn.onClick?.Invoke();
    }

    public virtual void OnChoose() 
    {
    
    }

    public virtual void OnCancleChoose()
    {
        
    }
}
