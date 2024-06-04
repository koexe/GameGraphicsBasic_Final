using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnerCTR : MonoBehaviour
{
    public string DespawnObject;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == DespawnObject)
        {
            Destroy(other.gameObject);
        }

    }
}
