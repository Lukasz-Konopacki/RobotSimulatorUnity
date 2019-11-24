using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Mathf;

public class CalcXYZ : MonoBehaviour
{

    private float d1, d2, d3, d4, d5, d6;
    private GameObject[] Arms = new GameObject[6];
    private GameObject Effector;

    public float q1, q2, q3, q4, q5, q6;
    public float x, y, z;
    public float nx, ny, nz, mx, my, mz, lx, ly, lz;
    public float nx1, ny1, nz1, mx1, my1, mz1, lx1, ly1, lz1;


    void Start()
    {
        d1 = 0.33f;
        d2 = 0.075f;
        d3 = 0.3f;
        d4 = 0.075f;
        d5 = 0.32f;
        d6 = 0.08f;

        Arms[0] = GameObject.Find("Slider Axis 1");
        Arms[1] = GameObject.Find("Slider Axis 2");
        Arms[2] = GameObject.Find("Slider Axis 3");
        Arms[3] = GameObject.Find("Slider Axis 4");
        Arms[4] = GameObject.Find("Slider Axis 5");
        Arms[5] = GameObject.Find("Slider Axis 6");

        Effector = GameObject.Find("LR Mate-200iC Part 6");
    }

    // Update is called once per frame
    void Update()
    {
        q1 = Arms[0].GetComponent<Slider>().value * Deg2Rad;
        q2 = Arms[1].GetComponent<Slider>().value * Deg2Rad;
        q3 = Arms[2].GetComponent<Slider>().value * Deg2Rad;
        q4 = Arms[3].GetComponent<Slider>().value * Deg2Rad;
        q5 = Arms[4].GetComponent<Slider>().value * Deg2Rad;
        q6 = Arms[5].GetComponent<Slider>().value * Deg2Rad;

        x = d6 * (Cos(q5) * (Cos(q2 + q3) * Cos(q1) * Cos(q2) + Sin(q2 + q3) * Cos(q1) * Sin(q2)) + Sin(q5) * (Cos(q4) * (Cos(q2 + q3) * Cos(q1) * Sin(q2) - Sin(q2 + q3) * Cos(q1) * Cos(q2)) - Sin(q1) * Sin(q4))) + d2 * Cos(q1) + d5 * (Cos(q2 + q3) * Cos(q1) * Cos(q2) + Sin(q2 + q3) * Cos(q1) * Sin(q2)) + d3 * Cos(q1) * Sin(q2) + d4 * Cos(q2 + q3) * Cos(q1) * Sin(q2) - d4 * Sin(q2 + q3) * Cos(q1) * Cos(q2);

        z = d6 * (Cos(q5) * (Cos(q2 + q3) * Cos(q2) * Sin(q1) + Sin(q2 + q3) * Sin(q1) * Sin(q2)) + Sin(q5) * (Cos(q1) * Sin(q4) + Cos(q4) * (Cos(q2 + q3) * Sin(q1) * Sin(q2) - Sin(q2 + q3) * Cos(q2) * Sin(q1)))) + d2 * Sin(q1) + d5 * (Cos(q2 + q3) * Cos(q2) * Sin(q1) + Sin(q2 + q3) * Sin(q1) * Sin(q2)) + d3 * Sin(q1) * Sin(q2) + d4 * Cos(q2 + q3) * Sin(q1) * Sin(q2) - d4 * Sin(q2 + q3) * Cos(q2) * Sin(q1);

        y = d1 + d3 * Cos(q2) - d6 * (Cos(q5) * (Cos(q2 + q3) * Sin(q2) - Sin(q2 + q3) * Cos(q2)) - Cos(q4) * Sin(q5) * (Cos(q2 + q3) * Cos(q2) + Sin(q2 + q3) * Sin(q2))) - d5 * (Cos(q2 + q3) * Sin(q2) - Sin(q2 + q3) * Cos(q2)) + d4 * Cos(q2 + q3) * Cos(q2) + d4 * Sin(q2 + q3) * Sin(q2);

        transform.position = Effector.transform.position;
        transform.rotation = Effector.transform.rotation;

        var qx = transform.rotation.x;
        var qy = transform.rotation.y;
        var qz = transform.rotation.z;
        var qw = transform.rotation.w;

        lx = Round(1000 * (qw * qw + qx * qx - qz * qz - qy * qy)) / 1000;
        nz = Round(1000 * (qy * qy - qz * qz + qw * qw - qx * qx)) / 1000;
        my = Round(1000 * (qz * qz - qy * qy - qx * qx + qw * qw)) / 1000;
        nx = Round(1000 * (-qz * qw + qy * qx - qw * qz + qx * qy))/ 1000;
        mx = Round(1000 * (qy * qw + qz * qx + qx * qz + qw * qy)) / 1000;
        lz = Round(1000 * (qx * qy + qw * qz + qz * qw + qy * qx)) / 1000;
        mz = Round(1000 * (qz * qy + qy * qz - qx * qw - qw * qx)) / 1000;
        ly = Round(1000 * (qx * qz - qw * qy + qz * qx - qy * qw)) / 1000;
        ny = Round(1000 * (qy * qz + qz * qy + qw * qx + qx * qw)) / 1000;

        lx1 = -Cos(q6) * (Sin(q5) * (Cos(q2 + q3) * Cos(q1) * Cos(q2) + Sin(q2 + q3) * Cos(q1) * Sin(q2)) - Cos(q5) * (Cos(q4) * (Cos(q2 + q3) * Cos(q1) * Sin(q2) - Sin(q2 + q3) * Cos(q1) * Cos(q2)) - Sin(q1) * Sin(q4))) - Sin(q6) * (Cos(q4) * Sin(q1) + Sin(q4) * (Cos(q2 + q3) * Cos(q1) * Sin(q2) - Sin(q2 + q3) * Cos(q1) * Cos(q2)));
        ly1 = Sin(q6) * (Cos(q1) * Cos(q4) - Sin(q4) * (Cos(q2 + q3) * Sin(q1) * Sin(q2) - Sin(q2 + q3) * Cos(q2) * Sin(q1))) - Cos(q6) * (Sin(q5) * (Cos(q2 + q3) * Cos(q2) * Sin(q1) + Sin(q2 + q3) * Sin(q1) * Sin(q2)) - Cos(q5) * (Cos(q1) * Sin(q4) + Cos(q4) * (Cos(q2 + q3) * Sin(q1) * Sin(q2) - Sin(q2 + q3) * Cos(q2) * Sin(q1))));
        lz1 = Cos(q6) * (Sin(q5) * (Cos(q2 + q3) * Sin(q2) - Sin(q2 + q3) * Cos(q2)) + Cos(q4) * Cos(q5) * (Cos(q2 + q3) * Cos(q2) + Sin(q2 + q3) * Sin(q2))) - Sin(q4) * Sin(q6) * (Cos(q2 + q3) * Cos(q2) + Sin(q2 + q3) * Sin(q2));
        mx1 = Sin(q6) * (Sin(q5) * (Cos(q2 + q3) * Cos(q1) * Cos(q2) + Sin(q2 + q3) * Cos(q1) * Sin(q2)) - Cos(q5) * (Cos(q4) * (Cos(q2 + q3) * Cos(q1) * Sin(q2) - Sin(q2 + q3) * Cos(q1) * Cos(q2)) - Sin(q1) * Sin(q4))) - Cos(q6) * (Cos(q4) * Sin(q1) + Sin(q4) * (Cos(q2 + q3) * Cos(q1) * Sin(q2) - Sin(q2 + q3) * Cos(q1) * Cos(q2)));
        my1 = Sin(q6) * (Sin(q5) * (Cos(q2 + q3) * Cos(q2) * Sin(q1) + Sin(q2 + q3) * Sin(q1) * Sin(q2)) - Cos(q5) * (Cos(q1) * Sin(q4) + Cos(q4) * (Cos(q2 + q3) * Sin(q1) * Sin(q2) - Sin(q2 + q3) * Cos(q2) * Sin(q1)))) + Cos(q6) * (Cos(q1) * Cos(q4) - Sin(q4) * (Cos(q2 + q3) * Sin(q1) * Sin(q2) - Sin(q2 + q3) * Cos(q2) * Sin(q1)));
        mz1 = -Sin(q6) * (Sin(q5) * (Cos(q2 + q3) * Sin(q2) - Sin(q2 + q3) * Cos(q2)) + Cos(q4) * Cos(q5) * (Cos(q2 + q3) * Cos(q2) + Sin(q2 + q3) * Sin(q2))) - Cos(q6) * Sin(q4) * (Cos(q2 + q3) * Cos(q2) + Sin(q2 + q3) * Sin(q2));
        nx1 = -Cos(q5) * (Cos(q2 + q3) * Cos(q1) * Cos(q2) + Sin(q2 + q3) * Cos(q1) * Sin(q2)) - Sin(q5) * (Cos(q4) * (Cos(q2 + q3) * Cos(q1) * Sin(q2) - Sin(q2 + q3) * Cos(q1) * Cos(q2)) - Sin(q1) * Sin(q4));
        ny1 = -Cos(q5) * (Cos(q2 + q3) * Cos(q2) * Sin(q1) + Sin(q2 + q3) * Sin(q1) * Sin(q2)) - Sin(q5) * (Cos(q1) * Sin(q4) + Cos(q4) * (Cos(q2 + q3) * Sin(q1) * Sin(q2) - Sin(q2 + q3) * Cos(q2) * Sin(q1)));
        nz1 = Cos(q5) * (Cos(q2 + q3) * Sin(q2) - Sin(q2 + q3) * Cos(q2)) - Cos(q4) * Sin(q5) * (Cos(q2 + q3) * Cos(q2) + Sin(q2 + q3) * Sin(q2));



    }
}
