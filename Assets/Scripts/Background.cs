using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
public class Background : MonoBehaviour
{
    public RectTransform[] BGs;
    public Image[] Nights;
    public float LeftBG;
    public float TimeToLoop = 1;

    private void Start()
    {
        LeftBG = BGs[1].anchoredPosition.x;
        LoopBG();
        SetWeather(true);
    }

    private void LoopBG()
    {
        BGs[1].DOAnchorPosX(-LeftBG, TimeToLoop).SetEase(Ease.Linear).SetLoops(-1, LoopType.Restart);
        BGs[0].DOAnchorPosX(-LeftBG, TimeToLoop / 2).SetEase(Ease.Linear).OnComplete(() =>
        {
            BGs[0].anchoredPosition = new Vector2(LeftBG, 0);
            BGs[0].DOAnchorPosX(-LeftBG, TimeToLoop).SetEase(Ease.Linear).SetLoops(-1, LoopType.Restart);
        });
    }

    public void SetWeather(bool isDay)
    {
        foreach (var night in Nights)
        {
            night.DOFade(isDay ? 0 : 1, 0.5f);
        }
    }
}
