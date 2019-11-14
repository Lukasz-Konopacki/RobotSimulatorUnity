using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Mathf;

public class CalcRot : MonoBehaviour
{

    public float lx, ly, lz, mx, my, mz, nx, ny, nz;
    public float lx1, ly1, lz1, mx1, my1, mz1, nx1, ny1, nz1;
    private GameObject[] Arms = new GameObject[6];
    public float q1, q2, q3, q4, q5, q6;
    public float q1new;

    // Start is called before the first frame update
    void Start()
    {
        Arms[0] = GameObject.Find("Slider Axis 1");
        Arms[1] = GameObject.Find("Slider Axis 2");
        Arms[2] = GameObject.Find("Slider Axis 3");
        Arms[3] = GameObject.Find("Slider Axis 4");
        Arms[4] = GameObject.Find("Slider Axis 5");
        Arms[5] = GameObject.Find("Slider Axis 6");
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

        lx = -Cos(q6) * (Sin(q5) * (Cos(q2 + q3) * Cos(q1) * Cos(q2) - Sin(q2 + q3) * Cos(q1) * Sin(q2)) + Cos(q5) * (Cos(q4) * (Cos(q2 + q3) * Cos(q1) * Sin(q2) + Sin(q2 + q3) * Cos(q1) * Cos(q2)) + Sin(q1) * Sin(q4))) - Sin(q6) * (Cos(q4) * Sin(q1) - Sin(q4) * (Cos(q2 + q3) * Cos(q1) * Sin(q2) + Sin(q2 + q3) * Cos(q1) * Cos(q2)));

        ly = Cos(q6) * (Cos(q4) * Sin(q1) - Sin(q4) * (Cos(q2 + q3) * Cos(q1) * Sin(q2) + Sin(q2 + q3) * Cos(q1) * Cos(q2))) - Sin(q6) * (Sin(q5) * (Cos(q2 + q3) * Cos(q1) * Cos(q2) - Sin(q2 + q3) * Cos(q1) * Sin(q2)) + Cos(q5) * (Cos(q4) * (Cos(q2 + q3) * Cos(q1) * Sin(q2) + Sin(q2 + q3) * Cos(q1) * Cos(q2)) + Sin(q1) * Sin(q4)));

        lz = Cos(q5) * (Cos(q2 + q3) * Cos(q1) * Cos(q2) - Sin(q2 + q3) * Cos(q1) * Sin(q2)) - Sin(q5) * (Cos(q4) * (Cos(q2 + q3) * Cos(q1) * Sin(q2) + Sin(q2 + q3) * Cos(q1) * Cos(q2)) + Sin(q1) * Sin(q4));

        mx = Sin(q6) * (Cos(q1) * Cos(q4) + Sin(q4) * (Cos(q2 + q3) * Sin(q1) * Sin(q2) + Sin(q2 + q3) * Cos(q2) * Sin(q1))) - Cos(q6) * (Sin(q5) * (Cos(q2 + q3) * Cos(q2) * Sin(q1) - Sin(q2 + q3) * Sin(q1) * Sin(q2)) - Cos(q5) * (Cos(q1) * Sin(q4) - Cos(q4) * (Cos(q2 + q3) * Sin(q1) * Sin(q2) + Sin(q2 + q3) * Cos(q2) * Sin(q1))));

        my = -Sin(q6) * (Sin(q5) * (Cos(q2 + q3) * Cos(q2) * Sin(q1) - Sin(q2 + q3) * Sin(q1) * Sin(q2)) - Cos(q5) * (Cos(q1) * Sin(q4) - Cos(q4) * (Cos(q2 + q3) * Sin(q1) * Sin(q2) + Sin(q2 + q3) * Cos(q2) * Sin(q1)))) - Cos(q6) * (Cos(q1) * Cos(q4) + Sin(q4) * (Cos(q2 + q3) * Sin(q1) * Sin(q2) + Sin(q2 + q3) * Cos(q2) * Sin(q1)));

        mz = Cos(q5) * (Cos(q2 + q3) * Cos(q2) * Sin(q1) - Sin(q2 + q3) * Sin(q1) * Sin(q2)) + Sin(q5) * (Cos(q1) * Sin(q4) - Cos(q4) * (Cos(q2 + q3) * Sin(q1) * Sin(q2) + Sin(q2 + q3) * Cos(q2) * Sin(q1)));

        nx = -Cos(q6) * (Sin(q5) * (Cos(q2 + q3) * Sin(q2) + Sin(q2 + q3) * Cos(q2)) - Cos(q4) * Cos(q5) * (Cos(q2 + q3) * Cos(q2) - Sin(q2 + q3) * Sin(q2))) - Sin(q4) * Sin(q6) * (Cos(q2 + q3) * Cos(q2) - Sin(q2 + q3) * Sin(q2));

        ny = Cos(q6) * Sin(q4) * (Cos(q2 + q3) * Cos(q2) - Sin(q2 + q3) * Sin(q2)) - Sin(q6) * (Sin(q5) * (Cos(q2 + q3) * Sin(q2) + Sin(q2 + q3) * Cos(q2)) - Cos(q4) * Cos(q5) * (Cos(q2 + q3) * Cos(q2) - Sin(q2 + q3) * Sin(q2)));

        nz = Cos(q5) * (Cos(q2 + q3) * Sin(q2) + Sin(q2 + q3) * Cos(q2)) + Cos(q4) * Sin(q5) * (Cos(q2 + q3) * Cos(q2) - Sin(q2 + q3) * Sin(q2));

        var qx = transform.rotation.x;
        var qy = transform.rotation.y;
        var qz = transform.rotation.z;
        var qw = transform.rotation.w;

        lz1 = Round((qw * qw + qx * qx - qz * qz - qy * qy)*100)/100;

        nx1 = Round((qy * qy - qz * qz + qw * qw - qx * qx) * 100) / 100;

        my1 = Round((-1*(qz * qz - qy * qy - qx * qx + qw * qw)) * 100) / 100;

        lx1 = Round((-qz * qw + qy * qx - qw * qz + qx * qy) * 100) / 100;

        ly1 = Round((-1*(qy * qw + qz * qx + qx * qz + qw * qy)) * 100) / 100;

        nz1 = Round((qx * qy + qw * qz + qz * qw + qy * qx) * 100) / 100;

        ny1 = Round((-1*(qz * qy + qy * qz - qx * qw - qw * qx)) * 100) / 100;

        mz1 = Round((qx * qz - qw * qy + qz * qx - qy * qw) * 100) / 100;

        mx1 = Round((qy * qz + qz * qy + qw * qx + qx * qw) * 100) / 100;

    }

}
