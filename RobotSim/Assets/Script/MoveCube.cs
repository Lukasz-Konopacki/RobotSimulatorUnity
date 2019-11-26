using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Mathf;

public class MoveCube : MonoBehaviour
{
    private GameObject[] Sliders = new GameObject[6];
    private GameObject[] Part = new GameObject[6];
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

        Sliders[0] = GameObject.Find("Slider OX");
        Sliders[1] = GameObject.Find("Slider OY");
        Sliders[2] = GameObject.Find("Slider OZ");
        Sliders[3] = GameObject.Find("Slider DX");
        Sliders[4] = GameObject.Find("Slider DY");
        Sliders[5] = GameObject.Find("Slider DZ");

        Part[0] = GameObject.Find("LR Mate-200iC Part 1");
        Part[1] = GameObject.Find("LR Mate-200iC Part 2");
        Part[2] = GameObject.Find("LR Mate-200iC Part 3");
        Part[3] = GameObject.Find("LR Mate-200iC Part 4");
        Part[4] = GameObject.Find("LR Mate-200iC Part 5");
        Part[5] = GameObject.Find("LR Mate-200iC Part 6");


    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Sliders[0].GetComponent<Slider>().value, Sliders[1].GetComponent<Slider>().value, 
                                Sliders[2].GetComponent<Slider>().value);


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

        Part[0].GetComponent<PartClass>().Rotate(q1 * Rad2Deg);
        Part[1].GetComponent<PartClass>().Rotate(q2 * Rad2Deg);
        Part[2].GetComponent<PartClass>().Rotate((q3 +q2) * Rad2Deg);

        ///// Czesc Orientacyjna /////

        var l3x = Cos(q2 + q3) * Cos(q1) * Sin(q2) - Sin(q2 + q3) * Cos(q1) * Cos(q2);
        var n3z = Cos(q2 + q3) * Sin(q2) - Sin(q2 + q3) * Cos(q2);
        var n3x = -Cos(q2 + q3) * Cos(q1) * Cos(q2) - Sin(q2 + q3) * Cos(q1) * Sin(q2);
        var l3z = Cos(q2 + q3) * Cos(q2) + Sin(q2 + q3) * Sin(q2);
        var l3y = Cos(q2 + q3) * Sin(q1) * Sin(q2) - Sin(q2 + q3) * Cos(q2) * Sin(q1);
        var n3y = -Cos(q2 + q3) * Cos(q2) * Sin(q1) - Sin(q2 + q3) * Sin(q1) * Sin(q2);

        /// q5 ///

        W = Round((n3x * nx + n3y * ny + n3z * nz) * 100000) / 100000; // Zaokrąglam by dla wartości 0 się zgadzało


        q5 = Acos(W);


    }
}
