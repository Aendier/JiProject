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
            EnterOption();
        }
    }

    public void SetCurrentPanel(BasePanel panel)
    {
        currentPanel = panel;
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
        currentOption.OnCancleChoose();
        currentOption = currentPanel.options[index];
        currentOption.OnChoose();
        //设置光标的位置为当前选项位置的最右侧
        //cursor.rect.Set(currentPanel.options[index].transform.position.x + currentPanel.options[index].transform.localScale.x / 2, currentPanel.options[index].transform.position.y, 0, 0);

        Debug.Log("当前选项为：" + currentOption.name);
    }

    public void EnterOption()
    {
        currentOption.OnEnter();
    }
}
