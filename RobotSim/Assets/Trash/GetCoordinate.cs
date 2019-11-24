using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetCoordinate : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject LastJoint;
    public Text [] TextBoxes = new Text[6];

    void Start()
    {
        LastJoint = GameObject.Find("LR Mate-200iC axis 6");
    }

    // Update is called once per frame
    void Update()
    {
        var x = Mathf.Round(LastJoint.transform.position.x * 100f);
        var y = Mathf.Round(LastJoint.transform.position.y * 100f);
        var z = Mathf.Round(LastJoint.transform.position.z * 100f);
        var dx = LastJoint.transform.rotation.eulerAngles.x;
        var dy = LastJoint.transform.rotation.eulerAngles.y;
        var dz = LastJoint.transform.rotation.eulerAngles.z;

        TextBoxes[0].text = Mathf.Round(x).ToString();
        TextBoxes[1].text = Mathf.Round(y).ToString();
        TextBoxes[2].text = Mathf.Round(z).ToString();
        TextBoxes[3].text = Mathf.Round(dx).ToString();
        TextBoxes[4].text = Mathf.Round(dy).ToString();
        TextBoxes[5].text = Mathf.Round(dz).ToString();
    }
}
