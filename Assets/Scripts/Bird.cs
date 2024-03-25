using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    private Rigidbody2D body;
    public float JumpVeloc;
    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            body.velocity = Vector3.up * JumpVeloc;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            body.velocity = Vector3.up * JumpVeloc;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Die");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameController.Instance.IncreaseScore();
    }
}
