using System.Collections;
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
    public Action move;

    // Start is called before the first frame update
    void Start()
    {
        switch(Axis)
        {
            case ChoseAxis.x:
                move = () =>
                {
                    print(gameObject.transform.rotation.eulerAngles.x);
                    gameObject.transform.Rotate(1, 0, 0);
                    System.Threading.Thread.Sleep(30);
                };
                break;
            case ChoseAxis.y:
                move = () =>
                {
                    print(gameObject.transform.rotation.eulerAngles.y);
                    gameObject.transform.Rotate(0, 1, 0);
                    System.Threading.Thread.Sleep(30);
                };
                break;
            case ChoseAxis.z:
                move = () =>
                {
                    print(gameObject.transform.rotation.eulerAngles.z);
                    gameObject.transform.Rotate(0, 0, 1);
                    System.Threading.Thread.Sleep(30);
                };
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }
}
