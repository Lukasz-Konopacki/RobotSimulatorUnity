using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Mathf;

public class SetAngleText : MonoBehaviour
{
    public GameObject part;

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Text>().text = Round(part.GetComponent<PartClass>().RotValue).ToString() + "°";
    }
}
