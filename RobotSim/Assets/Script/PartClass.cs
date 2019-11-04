using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PartClass : MonoBehaviour
{
    public enum Axis { x, y, z };

    public GameObject part;
    public float RotValue;
    public Axis RotAxis;


    private void Start()
    {
        part = gameObject;
        RotValue = 0f;

        if (part.GetComponent<ConfigurableJoint>().angularXMotion == ConfigurableJointMotion.Free)
        {
            RotAxis = Axis.x;
        }
        else if (part.GetComponent<ConfigurableJoint>().angularYMotion == ConfigurableJointMotion.Free)
        {
            RotAxis = Axis.y;
        }
        else if (part.GetComponent<ConfigurableJoint>().angularZMotion == ConfigurableJointMotion.Free)
        {
            RotAxis = Axis.z;
        }

    }

    public void Rotate(float Angle)
    {
        var value = Angle - RotValue;

        if(RotAxis == Axis.x)
        {
            transform.Rotate(value, 0, 0);
        }
        else if (RotAxis == Axis.y)
        {
            transform.Rotate(0, value, 0);
        }
        else if (RotAxis == Axis.z)
        {
            transform.Rotate(0, 0, value);
        }
        
        RotValue += value;
    }

    public void RotatePart3bySlider2(float slider2)
    {
        var Part2 = GameObject.Find("LR Mate-200iC axis 2").GetComponent<PartClass>();
        var Slider3 = GameObject.Find("Slider Axis 3").GetComponent<Slider>();

        var value2 = slider2 - Part2.RotValue;
        
        if (Slider3.value + value2 < Slider3.maxValue && Slider3.value + value2 > Slider3.minValue)
        {
            transform.Rotate(0, 0, value2);

            RotValue += value2;
            Slider3.value = RotValue;
        }
    }
}
