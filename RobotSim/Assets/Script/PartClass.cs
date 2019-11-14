using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PartClass : MonoBehaviour
{
    public enum Axis { x, y, z };

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

        if(part.GetComponent<ConfigurableJoint>().angularXMotion == ConfigurableJointMotion.Free)
        {
            transform.Rotate(value, 0, 0);
        }
        else if (part.GetComponent<ConfigurableJoint>().angularYMotion == ConfigurableJointMotion.Free)
        {
            transform.Rotate(0, -value, 0);
        }
        else if (part.GetComponent<ConfigurableJoint>().angularZMotion == ConfigurableJointMotion.Free)
        {
            transform.Rotate(0, 0, value);   
        }
        
        RotValue += value;
    }

    public void RotatePart3bySlider2(float Angle)
    {

        var Part2 = GameObject.Find("LR Mate-200iC axis 2").GetComponent<PartClass>();

        var RotValue = Angle - Part2.RotValue;
        
        transform.Rotate(0, 0, RotValue);
    }
}
