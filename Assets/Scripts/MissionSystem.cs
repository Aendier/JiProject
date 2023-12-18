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
        // ��ȡ��ִ���ļ�����Ŀ¼
        string executablePath = Application.dataPath;

        // ���������ļ���·��
        filePath = Path.Combine(executablePath, "MissionReport.txt");

        // ��ȡ�ļ�����Ŀ¼
        string directoryPath = Path.GetDirectoryName(filePath);

        // ���Ŀ¼�����ڣ�����Ŀ¼
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
        missionId = PlayerPrefs.GetInt("MissionId", 0);
        using (StreamWriter write = new StreamWriter(filePath, true))
        {
            write.WriteLine("[ID : " + missionId + "]" + "---" + "��ʼ����");
        }
        }

    public void RecordMission(string missionName)
    {
        missionId = PlayerPrefs.GetInt("MissionId", 0);
        using (StreamWriter write = new StreamWriter(filePath,true))
        {
            write.WriteLine("[ID : " + missionId + "]" + "---" + ConvertFloatToTimeString(missionEndTime) + "---" + missionName);
        }

    }

    public void EndMission(string missionName)
    {
        isMissionStart = false;
        
        missionId = PlayerPrefs.GetInt("MissionId", 0);
        using (StreamWriter write = new StreamWriter(filePath,true))
        {
            write.WriteLine("[ID : " + missionId +"]" + "---" + ConvertFloatToTimeString(missionEndTime) + "---" + missionName);
            write.WriteLine("[ID : " + missionId + "]" + "---" + "��������");
            write.WriteLine();
        }
        
        missionEndTime = 0;
        PlayerPrefs.SetInt("MissionId", missionId + 1);
        PlayerPrefs.Save();
        UIManager.Instance.CloseAllPanel();
        PanelController.intstance.SetCurrentPanel(UIManager.Instance.ShowPanel<MenuPanel>());

    }


    static string ConvertFloatToTimeString(float timeInSeconds)
    {
        // ��������ת��Ϊ TimeSpan ����
        TimeSpan timeSpan = TimeSpan.FromSeconds(timeInSeconds);

        // ʹ�� ToString ��ʽ��Ϊ HH:mm:ss.fff ��ʽ
        string timeString = timeSpan.ToString(@"hh\:mm\:ss\.fff");

        return timeString;
    }
}
