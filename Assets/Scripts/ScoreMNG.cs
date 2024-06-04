using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreMNG : MonoBehaviour
{
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
                return instance;
            }
            return instance;
        }
    }

    private void Awake()
    {
        instance = this;
    }
}
