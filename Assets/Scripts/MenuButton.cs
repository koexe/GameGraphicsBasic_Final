using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    public GameObject panel;
    public void StartButton()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void MenuButton_()
    {
        SceneManager.LoadScene("MenuScene");
    }
    public void ScoreButton()
    {
        panel.SetActive(true);
    }
    public void ScoreButton_Close()
    {
        panel.SetActive(false);
    }
}
