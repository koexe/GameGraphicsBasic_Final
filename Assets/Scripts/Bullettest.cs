using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullettest : MonoBehaviour
{

    [SerializeField] private Rigidbody rb;
    private const float bulletSpeed = 300f;
    // Start is called before the first frame update
    void Start()
    {
        AddForce();

    }

    // Update is called once per frame
    void Update()
    {
        if(this.gameObject.transform.position.z > 0f)
        {
            Destroy(this.gameObject);
        }
    }

    public void AddForce()
    {
        rb.AddForce(Vector3.forward * bulletSpeed, ForceMode.Force);
    }
}
