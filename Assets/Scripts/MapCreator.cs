using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEditor;
public class MapCreator : MonoBehaviour
{
    public Tube BaseTube;
    public Transform StartSpawnTub;
    public float TimeSpawnTube;
    public float TimeTubExist;

    private float LastHight = 1;
    IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSeconds(TimeSpawnTube);
            Tube tube = Instantiate(BaseTube, StartSpawnTub);
            LastHight = Mathf.Clamp(Random.Range(LastHight - 0.5f, LastHight + 0.5f), -1, 3);
            tube.transform.localPosition = Vector3.up * LastHight;
            tube.SetMeasurementSpace(2);
            tube.transform.DOMoveX(-StartSpawnTub.position.x, TimeTubExist).SetEase(Ease.Linear).OnComplete(() =>
            {
                Destroy(tube.gameObject);
            });
        }
    }



}
