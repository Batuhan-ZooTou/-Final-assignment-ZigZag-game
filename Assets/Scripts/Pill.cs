using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pill : MonoBehaviour
{
    void Update()
    {
        transform.RotateAround(transform.position,Vector3.up,120*Time.deltaTime);
    }
    private void OnEnable()
    {
        transform.rotation = Quaternion.Euler(30,0,0);
    }
}
