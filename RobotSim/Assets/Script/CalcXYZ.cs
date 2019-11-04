using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Mathf;

public class CalcXYZ : MonoBehaviour
{

    private float d0, d1, d2, d3, d4, d5;
    public float q1, q2, q3, q4, q5, q6;
    public float x, y, z;
    public GameObject[] Arms = new GameObject[6];
    public GameObject Effector;


    void Start()
    {
        d0 = 0.33f;
        d1 = 0.075f;
        d2 = 0.3f;
        d3 = 0.075f;
        d4 = 0.32f;
        d5 = 0.08f;

        Arms[0] = GameObject.Find("Slider Axis 1");
        Arms[1] = GameObject.Find("Slider Axis 2");
        Arms[2] = GameObject.Find("Slider Axis 3");
        Arms[3] = GameObject.Find("Slider Axis 4");
        Arms[4] = GameObject.Find("Slider Axis 5");
        Arms[5] = GameObject.Find("Slider Axis 6");

        Effector = GameObject.Find("LR Mate-200iC axis 6");
    }

    // Update is called once per frame
    void Update()
    {
        q1 = Arms[0].GetComponent<Slider>().value * 0.01745329252f;
        q2 = Arms[1].GetComponent<Slider>().value * 0.01745329252f;
        q3 = Arms[2].GetComponent<Slider>().value * -0.01745329252f;
        q4 = Arms[3].GetComponent<Slider>().value * -0.01745329252f;
        q5 = Arms[4].GetComponent<Slider>().value * -0.01745329252f;
        q6 = Arms[5].GetComponent<Slider>().value * 0.01745329252f;



        x = d5 * (Cos(q5) * (Cos(q2 + q3) * Cos(q1) * Cos(q2) + Sin(q2 + q3) * Cos(q1) * Sin(q2)) + Sin(q5) * (Cos(q4) * (Cos(q2 + q3) * Cos(q1) * Sin(q2) - Sin(q2 + q3) * Cos(q1) * Cos(q2)) - Sin(q1) * Sin(q4))) + d1 * Cos(q1) + d4 * (Cos(q2 + q3) * Cos(q1) * Cos(q2) + Sin(q2 + q3) * Cos(q1) * Sin(q2)) + d2 * Cos(q1) * Sin(q2) + d3 * Cos(q2 + q3) * Cos(q1) * Sin(q2) - d3 * Sin(q2 + q3) * Cos(q1) * Cos(q2);

        z = d5 * (Cos(q5) * (Cos(q2 + q3) * Cos(q2) * Sin(q1) + Sin(q2 + q3) * Sin(q1) * Sin(q2)) + Sin(q5) * (Cos(q1) * Sin(q4) + Cos(q4) * (Cos(q2 + q3) * Sin(q1) * Sin(q2) - Sin(q2 + q3) * Cos(q2) * Sin(q1)))) + d1 * Sin(q1) + d4 * (Cos(q2 + q3) * Cos(q2) * Sin(q1) + Sin(q2 + q3) * Sin(q1) * Sin(q2)) + d2 * Sin(q1) * Sin(q2) + d3 * Cos(q2 + q3) * Sin(q1) * Sin(q2) - d3 * Sin(q2 + q3) * Cos(q2) * Sin(q1);

        y = d2 * Cos(q2) - d5 * (Cos(q5) * (Cos(q2 + q3) * Sin(q2) - Sin(q2 + q3) * Cos(q2)) - Cos(q4) * Sin(q5) * (Cos(q2 + q3) * Cos(q2) + Sin(q2 + q3) * Sin(q2))) - d4 * (Cos(q2 + q3) * Sin(q2) - Sin(q2 + q3) * Cos(q2)) + d3 * Cos(q2 + q3) * Cos(q2) + d3 * Sin(q2 + q3) * Sin(q2) + d0;


        transform.position = Effector.transform.position;
    }
}
