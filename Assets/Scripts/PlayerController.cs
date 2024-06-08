using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    public float speed = 10;
    public BulletSpawn spawn;
    public Transform range;
    public int PlayerHP = 3;
    public GameObject[] HPs;
    [SerializeField] private CapsuleCollider m_PlayerCollider;
    [SerializeField] private Animator m_PlayerAnimator;

    private Coroutine m_crHit;
    private bool m_isDown = false;

    private void Start()
    {
        GameMNG.InputManager.MouseAction -= OnMouseInput;
        GameMNG.InputManager.MouseAction += OnMouseInput;
        GameMNG.InputManager.KeyAction -= OnKeyBoardInput;
        GameMNG.InputManager.KeyAction += OnKeyBoardInput;
        GameMNG.Instance.PlayerHitAction -= OnHit;
        GameMNG.Instance.PlayerHitAction += OnHit;


        //GameMNG.Instance.PlayerHitAction;
    }

    void OnMouseInput()
    {
        if (m_isDown)
            return;
        Vector3 mousePos = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        Vector3 playerPos = gameObject.transform.position;

        if (mousePos.x >= 0.5)
        {
            playerPos.x += speed * Time.deltaTime;
        }
        else
        {
            playerPos.x -= speed * Time.deltaTime;
        }
        playerPos.x = Mathf.Clamp(playerPos.x, -4.5f, 4.5f);
        gameObject.transform.position = playerPos;

    }

    void OnKeyBoardInput()
    {
        if (m_isDown)
            return;
        Vector3 playerPos = gameObject.transform.position;

        if (Input.GetKey(KeyCode.D))
        {
            playerPos.x += speed * Time.deltaTime;
        }
        else if(Input.GetKey(KeyCode.A))
        {
            playerPos.x -= speed * Time.deltaTime;
        }
        playerPos.x = Mathf.Clamp(playerPos.x, -4.5f, 4.5f);
        gameObject.transform.position = playerPos;
    }

    void OnHit()
    {
        
        PlayerHP -= 1;

        HPs[PlayerHP].SetActive(false);
        m_PlayerAnimator.SetTrigger("IsHit");
        if (m_crHit == null)
        {
            m_crHit = StartCoroutine(HitAfterCr());
        }
        if(PlayerHP == 0)
        {
            Time.timeScale = 0.0f;
            ScoreMNG.Instance.AddList(GameMNG.Instance.g_iMissed, GameMNG.Instance.g_iRound, GameMNG.Instance.g_fGameTime);
            ScoreMNG.Instance.SaveList();
            GameMNG.Instance.ShowGameOver();
        }
    }
    IEnumerator HitAfterCr()
    {
        m_isDown = true;
        m_PlayerCollider.enabled = false;
        yield return new WaitForSeconds(1.5f);
        m_PlayerCollider.enabled = true;
        m_isDown = false;
        m_crHit = null;

    }

    public void ResetInit()
    {
        GameMNG.InputManager.MouseAction -= OnMouseInput;
        GameMNG.InputManager.MouseAction += OnMouseInput;
        GameMNG.InputManager.KeyAction -= OnKeyBoardInput;
        GameMNG.InputManager.KeyAction += OnKeyBoardInput;
        GameMNG.Instance.PlayerHitAction -= OnHit;
        GameMNG.Instance.PlayerHitAction += OnHit;

        for(int i = 0; i < HPs.Length;i++)
            HPs[i].SetActive(true);
        PlayerHP = 3;
        spawn.ResetInit();
        range.transform.position = new Vector3(0f, 0.9f, 0f);
    }
    
}
