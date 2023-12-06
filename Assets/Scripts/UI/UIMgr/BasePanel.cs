using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
/// <summary>
/// 所有UI面板的父类，包括UI面板的状态信息
/// </summary>
 public abstract class BasePanel:MonoBehaviour
{
    //整体控制淡入淡出的画布组 组件
    private CanvasGroup canvasGroup;
    //淡入淡出的速度
    private float alphaSpeed = 10;
    //是否开始显示
    private bool isShow;
    //当自己淡出成功时 要执行的委托函数
    private UnityAction hideCallBack;

    public PanelOption[] options;

    public int defaultOptionIndex = 0;
    
    protected virtual void Awake()
    {   //一开始获取面板上 挂载的组件 如果没有 我们通过代码 为它添加一个
        canvasGroup = this.GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            canvasGroup = this.gameObject.AddComponent<CanvasGroup>();
        }

        options = GetComponentsInChildren<PanelOption>();
        if (defaultOptionIndex <0 || defaultOptionIndex >= options.Length)
        {
            defaultOptionIndex = 0;
        }
    }
    // Start is called before the first frame update
    protected virtual void Start()
    {
        Init();
    }

    /// <summary>   
    /// 主要用于 初始化 按钮事件监听等等内容
    /// </summary>
    public abstract void Init();

    /// <summary>
    /// 显示自己时 做的事情
    /// </summary>
    public virtual void ShowMe()
    {
        Debug.Log("Show---" + name);
        isShow = true;
        PanelController.intstance.SetCurrentPanel(this);
        PanelController.intstance.ChooseOption(0);   
        canvasGroup.alpha = 0;
    }
    /// <summary>
    /// 隐藏自己时 做的事情
    /// </summary>
    public virtual void HideMe(UnityAction callBack)
    {
        Debug.Log("Hide---" + name);
        isShow = false;
        canvasGroup.alpha = 1;
        //记录传入的 当淡出成功后会执行的函数
        hideCallBack = callBack;
    }
    // Update is called once per frame
    void Update()
    {    //淡入
        if (isShow && canvasGroup.alpha != 1)
        {
            canvasGroup.alpha += alphaSpeed * Time.deltaTime;
            if (canvasGroup.alpha >= 1)
            {
                canvasGroup.alpha = 1;
            }
        }
        //淡出
        else if (!isShow)
        {
            canvasGroup.alpha -= alphaSpeed * Time.deltaTime;
            if (canvasGroup.alpha >= 1)
            {
                canvasGroup.alpha = 0;
                //应该让管理器 删除自己
                hideCallBack?.Invoke();
            }
        }
    }
}
