using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetAngleText : MonoBehaviour
{
    public GameObject part;

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Text>().text = part.GetComponent<PartClass>().RotValue.ToString() + "°";
    }
}
