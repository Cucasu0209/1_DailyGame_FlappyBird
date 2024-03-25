using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Tube : MonoBehaviour
{
    public Transform TubAbove;
    public Transform TubBelow;
    public void SetMeasurementSpace(float value)
    {
        TubAbove.transform.localPosition=Vector2.up*value/2;
        TubBelow.transform.localPosition=Vector2.down*value/2;
    }
}
