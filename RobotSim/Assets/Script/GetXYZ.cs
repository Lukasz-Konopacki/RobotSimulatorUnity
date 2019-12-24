using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetXYZ : MonoBehaviour
{
    public Text TextBox;
    public GameObject LastJoint;
    // Start is called before the first frame update
    void Start()
    {
        TextBox = gameObject.GetComponent<Text>();
        LastJoint = GameObject.Find("LR Mate-200iC Part 6");
    }

    // Update is called once per frame
    void Update()
    {
        var x = Mathf.Round(LastJoint.transform.position.x * 100f);
        var y = Mathf.Round(LastJoint.transform.position.y * 100f);
        var z = Mathf.Round(LastJoint.transform.position.z * 100f);

        var Rotx = Mathf.Round(LastJoint.transform.rotation.eulerAngles.x);
        var Roty = Mathf.Round(LastJoint.transform.rotation.eulerAngles.y);
        var Rotz = Mathf.Round(LastJoint.transform.rotation.eulerAngles.z);


        TextBox.text = $"X:{x} Y:{y} Z:{z}\n" +
                       $"Rx:{Rotx} Ry:{Roty} Rz:{Rotz}";

    }
}
