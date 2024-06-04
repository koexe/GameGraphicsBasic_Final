using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEditor.Profiling;
using UnityEngine;

public class TreePrefab : MonoBehaviour
{
    
    private bool Walk_bool = true;
    private float Enemy_Speed = 10f;
    void Update()
    {
        if (Walk_bool == true)
        {
            transform.Translate(Vector3.forward * -Enemy_Speed * Time.deltaTime);
        }
    }
}
