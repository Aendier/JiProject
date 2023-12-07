using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
/// <summary>
/// ����UI���ĸ��࣬����UI����״̬��Ϣ
/// </summary>
 public abstract class BasePanel:MonoBehaviour
{
    //������Ƶ��뵭���Ļ����� ���
    private CanvasGroup canvasGroup;
    //���뵭�����ٶ�
    private float alphaSpeed = 10;
    //�Ƿ�ʼ��ʾ
    private bool isShow;
    //���Լ������ɹ�ʱ Ҫִ�е�ί�к���
    private UnityAction hideCallBack;

    public PanelOption[] options;

    public int defaultOptionIndex = 0;
    
    protected virtual void Awake()
    {   //һ��ʼ��ȡ����� ���ص���� ���û�� ����ͨ������ Ϊ�����һ��
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
    /// ��Ҫ���� ��ʼ�� ��ť�¼������ȵ�����
    /// </summary>
    public abstract void Init();

    /// <summary>
    /// ��ʾ�Լ�ʱ ��������
    /// </summary>
    public virtual void ShowMe()
    {
        Debug.Log("Show---" + name);
        isShow = true;
        canvasGroup.alpha = 0;
    }
    /// <summary>
    /// �����Լ�ʱ ��������
    /// </summary>
    public virtual void HideMe(UnityAction callBack)
    {
        Debug.Log("Hide---" + name);
        isShow = false;
        canvasGroup.alpha = 1;
        //��¼����� �������ɹ����ִ�еĺ���
        hideCallBack = callBack;
    }
    // Update is called once per frame
    void Update()
    {    //����
        if (isShow && canvasGroup.alpha != 1)
        {
            canvasGroup.alpha += alphaSpeed * Time.deltaTime;
            if (canvasGroup.alpha >= 1)
            {
                canvasGroup.alpha = 1;
            }
        }
        //����
        else if (!isShow)
        {
            canvasGroup.alpha -= alphaSpeed * Time.deltaTime;
            if (canvasGroup.alpha >= 1)
            {
                canvasGroup.alpha = 0;
                //Ӧ���ù����� ɾ���Լ�
                hideCallBack?.Invoke();
            }
        }
    }
}
