using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor;
public class GameController : MonoBehaviour
{
    public static GameController Instance;
    private int Score;
    public bool IsGameRuning = false;
    private void Awake()
    {
        Instance = this;
        Score = 0;
    }
    IEnumerator Start()
    {
        yield return null;
        OnUpdateScore?.Invoke(Score);

    }

    public Action<int> OnUpdateScore;
    public Action OnStartGame;
    public Action OnGameOver;
    public Action OnBirdDeath;

    public void IncreaseScore()
    {
        Score += 1;
        OnUpdateScore?.Invoke(Score);
    }
   public void StartNewGame()
    {
        IsGameRuning = true;
        Score = 0;
        OnUpdateScore?.Invoke(Score);
        OnStartGame?.Invoke();
    }

    public void Gameover()
    {
        IsGameRuning = false;
        OnGameOver?.Invoke();
    }
}
