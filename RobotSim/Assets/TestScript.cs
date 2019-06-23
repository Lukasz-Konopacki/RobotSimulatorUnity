using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    public enum ChoseAxis
    {
        x,
        y,
        z
    }
    public Vector3 CurrentRotation;
    public ChoseAxis Axis;
    public Action<float> move;
    public float Slid;
    public float ActualPosition = 0;

    void Start()
    {
        switch (Axis)
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
                    //print(gameObject.transform.rotation.eulerAngles.x);
                    //gameObject.transform.Rotate(1, 0, 0);
                    //System.Threading.Thread.Sleep(30);
                };
                break;
            case ChoseAxis.y:
                move = (Angle) =>
                {
                    if (transform.rotation.eulerAngles.y < Angle + 1 && transform.rotation.eulerAngles.y > Angle - 1)
                    {

                    }
                    else if (transform.rotation.eulerAngles.y < Angle)
                    {
                        gameObject.transform.Rotate(0, 1, 0);
                    }
                    else if (transform.rotation.eulerAngles.y > Angle)
                    {
                        gameObject.transform.Rotate(0, -1, 0);
                    }
                    //print(gameObject.transform.rotation.eulerAngles.y);
                    // gameObject.transform.Rotate(0, 1, 0);
                    // System.Threading.Thread.Sleep(30);
                };
                break;
            case ChoseAxis.z:
                move = (Angle) =>
                {
                    if (transform.rotation.eulerAngles.z < Angle + 1 && transform.rotation.eulerAngles.z > Angle - 1)
                    {

                    }
                    else if (transform.rotation.eulerAngles.z < Angle)
                    {
                        gameObject.transform.Rotate(0, 0, 1);
                    }
                    else if (transform.rotation.eulerAngles.z > Angle)
                    {
                        gameObject.transform.Rotate(0, 0, -1);
                    }
                    //print(gameObject.transform.rotation.eulerAngles.z);
                    //gameObject.transform.Rotate(0, 0, 1);
                    //System.Threading.Thread.Sleep(30);
                };
                break;
        }
    }

    void Update()
    {
        move(Slid);
    }

    public void AddSlid(float newSlid)
    {
        Slid = newSlid;
    }

}
