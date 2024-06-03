using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEditor.Profiling;
using UnityEngine;

public class TreePrefab : MonoBehaviour
{
    
    private bool Walk_bool = true;
   
    public float Play_Time = 0.0f;
    public LevelManager levelManager;
    private float Enemy_Speed = 10f;

    // ���Ͱ� despawn �浹ó��
    void Start()
    {
        
        //Timer = null;
        //this.PlayTime();
        levelManager = FindObjectOfType<LevelManager>();
        int fTime = levelManager.Time;

        


    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("despawner"))
        {
            Destroy(gameObject);
        }
        
    }

    void Update()
    {

        if (Walk_bool == true)
        {
            Walk();
        }
        // PlayTime();


    }

    void Walk() // ���� �̵�
    {
        transform.Translate(Vector3.forward * -Enemy_Speed * Time.deltaTime);
    }

}
