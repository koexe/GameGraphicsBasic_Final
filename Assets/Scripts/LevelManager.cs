using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class LevelManager : MonoBehaviour
{
    public int killCount = 0;
    public int Time = 0;
    public List<GameObject> li_Prefab;

    private Coroutine co_Timer;
    public GameObject prefabObj;
    public GameObject prefabTree;
    public TextMeshProUGUI KillText;

    // Start is called before the first frame update
    void Start()
    {
        co_Timer = null;
        this.TimeCheck();
        InvokeRepeating("InvokePrefab", 1f, 3f);
        this.li_Prefab = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CancelInvoke("InvokePrefab");
        }
        
    }
    
    private void GeneratePrefab()
    {
        GameObject gmobjTemp;
        GameObject gmobjTree01;
        GameObject gmobjTree02;

        gmobjTemp = Instantiate(this.prefabObj, new Vector3(Random.Range(-4, 4), 2f, 30f), Quaternion.identity);
        gmobjTree01 = Instantiate(this.prefabTree, new Vector3(-5f, 0f, 50f), Quaternion.identity);
        gmobjTree02 = Instantiate(this.prefabTree, new Vector3(5f, 0, 50), Quaternion.identity);
        this.li_Prefab.Add(gmobjTemp);
    }

    void InvokePrefab()
    {
        GeneratePrefab();
    }

    private void TimeCheck()
    {
        if(co_Timer!= null) StopCoroutine(co_Timer);
        co_Timer = StartCoroutine(Timer());
    }

    IEnumerator Timer()
    {
        yield return null;
        while (true)
        {
            yield return new WaitForSeconds(1);
            Time += 1;
        }
    }
    public void KillCheck()
    {
        killCount += 1;
        KillText.text = "Kill: " + killCount;
    }

}
