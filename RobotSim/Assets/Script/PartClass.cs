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
        var Part3 = GameObject.Find("LR Mate-200iC Part 3").GetComponent<PartClass>();
        var Part2 = GameObject.Find("LR Mate-200iC Part 2").GetComponent<PartClass>();
        var value = Angle - Part2.RotValue;

        if(!(Part3.RotValue + value >= 185 || Part3.RotValue + value <= -72))
        {
            transform.Rotate(0, -value, 0);
            RotValue += value;
        }

        GameObject.Find("Slider Axis 3").GetComponent<Slider>().value = Part3.RotValue;
    }
}
