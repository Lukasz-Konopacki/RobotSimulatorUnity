using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Mathf;

public class MoveCube : MonoBehaviour
{
    private Slider[] Sliders = new Slider[6];
    private GameObject[] Part = new GameObject[6];
    private GameObject Panel;
    private float d1, d2, d3, d4, d5, d6;
    private float nx, ny, nz, mx, my, mz, lx, ly, lz;

    public float q1, q2, q3, q4, q5, q6;

    // Start is called before the first frame update
    void Start()
    {
        d1 = 0.33f;
        d2 = 0.075f;
        d3 = 0.3f;
        d4 = 0.075f;
        d5 = 0.32f;
        d6 = 0.08f;

        Sliders[0] = GameObject.Find("Slider OX").GetComponent<Slider>();
        Sliders[1] = GameObject.Find("Slider OY").GetComponent<Slider>();
        Sliders[2] = GameObject.Find("Slider OZ").GetComponent<Slider>();
        Sliders[3] = GameObject.Find("Slider DX").GetComponent<Slider>();
        Sliders[4] = GameObject.Find("Slider DY").GetComponent<Slider>();
        Sliders[5] = GameObject.Find("Slider DZ").GetComponent<Slider>();

        Part[0] = GameObject.Find("LR Mate-200iC Part 1");
        Part[1] = GameObject.Find("LR Mate-200iC Part 2");
        Part[2] = GameObject.Find("LR Mate-200iC Part 3");
        Part[3] = GameObject.Find("LR Mate-200iC Part 4");
        Part[4] = GameObject.Find("LR Mate-200iC Part 5");
        Part[5] = GameObject.Find("LR Mate-200iC Part 6");

        Panel = GameObject.Find("Message");
        Panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Sliders[0].GetComponent<Slider>().value, Sliders[1].GetComponent<Slider>().value, 
                                Sliders[2].GetComponent<Slider>().value);

        transform.rotation = Quaternion.Euler(Sliders[3].value, Sliders[4].value, Sliders[5].value);


        var qx = transform.rotation.x;
        var qy = transform.rotation.y;
        var qz = transform.rotation.z;
        var qw = transform.rotation.w;

        lx = (qw * qw + qx * qx - qz * qz - qy * qy);
        nz = (qy * qy - qz * qz + qw * qw - qx * qx);
        my = (qz * qz - qy * qy - qx * qx + qw * qw);
        nx = (-qz * qw + qy * qx - qw * qz + qx * qy);
        mx = (qy * qw + qz * qx + qx * qz + qw * qy);
        lz = (qx * qy + qw * qz + qz * qw + qy * qx);
        mz = (qz * qy + qy * qz - qx * qw - qw * qx);
        ly = (qx * qz - qw * qy + qz * qx - qy * qw);
        ny = (qy * qz + qz * qy + qw * qx + qx * qw);

        /// q1 ///

        var Prx = transform.position.x + nx * d6;
        var Pry = transform.position.z + ny * d6;
        var Prz = transform.position.y + nz * d6;


        q1 = Atan2(Pry, Prx);

        /// q2 ///

        var W = Prx * Cos(q1) + Pry * Sin(q1) - d2;
        var U = Prz - d1;

        var A = 2 * d3 * W;
        var B = 2 * d3 * U;
        var D = W * W + U * U + d3 * d3 - d5 * d5 - d4 * d4;

        q2 = Atan2(D, Sqrt(A * A + B * B - D * D)) - Atan2(B, A);

        /// q3 ///

        A = d5;
        B = d4;
        D = U - d3 * Cos(q2);

        q3 = Atan2(D, Sqrt(A * A + B * B - D * D)) - Atan2(B, A);


        ///// Czesc Orientacyjna /////

        var l3x = Cos(q2 + q3) * Cos(q1) * Sin(q2) - Sin(q2 + q3) * Cos(q1) * Cos(q2);
        var n3z = Cos(q2 + q3) * Sin(q2) - Sin(q2 + q3) * Cos(q2);
        var n3x = -Cos(q2 + q3) * Cos(q1) * Cos(q2) - Sin(q2 + q3) * Cos(q1) * Sin(q2);
        var l3z = Cos(q2 + q3) * Cos(q2) + Sin(q2 + q3) * Sin(q2);
        var l3y = Cos(q2 + q3) * Sin(q1) * Sin(q2) - Sin(q2 + q3) * Cos(q2) * Sin(q1);
        var n3y = -Cos(q2 + q3) * Cos(q2) * Sin(q1) - Sin(q2 + q3) * Sin(q1) * Sin(q2);
        var m3x = -Sin(q1);
        var m3y = Cos(q1);
        var m3z = 0;

        /// q5 ///

        W = Round((n3x * nx + n3y * ny + n3z * nz) * 100000) / 100000; // Zaokrąglam by dla wartości 0 się zgadzało
        q5 = Acos(W);



        /// q4 ///  

        B = (m3x * nx + m3y * ny + m3z * nz);
        A = (l3x * nx + l3y * ny + l3z * nz);

        if (q5 == 0)
        {
            q4 = 0;
        }
        else if (Atan2(B, A) > 0)
        {
            q4 = Atan2(B, A) - 3.14f;
        }
        else
        {
            q4 = Atan2(B, A) + 3.14f;
        }
        /// q6 /// 

        A = (Sin(q4) * (l3x * lx + l3y * ly + l3z * lz) - Cos(q4) * (lx * m3x + ly * m3y + lz * m3z));
        W = Sin(q4) * (l3x * mx + l3y * my + l3z * mz) - Cos(q4) * (m3x * mx + m3y * my + m3z * mz);

        if (W > 1 || W < -1)
        {
            q6 = 0;
        }
        else
        {
            q6 = Acos(W) - PI;
        }
        if (A < 0)
        {
            q6 = -q6;
        }


        q1 = q1 * Rad2Deg;
        q2 = q2 * Rad2Deg;
        q3 = q3 * Rad2Deg;
        q4 = q4 * Rad2Deg;
        q5 = q5 * Rad2Deg;
        q6 = q6 * Rad2Deg;

        if(float.IsNaN(q1)|| float.IsNaN(q2)|| float.IsNaN(q3)|| float.IsNaN(q4)|| float.IsNaN(q5)|| float.IsNaN(q6))
        {
            Panel.SetActive(true);
        }
        else if(q1 > 180 || q1 < -180)
        {
            Panel.SetActive(true);
        }
        else if(q2 > 140 || q2 < -60 )
        {
            Panel.SetActive(true);
        }
        else if(q3 > 185 || q2 < -72)
        {
            Panel.SetActive(true);
        }
        else if(q4 > 190 || q4 < -190)
        {
            Panel.SetActive(true);
        }
        else if(q5 > 120 || q5 < -120)
        {
            Panel.SetActive(true);
        }
        else
        {
            Part[0].GetComponent<PartClass>().Rotate(q1);
            Part[1].GetComponent<PartClass>().Rotate(q2);
            Part[2].GetComponent<PartClass>().Rotate((q3 + q2));
            Part[3].GetComponent<PartClass>().Rotate(q4);
            Part[4].GetComponent<PartClass>().Rotate(q5);
            Part[5].GetComponent<PartClass>().Rotate(q6);
            Panel.SetActive(false);
        }
    }
}
