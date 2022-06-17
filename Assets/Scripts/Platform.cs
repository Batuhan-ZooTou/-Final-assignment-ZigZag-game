using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    Vector3 moveTo;
    bool spawned;
    void Start()
    {
        
    }

    void Update()
    {
        if (spawned)
        {
            transform.position = Vector3.MoveTowards(transform.position, moveTo, 0.05f);

        }
    }
    private void OnEnable()
    {
        moveTo = new Vector3(transform.position.x, -3.919983f, transform.position.z);
        spawned = true;
    }
}
