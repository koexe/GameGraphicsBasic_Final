using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankPanel : MonoBehaviour
{
    public GameObject RankPrefab;
    private void OnEnable()
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        { 
            Destroy(gameObject.transform.GetChild(i).gameObject);        
        }
        for (int i = 0; i< ScoreMNG.Instance.ScoreList.Count;i++)
        {
            var info = ScoreMNG.Instance.ScoreList[i];
            GameObject Scoretemp = Instantiate(RankPrefab, gameObject.transform);
            Scoretemp.transform.GetComponent<RankCTR>().Init(info.m_sName,info.m_iRound,info.m_iMissedUnit,info.m_fTime);
        }
    }
}
