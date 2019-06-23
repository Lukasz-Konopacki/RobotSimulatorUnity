﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RotAxis1 : MonoBehaviour
{
    public enum ChoseAxis
    {
        x,
        y,
        z
    }

    public ChoseAxis Axis;
    public Action<float> move;
    public float SliderValue;
    public float ActualPosition = 0;

    // Start is called before the first frame update
    void Start()
    {
        switch(Axis)
        {
            case ChoseAxis.x:
                move = (Angle) =>
                {
                    if (ActualPosition < Angle + 1 && ActualPosition > Angle - 1)
                    {

                    }
                    else if (ActualPosition < Angle)
                    {
                        ActualPosition += 1;
                        gameObject.transform.Rotate(1, 0, 0);

                    }
                    else if (ActualPosition > Angle)
                    {
                        ActualPosition -= 1;
                        gameObject.transform.Rotate(-1, 0, 0);
                    }
                };
                break;
            case ChoseAxis.y:
                move = (Angle) =>
                {
                    if (ActualPosition < Angle + 1 && ActualPosition > Angle - 1)
                    {

                    }
                    else if (ActualPosition < Angle)
                    {
                        ActualPosition += 1;
                        gameObject.transform.Rotate(0, 1, 0);

                    }
                    else if (ActualPosition > Angle)
                    {
                        ActualPosition -= 1;
                        gameObject.transform.Rotate(0, -1, 0);
                    }
                };
                break;
            case ChoseAxis.z:
                move = (Angle) =>
                {
                    if (ActualPosition < Angle + 1 && ActualPosition > Angle - 1)
                    {

                    }
                    else if (ActualPosition < Angle)
                    {
                        ActualPosition += 1;
                        gameObject.transform.Rotate(0, 0, 1);

                    }
                    else if (ActualPosition > Angle)
                    {
                        ActualPosition -= 1;
                        gameObject.transform.Rotate(0, 0, -1);
                    }
                };
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        move(SliderValue);
    }

     public void AddSlid(float newSliderValue)
    {
        SliderValue = newSliderValue;
    }

}
