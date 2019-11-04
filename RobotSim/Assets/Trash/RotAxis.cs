using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class RotAxis : MonoBehaviour
{
    public GameObject Axis;
    private float SliderValue;
    private float ActualPosition;

    public Action<float> move;

    // Start is called before the first frame update
    void Start()
    {
        var Joint = Axis.GetComponent<ConfigurableJoint>();

        ActualPosition = gameObject.GetComponent<Slider>().value;
        SliderValue = ActualPosition;


        if(Joint.angularXMotion == ConfigurableJointMotion.Free)
        {
            move = (Angle) => 
            {
                if (ActualPosition < Angle + 1 && ActualPosition > Angle - 1)
                {

                }
                else if (ActualPosition < Angle)
                {
                    ActualPosition += 1;
                    Axis.transform.Rotate(-1, 0, 0);

                }
                else if (ActualPosition > Angle)
                {
                    ActualPosition -= 1;
                    Axis.transform.Rotate(1, 0, 0);
                }
            };
        }
        else if(Joint.angularYMotion == ConfigurableJointMotion.Free)
        {
            move = (Angle) =>
            {
                if (ActualPosition < Angle + 1 && ActualPosition > Angle - 1)
                {

                }
                else if (ActualPosition < Angle)
                {
                    ActualPosition += 1;
                    Axis.transform.Rotate(0, -1, 0);

                }
                else if (ActualPosition > Angle)
                {
                    ActualPosition -= 1;
                    Axis.transform.Rotate(0, 1, 0);
                }
            };
        }
        else if(Joint.angularZMotion == ConfigurableJointMotion.Free)
        {
            move = (Angle) =>
            {
                if (ActualPosition < Angle + 1 && ActualPosition > Angle - 1)
                {

                }
                else if (ActualPosition < Angle)
                {
                    ActualPosition += 1;
                    Axis.transform.Rotate(0, 0, -1);

                }
                else if (ActualPosition > Angle)
                {
                    ActualPosition -= 1;
                    Axis.transform.Rotate(0, 0, 1);
                }
            };
        }

    }

    // Update is called once per frame
    void Update()
    {
        move(SliderValue);
        //Debug.Log(SliderValue);
    }

     public void AddSlid(float newSliderValue)
    {
        SliderValue = newSliderValue;
    }

}
