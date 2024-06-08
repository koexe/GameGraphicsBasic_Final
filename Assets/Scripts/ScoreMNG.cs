using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;
using System;

public class ScoreMNG : MonoBehaviour
{
    [Serializable]
    public class ScoreInfo
    {
        string m_sName;
        int m_iMissedUnit;
        float m_fTime;
        public ScoreInfo(string name, int missed, float time)
        {
            m_sName = name;
            m_iMissedUnit = missed;
            m_fTime = time;
        }
    }
    public List<ScoreInfo> ScoreList;

    private static ScoreMNG instance;
    public static ScoreMNG Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject go = GameObject.Find("ScoreMNG");
                if (go == null)
                {
                    go = new GameObject { name = "ScoreMNG" };
                    go.AddComponent<ScoreMNG>();
                }
                instance = go.GetComponent<ScoreMNG>();
                DontDestroyOnLoad(go);
                return instance;
            }
            return instance;
        }
    }

    private void Awake()
    {
        ScoreList = new List<ScoreInfo>();
        instance = this;
        InitList();
    }

    public void InitList()
    {
        string path = Application.persistentDataPath + "Save.json";
        if (File.Exists(path))
        {
            string JsonDataTemp = File.ReadAllText(path);
            ScoreList = JsonConvert.DeserializeObject<List<ScoreInfo>>(JsonDataTemp);
        }
        else
        {
            Debug.Log("SaveMissed");
        }
    }
    public void SaveList()
    {
        if(ScoreList != null)
        {
            string path = Application.persistentDataPath + "Save.json";
            if (File.Exists(path))
                System.IO.File.Delete(path);
            string SaveData = JsonConvert.SerializeObject(ScoreList, Formatting.Indented);
            File.WriteAllText(path, SaveData);
            Debug.Log("Save Complete " + path);
        }
    }
    public void AddList(int missed, float time, string name = "AAA")
    {
        ScoreInfo info_temp = new ScoreInfo(name, missed, time);
        ScoreList.Add(info_temp);
    }
}
