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
        var value = (Angle - RotValue);

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


    public void RotatePart3()
    {

    }

}
