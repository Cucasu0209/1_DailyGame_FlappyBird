using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreBoard : MonoBehaviour
{
    public List<Sprite> numbers;
    public Image Render1;
    public Image Render2;
    public Image Render3;

    private void Start()
    {
        GameController.Instance.OnUpdateScore += RenderScore;
    }
    private void OnDestroy()
    {
        GameController.Instance.OnUpdateScore -= RenderScore;
    }
    private void RenderScore(int Score)
    {
        if (Score < 10)
        {
            Render2.gameObject.SetActive(false);
            Render3.gameObject.SetActive(false);
            Render1.sprite = numbers[Score];
        }
        else if (Score < 100)
        {
            Render2.gameObject.SetActive(true);
            Render3.gameObject.SetActive(false);
            Render2.sprite = numbers[Score % 10];
            Render1.sprite = numbers[Score / 10];
        }
        else if (Score < 1000)
        {
            Render2.gameObject.SetActive(true);
            Render3.gameObject.SetActive(true);
            Render3.sprite = numbers[Score % 10];
            Render2.sprite = numbers[(Score % 100) / 10];
            Render1.sprite = numbers[Score / 100];
        }
    }
}
