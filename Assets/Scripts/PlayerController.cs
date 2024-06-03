using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    public float speed = 10;
    public GameObject BulletPrefab;
    
    private void Start()
    {
        GameMNG.InputManager.MouseAction -= OnMouseInput;
        GameMNG.InputManager.MouseAction += OnMouseInput;
    }
    private void Update()
    {
        Instantiate(BulletPrefab);
    }
    void OnMouseInput()
    {
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
}
