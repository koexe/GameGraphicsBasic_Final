using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;
using System;
using System.Linq;

public class ScoreMNG : MonoBehaviour
{
    [Serializable]
    public class ScoreInfo
    {
        public string m_sName;
        public int m_iMissedUnit;
        public float m_fTime;
        public int m_iRound;
        public ScoreInfo(string name, int missed,int round, float time)
        {
            m_sName = name;
            m_iMissedUnit = missed;
            m_iRound = round;
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
            List<ScoreInfo> temp = ScoreList.OrderByDescending(x => x.m_iRound).ToList<ScoreInfo>();
            ScoreList = temp;
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
    public void AddList(int missed, int round, float time,  string name = "AAA")
    {
        ScoreInfo info_temp = new ScoreInfo(name, missed,round, time);
        ScoreList.Add(info_temp);
    }
}
