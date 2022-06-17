using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;
    public LayerMask WhatIsGround;
    public bool isDead;
    public enum CurrentDirection
    {
        right,
        left
    }
    public CurrentDirection direction;
    void Start()
    {
        rb = GetComponent<Rigidbody>();   
    }
    private void FixedUpdate()
    {
        switch (direction)
        {
            case CurrentDirection.right:
                rb.velocity = new Vector3(-speed, 0, 0);
                break;
            case CurrentDirection.left:
                rb.velocity = new Vector3(0, 0, -speed);
                break;
            default:
                break;
        }
    }
    void Update()
    {
        if (IsFalling())
        {
            if (Input.GetMouseButtonDown(0)&& !EventSystem.current.IsPointerOverGameObject())
            {
                if (direction == CurrentDirection.right)
                {
                    direction = CurrentDirection.left;
                }
                else
                {
                    direction = CurrentDirection.right;
                }
            }
        }
        else
        {
            Time.timeScale = 0;
            isDead = true;
            speed = 0;
        }
        
    }
    IEnumerator Boost()
    {
        float a = speed;
        speed = Random.Range(3.5f,5);
        yield return new WaitForSeconds(2.5f);
        speed = a;

    }
    public bool IsFalling()
    {
        return Physics.Raycast(transform.position, new Vector3(0, -1.2f, 0), WhatIsGround, 90);
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x, transform.position.y-1.2f, transform.position.z));
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pill"))
        {
            StartCoroutine("Boost");
            Destroy(other.gameObject);
        }
    }
}
