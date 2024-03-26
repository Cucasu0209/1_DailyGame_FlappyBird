using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;
using DG.Tweening;
public class Bird : MonoBehaviour
{
    private Rigidbody2D body;
    public float JumpVeloc;
    public SpriteRenderer BirdRender;
    public bool IsDeath = false;
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
        if (IsDeath == false)
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

    }

    private void OnStartGame()
    {
        GetComponent<Collider2D>().isTrigger = false;
        body.gravityScale = 1.8f;
        IsDeath = false;

    }
    private void OnEndGame()
    {
        BirdRender.transform.eulerAngles = Vector3.zero;
        transform.position = Vector3.zero;
        body.velocity = Vector2.zero;
        body.gravityScale = 0;
        IsDeath = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        IsDeath = true;
        BirdRender.transform.DORotate(Vector3.forward * -90, 0.2f);
        GameController.Instance.OnBirdDeath();
        GetComponent<Collider2D>().isTrigger = true;
        DOVirtual.DelayedCall(3, () =>
        {
            Debug.Log(collision.gameObject.name);
            GameController.Instance.Gameover();
        });
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "CheckPoint")
            GameController.Instance.IncreaseScore();
    }
}
