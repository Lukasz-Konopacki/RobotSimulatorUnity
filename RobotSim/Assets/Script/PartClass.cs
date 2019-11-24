using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PartClass : MonoBehaviour
{
    public GameObject part;
    public float RotValue;


    private void Start()
    {
        part = gameObject;
        RotValue = 0f;
    }

    public void Rotate(float Angle)
    {
        var value = Angle - RotValue;

        transform.Rotate(0, -value, 0);
        
        RotValue += value;
    }

    public void RotatePart3bySlider2(float Angle)
    {
        var Part2 = GameObject.Find("LR Mate-200iC Part 2");

        var value = Angle - Part2.GetComponent<PartClass>().RotValue;

        transform.Rotate(0, -value, 0);
    }
}
