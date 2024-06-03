using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawn : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("InvokePrefab", 1f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CancelInvoke("InvokePrefab");
        }
    }

    void BulletGenerate()
    {
        Instantiate(this.bulletPrefab, this.transform.position, Quaternion.identity);
    }
    void InvokePrefab()
    {
        BulletGenerate();
    }
}
