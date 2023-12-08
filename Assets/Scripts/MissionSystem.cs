using System;
using System.IO;
using UnityEngine;

public class MissionSystem : MonoBehaviour
{
    public static MissionSystem instance;

    private bool isMissionStart;
    private int missionId;
    private float missionEndTime;
    string filePath;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        // 获取可执行文件所在目录
        string executablePath = Application.dataPath;

        // 构建保存文件的路径
        filePath = Path.Combine(executablePath, "MissionReport.txt");

        // 获取文件所在目录
        string directoryPath = Path.GetDirectoryName(filePath);

        // 如果目录不存在，创建目录
        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }
    }
    public void Update()
    {
        if (isMissionStart)
        {
            missionEndTime += Time.deltaTime;
        }
    }
    public void StartMission()
    {
        isMissionStart = true;
    }

    public void EndMission(string missionName)
    {
        isMissionStart = false;
        
        missionId = PlayerPrefs.GetInt("MissionId", 0);
        using (StreamWriter write = new StreamWriter(filePath,true))
        {
            write.WriteLine("[ID : " + missionId + "]" + "---" + "开始任务");
            write.WriteLine("[ID : " + missionId +"]" + "---" + ConvertFloatToTimeString(missionEndTime) + "---" + missionName);
        }
        
        missionEndTime = 0;
        PlayerPrefs.SetInt("MissionId", missionId + 1);
        PlayerPrefs.Save();
        UIManager.Instance.CloseAllPanel();
        PanelController.intstance.SetCurrentPanel(UIManager.Instance.ShowPanel<MenuPanel>());

    }


    static string ConvertFloatToTimeString(float timeInSeconds)
    {
        // 将浮点数转换为 TimeSpan 类型
        TimeSpan timeSpan = TimeSpan.FromSeconds(timeInSeconds);

        // 使用 ToString 格式化为 HH:mm:ss 格式
        string timeString = timeSpan.ToString(@"hh\:mm\:ss");

        return timeString;
    }
}
