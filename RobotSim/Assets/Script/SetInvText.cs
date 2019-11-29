using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetInvText : MonoBehaviour
{
    public Text[] InvTexts = new Text[6];

    public GameObject Cube;

    // Start is called before the first frame update
    void Start()
    {
        InvTexts[0] = GameObject.Find("PosX").GetComponent<Text>();
        InvTexts[1] = GameObject.Find("PosY").GetComponent<Text>();
        InvTexts[2] = GameObject.Find("PosZ").GetComponent<Text>();
        InvTexts[3] = GameObject.Find("RotX").GetComponent<Text>();
        InvTexts[4] = GameObject.Find("RotY").GetComponent<Text>();
        InvTexts[5] = GameObject.Find("RotZ").GetComponent<Text>();

        Cube = GameObject.Find("Cube");
    }

    // Update is called once per frame
    void Update()
    {
        InvTexts[0].text = Cube.transform.position.x.ToString();
        InvTexts[1].text = Cube.transform.position.y.ToString();
        InvTexts[2].text = Cube.transform.position.z.ToString();
        InvTexts[3].text = Cube.transform.rotation.eulerAngles.x.ToString();
        InvTexts[4].text = Cube.transform.rotation.eulerAngles.y.ToString();
        InvTexts[5].text = Cube.transform.rotation.eulerAngles.z.ToString();

    }
}
