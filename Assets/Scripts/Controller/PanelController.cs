using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;
using UnityEngine.UI;

public class PanelController : MonoBehaviour
{
    public static PanelController intstance;

    public BasePanel previousPanel;
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
        switch (state)
        {
            case ChooseState.Selecting:
                if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.W))
                {
                    Debug.Log("��һ��");
                    currentOptionIndex--;
                    ChooseOption(currentOptionIndex);
                }

                if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
                {
                    Debug.Log("��һ��");
                    currentOptionIndex++;
                    ChooseOption(currentOptionIndex);
                }

                if (Input.GetKeyDown(KeyCode.Return))
                {
                    Debug.Log("Selecting Enter");
                    EnterOption();
                }

                if (Input.GetKeyDown(KeyCode.R))
                {
                    ReturnPanel();
                }
                break;
            case ChooseState.Slide:
                if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.W))
                {
                    currentOption.ChangeValue(-3);
                }

                if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
                {
                    currentOption.ChangeValue(+3);
                }

                if (Input.GetKeyDown(KeyCode.Return))
                {
                    EnterOption();
                }

                if (Input.GetKeyDown(KeyCode.R))
                {
                    ReturnOption();
                }
                break;
        }
    }

    public void ReturnPanel()
    {
        if(previousPanel != null)
        {
            previousPanel.ShowMe();
            previousPanel.HideMe(null);
        }
    }

    public void ReturnOption()
    {
        state = ChooseState.Selecting;
    }
    public void SetCurrentPanel(BasePanel panel)
    {
        currentOptionIndex = panel.defaultOptionIndex;
        previousPanel = currentPanel;
        currentPanel = panel;
        currentOption = currentPanel.options[panel.defaultOptionIndex];
    }

    public void ChooseOption(int index)
    {
        if (index < 0)
        {
            Debug.Log("̫С��");
            currentOptionIndex = 0;
            return;
        }
        if (index >= currentPanel.options.Length)
        {
            Debug.Log("̫����");
            currentOptionIndex = currentPanel.options.Length - 1;
            return;
        }
        if(currentOption != null)
        {
            currentOption.OnCancleChoose();
        }

        currentOption = currentPanel.options[currentOptionIndex];
        currentOption.OnChoose();

        Debug.Log("��ǰѡ��Ϊ��" + currentOption.name);
    }

    public void EnterOption()
    {
        if (currentOption == null) return;
        Debug.Log("Enter Option");
        currentOption.OnEnter();
    }
}

public enum ChooseState
{
    Selecting,
    Slide
}