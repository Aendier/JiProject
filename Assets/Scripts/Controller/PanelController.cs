using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class PanelController : MonoBehaviour
{
    public static PanelController intstance;

    public Stack<BasePanel> previousPanel = new Stack<BasePanel>();
    public BasePanel currentPanel;

    public Vector2Int currentOptionIndex = new Vector2Int(0,0);
    public PanelOption currentOption;

    public RectTransform cursor;

    public ChooseState state;

    private void Awake()
    {
        intstance = this;
    }
    public void Init()
    {
        
    }
    private void Update()
    {
        switch (state)
        {
            case ChooseState.Selecting:
                if (Input.GetKeyDown(KeyCode.W) )
                {
                    Debug.Log("向上");
                    currentOptionIndex.y--;
                    ChooseOption(currentOptionIndex);
                }

                if (Input.GetKeyDown(KeyCode.S))
                {
                    Debug.Log("向下");
                    currentOptionIndex.y++;
                    ChooseOption(currentOptionIndex);

                }

                if (Input.GetKeyDown(KeyCode.A))
                {
                    Debug.Log("向左");
                    currentOptionIndex.x--;
                    ChooseOption(currentOptionIndex);


                }
                if (Input.GetKeyDown(KeyCode.D))
                {
                    Debug.Log("向右");
                    currentOptionIndex.x++;
                    ChooseOption(currentOptionIndex);                  
                }



                if (Input.GetKeyDown(KeyCode.Return))
                {
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

            case ChooseState.Scroll:
                if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.W))
                {
                    Debug.Log("下一个");
                    currentOptionIndex.y--;
                    ChooseOption(currentOptionIndex);
                    currentOption.transform.parent.GetComponent<RectTransform>().localPosition +=new Vector3(0,
                        - currentOption.transform.parent.GetComponent<RectTransform>().rect.height/ currentOption.transform.parent.childCount,
                        0);
                }

                if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
                {
                    Debug.Log("上一个");
                    currentOptionIndex.y++;
                    ChooseOption(currentOptionIndex);
                    currentOption.transform.parent.GetComponent<RectTransform>().localPosition += new Vector3(0,
                        currentOption.transform.parent.GetComponent<RectTransform>().rect.height / currentOption.transform.parent.childCount,
                        0);
                }

                if (Input.GetKeyDown(KeyCode.Return))
                {
                    EnterOption();
                }

                if (Input.GetKeyDown(KeyCode.R))
                {
                    state = ChooseState.Selecting;
                    ReturnPanel();
                }
                break;
        }
    }

    public void ReturnPanel()
    {
        if(previousPanel.Count > 1)
        {
            previousPanel.Pop();
            BasePanel panel = previousPanel.Peek();
            Debug.Log("返回面板" + panel);
            SetCurrentPanel(panel,true,false);
        }
        else
        {
            Debug.LogError("没有可以返回的面板");
        }
    }

    public void ReturnOption()
    {
        state = ChooseState.Selecting;
    }

    public void SetCurrentPanel(BasePanel panel,bool hideSelf = true,bool save = true)
    {
        if (currentOption != null) 
        {
            currentOption.OnCancelChoose();
        }
        
        //对当前面板的处理
        if(currentPanel != null)
        {
            currentPanel.defaultOptionIndex = currentOptionIndex;
            if (hideSelf)
            {
                currentPanel.HideMe(null);
            }
        }
        if (save)
        {
            previousPanel.Push(panel);
        }
        //对新面板的处理
        currentPanel = panel;
        panel.ShowMe();
        currentOptionIndex = panel.defaultOptionIndex;
        Debug.Log(currentOptionIndex.x+"11111" + currentOptionIndex.y);
        if(currentPanel.options.Length > 0)
        {
            ChooseOption(currentOptionIndex);

        }
        else
        {
            currentOption = null;
        }
    }

    public void ChooseOption(Vector2Int index)
    {
        Debug.Log("ChooseOption");
        Debug.Log(index.x+ "---" +index.y);
        if(currentOption != null)
        {
            currentOption.OnCancelChoose();
        }

        
        currentOption = currentPanel.ChooseOption(index);
        currentOption.OnChoose();

        Debug.Log("当前选项为：" + currentOption.name);
    }

    public void EnterOption()
    {
        if (currentOption == null) return;
        Debug.Log("Enter Option--"+currentOption.name);
        currentOption.OnEnter();
    }
}

public enum ChooseState
{
    Selecting,
    Slide,
    Scroll
}