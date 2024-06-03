using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMNG : MonoBehaviour
{
    public enum GameState {Pause, InProgress}
    public GameState g_GameState;
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

                DontDestroyOnLoad(go);

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
            _input.OnUpdate();
    }
}
