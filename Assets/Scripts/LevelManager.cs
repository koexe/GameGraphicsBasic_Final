using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public int Time = 0;
    public List<GameObject> li_Prefab;
    private Coroutine co_Timer;
    public GameObject prefabObj;

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
        
        gmobjTemp = Instantiate(this.prefabObj, new Vector3(Random.Range(-4, 4), 2f, 30f), Quaternion.identity);
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


}
