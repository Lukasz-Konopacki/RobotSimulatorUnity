using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InverseScript : MonoBehaviour
{
    public GameObject[] part = new GameObject[7];
    public float angle1;



    // Start is called before the first frame update
    void Start()
    {
        angle1 = Mathf.Atan((-gameObject.transform.position.z) / gameObject.transform.position.x) * 57.29f;

        part[1].transform.Rotate(0, angle1, 0);
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
