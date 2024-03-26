using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Bird : MonoBehaviour
{
    private Rigidbody2D body;
    public float JumpVeloc;
    public SpriteRenderer BirdRender;

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
        OnEndGame();
        GameController.Instance.OnStartGame += OnStartGame;
        GameController.Instance.OnGameOver += OnEndGame;
    }
    private void OnDestroy()
    {
        GameController.Instance.OnStartGame -= OnStartGame;
        GameController.Instance.OnGameOver -= OnEndGame;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            body.velocity = Vector3.up * JumpVeloc;
            if (GameController.Instance.IsGameRuning == false)
            {
                GameController.Instance.StartNewGame();
            }
        }
        BirdRender.transform.eulerAngles = new Vector3(0, 0, body.velocity.y / 6f * 45f);
    }

    private void OnStartGame()
    {
        body.gravityScale = 1.8f;

    }
    private void OnEndGame()
    {
        transform.position = Vector3.zero;
        body.velocity = Vector2.zero;
        body.gravityScale = 0;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameController.Instance.Gameover();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameController.Instance.IncreaseScore();
    }
}
