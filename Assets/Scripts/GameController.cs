using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class GameController : MonoBehaviour
{
    public static GameController Instance;
    private int Score;
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

    public void IncreaseScore()
    {
        Score += 1;
        OnUpdateScore?.Invoke(Score);
    }
}
