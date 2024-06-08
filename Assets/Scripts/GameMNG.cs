using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameMNG : MonoBehaviour
{
    public enum GameState {Pause, InProgress}
    public GameState g_GameState;
    public float g_fGameTime = 0;
    public int g_iMissed = 0;
    public int g_iRound = 0;
    public GameObject ButtonPrefab;
    public GameObject GameOver;
    private LevelManager g_LvlMng;
    private PlayerController g_PlayerCTR;
    private static GameMNG instance;
    public Action PlayerHitAction;

    public int g_iMissedUnits = 0;
    public int g_iRound = 0;

    public static GameMNG Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject go = GameObject.Find("@Managers");
                if (go == null)
                {
                    go = new GameObject { name = "@Managers" };
                    go.AddComponent<GameMNG>();
                }
                instance = go.GetComponent<GameMNG>();
                return instance;
            }
            return instance;
        }
    }

    InputManager _input = new InputManager();
    public static InputManager InputManager
    {
        get
        { return Instance._input; }
    }

    private void Update()
    {
        if(g_GameState == GameState.InProgress)
        {
            _input.OnUpdate();
            g_fGameTime += Time.deltaTime;
        }

    }
    public LevelManager getLvlMNG()
    {
        if (g_LvlMng == null)
            g_LvlMng = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        return g_LvlMng;
    }
    public PlayerController getPlayerCTR()
    {
        if (g_PlayerCTR == null)
            g_PlayerCTR = GameObject.Find("Player").GetComponent<PlayerController>();
        return g_PlayerCTR;
    }


    public void ShowSelectButton()
    {
        Time.timeScale = 0.0f;
        for (int i = 0; i < 3; i++) 
        {
            int RandomStat = Random.Range(0, 5);
            GameObject Button_Temp = Instantiate(ButtonPrefab,GameObject.Find("Canvas").transform);
            Button_Temp.GetComponent<SelectStatButton>().m_Stats = (Define.Stats)RandomStat;
            Button_Temp.GetComponent<SelectStatButton>().Init();
            Button_Temp.GetComponent<RectTransform>().localPosition = new Vector2((i - 1) * 350 , 0);
        }
    }

    public void SaveGameInfo()
    {
        ScoreMNG.Instance.AddList(g_iMissed, g_fGameTime);
        ScoreMNG.Instance.SaveList();
    public void ResetStage()
    {
        g_PlayerCTR.ResetInit();
        GameObject[] enemys = GameObject.FindGameObjectsWithTag("Monster");
        GameObject[] bullets = GameObject.FindGameObjectsWithTag("Bullet");

        for (int i = 0; i < enemys.Length; i++)
        {
            Destroy(enemys[i]);
        }
        for (int i = 0;i < bullets.Length; i++) { Destroy(bullets[i]); }
        g_PlayerCTR.transform.position = new Vector3(0, 0, -16);

        g_fGameTime = 0.0f;
        Time.timeScale = 1.0f;
        g_iRound = 0;
        GameOver.SetActive(false);
    }

    public void ShowGameOver()
    {
        GameOver.SetActive(true);
    }

}
