using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelController : MonoBehaviour
{
    public static PanelController intstance;

    public BasePanel currentPanel;

    public int currentOptionIndex;
    public PanelOption currentOption;

    public RectTransform cursor;

    public ChooseState state;

    private void Awake()
    {
        intstance = this;
    }
    public void Init()
    {
        currentOptionIndex = 0;
        
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            //返回主界面
        }

        switch (state)
        {
            case ChooseState.Selecting:
                if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.W))
                {
                    Debug.Log("下一个");
                    currentOptionIndex--;
                    ChooseOption(currentOptionIndex);
                }

                if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
                {
                    Debug.Log("上一个");
                    currentOptionIndex++;
                    ChooseOption(currentOptionIndex);
                }

                if (Input.GetKeyDown(KeyCode.Return))
                {
                    Debug.Log("Selecting Return");
                    EnterOption();
                }
                break;
            case ChooseState.Slide:
                if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.W))
                {
                    
                }

                if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
                {
                    Debug.Log("上一个");
                    currentOptionIndex++;
                    ChooseOption(currentOptionIndex);
                }

                if (Input.GetKeyDown(KeyCode.Return))
                {
                    EnterOption();
                }

                break;
        }
    }

    public void SetCurrentPanel(BasePanel panel)
    {
        currentPanel = panel;
        currentOption = currentPanel.options[0];
    }

    public void ChooseOption(int index)
    {
        if (index < 0)
        {
            Debug.Log("太小了");
            currentOptionIndex = 0;
            return;
        }
        if (index >= currentPanel.options.Length)
        {
            Debug.Log("太大了");
            currentOptionIndex = currentPanel.options.Length - 1;
            return;
        }
        if(currentOption != null)
        {
            currentOption.OnCancleChoose();
        }

        currentOption = currentPanel.options[currentOptionIndex];
        currentOption.OnChoose();

        Debug.Log("当前选项为：" + currentOption.name);
    }

    public void EnterOption()
    {
        if (currentOption == null) return;
        currentOption.OnEnter();
    }
}

public enum ChooseState
{
    Selecting,
    Slide
}