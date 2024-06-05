using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMNG : MonoBehaviour
{
    public enum GameState {Pause, InProgress}
    public GameState g_GameState;
    public float g_fGameTime = 0;
    public GameObject ButtonPrefab;
    private LevelManager g_LvlMng;
    private PlayerController g_PlayerCTR;
    private static GameMNG instance;

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

}
