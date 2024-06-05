using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SelectStatButton : MonoBehaviour
{
    public Define.Stats m_Stats;
    public TextMeshProUGUI m_ExplainText;
    public Button m_Button;
     public void Init()
    {
        switch (m_Stats)
        {
            case Define.Stats.AttackDamage:
                int stateAmount_1 = Random.Range(0, 10);
                m_ExplainText.text = "공격력" + stateAmount_1;
                m_Button.onClick.AddListener(() => Damage(stateAmount_1));
                
                break;
            case Define.Stats.AttackSpeed:
                float stateAmount_2 = Mathf.Floor(Random.Range(0, 20.0f) * 10)/10;
                m_ExplainText.text = "발사체 속도" + stateAmount_2;
                m_Button.onClick.AddListener(() => AttackSpeed(stateAmount_2));
                break;
            case Define.Stats.AttackRange:
                int stateAmount_3 = Random.Range(0, 3);
                m_ExplainText.text = "공격 사거리" + stateAmount_3;
                m_Button.onClick.AddListener(() => Range(stateAmount_3));
                break;
            case Define.Stats.AttackAmount:
                m_ExplainText.text = "발사체 수";
                m_Button.onClick.AddListener(() => AttackAmount());
                break;
            case Define.Stats.AttackRate:
                float stateAmount_5 = Mathf.Floor(Random.Range(0, 20.0f) * 10) / 10;
                m_ExplainText.text = "공격속도" + stateAmount_5;
                m_Button.onClick.AddListener(() => AttackRate(stateAmount_5));
                break;
        }
    }


    void Damage(int amount)
    {
        Debug.Log("DamageButton");
        GameMNG.Instance.getPlayerCTR().spawn.m_iAttackDamage += amount;
        GameObject[] findobjs = GameObject.FindGameObjectsWithTag("Button");
        for (int i = 0; i < findobjs.Length; i++)
        {
            Destroy(findobjs[i]);
        }
        Time.timeScale = 1.0f;
    }
    void AttackSpeed(float amount)
    {
        Debug.Log("AttackSpeedButton");
        GameMNG.Instance.getPlayerCTR().spawn.m_BulletSpeed += amount;
        GameObject[] findobjs = GameObject.FindGameObjectsWithTag("Button");
        for (int i = 0; i < findobjs.Length; i++)
        {
            Destroy(findobjs[i]);
        }
        Time.timeScale = 1.0f;
    }
    void Range(int amount)
    {
        Debug.Log("Rane");
        GameMNG.Instance.getPlayerCTR().spawn.m_AttackRange += amount;
        GameObject[] findobjs = GameObject.FindGameObjectsWithTag("Button");
        for (int i = 0; i < findobjs.Length; i++)
        {
            Destroy(findobjs[i]);
        }
        Time.timeScale = 1.0f;
    }
    void AttackAmount()
    {
        Debug.Log("DamageButton");
        GameMNG.Instance.getPlayerCTR().spawn.m_iAttackAmount += 1;
        GameObject[] findobjs = GameObject.FindGameObjectsWithTag("Button");
        for (int i = 0; i < findobjs.Length; i++)
        {
            Destroy(findobjs[i]);
        }
        Time.timeScale = 1.0f;
    }
    void AttackRate(float amount)
    {
        Debug.Log("DamageButton");
        GameMNG.Instance.getPlayerCTR().spawn.m_fAttackRate -= GameMNG.Instance.getPlayerCTR().spawn.m_fAttackRate/(20 - amount);
        GameObject[] findobjs = GameObject.FindGameObjectsWithTag("Button");
        for (int i = 0; i < findobjs.Length; i++)
        {
            Destroy(findobjs[i]);
        }
        Time.timeScale = 1.0f;
    }
}
