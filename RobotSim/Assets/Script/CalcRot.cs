using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Mathf;

public class CalcRot : MonoBehaviour
{
    private float d1, d2, d3, d4, d5, d6;   
    private GameObject[] Sliders = new GameObject[6];
    public float nx, ny, nz, mx, my, mz, lx, ly, lz;

    public float q1, q2, q3, q4, q5, q6;
    public float q1Calc, q2Calc, q3Calc, q4Calc, q5Calc, q6Calc;

    // Start is called before the first frame update
    void Start()
    {
        d1 = 0.33f;
        d2 = 0.075f;
        d3 = 0.3f;
        d4 = 0.075f;
        d5 = 0.32f;
        d6 = 0.08f;

        Sliders[0] = GameObject.Find("Slider Axis 1");
        Sliders[1] = GameObject.Find("Slider Axis 2");
        Sliders[2] = GameObject.Find("Slider Axis 3");
        Sliders[3] = GameObject.Find("Slider Axis 4");
        Sliders[4] = GameObject.Find("Slider Axis 5");
        Sliders[5] = GameObject.Find("Slider Axis 6");
    }

    // Update is called once per frame
    void Update()
    {
        q1 = Sliders[0].GetComponent<Slider>().value * Deg2Rad;
        q2 = Sliders[1].GetComponent<Slider>().value * Deg2Rad;
        q3 = Sliders[2].GetComponent<Slider>().value * Deg2Rad;
        q4 = Sliders[3].GetComponent<Slider>().value * Deg2Rad;
        q5 = Sliders[4].GetComponent<Slider>().value * Deg2Rad;
        q6 = Sliders[5].GetComponent<Slider>().value * Deg2Rad;


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


        q1Calc = Atan2(Pry, Prx);

        /// q2 ///

        var W = Prx * Cos(q1Calc) + Pry * Sin(q1Calc) - d2;
        var U = Prz - d1;

        var A = 2 * d3 * W;
        var B = 2 * d3 * U;
        var D = W * W + U * U + d3 * d3 - d5 * d5 - d4 * d4;

        q2Calc = Atan2(D, Sqrt(A * A + B * B - D * D)) - Atan2(B, A);

        /// q3 ///

        A = d5;
        B = d4;
        D = U - d3 * Cos(q2Calc);

        q3Calc = Atan2(D, Sqrt(A * A + B * B - D * D)) - Atan2(B, A);

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
        q5Calc = Acos(W);



        /// q4 ///  

            B = (m3x * nx + m3y * ny + m3z * nz);
            A = (l3x * nx + l3y * ny + l3z * nz);

        if(q5Calc == 0)
        {
            q4Calc = 0;
        }
        else if(Atan2(B, A) > 0)
        {
            q4Calc = Atan2(B, A) - 3.14f;
        }
        else
        {
            q4Calc = Atan2(B, A) + 3.14f;
        }
        /// q6 /// 

        A = (Sin(q4) * (l3x * lx + l3y * ly + l3z * lz) - Cos(q4) * (lx * m3x + ly * m3y + lz * m3z));
        W  = Sin(q4) * (l3x * mx + l3y * my + l3z * mz) - Cos(q4) * (m3x * mx + m3y * my + m3z * mz);

        if(W > 1 || W < -1)
        {
            q6Calc = 0;
        }
        else
        {
            q6Calc = Acos(W) - PI;
        }
        if (A < 0)
        {
            q6Calc = -q6Calc;
        }

        
        W = (l3x * nx + l3y * ny + l3z * nz) + Sin(q4) * (m3x * nx + m3y * ny + m3z * nz);
        if(W > 0)
        {
            q5Calc = -q5Calc;
        }

    }
}
