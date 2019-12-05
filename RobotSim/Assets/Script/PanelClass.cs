using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Mathf;

public class PanelClass : MonoBehaviour
{
    public GameObject PanelFor;
    public GameObject PanelInv;
    public GameObject Cube;
    public GameObject SwitchButton;
    private Slider[] SlidersFor;
    private Slider[] SlidersInv;
    private PartClass[] Parts;
    private float[] SaveRotateValue;

    public void Start()
    {
        SlidersFor = new Slider[6];
        SlidersInv = new Slider[6];
        Parts = new PartClass[6];
        SaveRotateValue = new float[6];

        SlidersFor[0] = GameObject.Find("Slider Axis 1").GetComponent<Slider>();
        SlidersFor[1] = GameObject.Find("Slider Axis 2").GetComponent<Slider>();
        SlidersFor[2] = GameObject.Find("Slider Axis 3").GetComponent<Slider>();
        SlidersFor[3] = GameObject.Find("Slider Axis 4").GetComponent<Slider>();
        SlidersFor[4] = GameObject.Find("Slider Axis 5").GetComponent<Slider>();
        SlidersFor[5] = GameObject.Find("Slider Axis 6").GetComponent<Slider>();

        SlidersInv[0] = GameObject.Find("Slider OX").GetComponent<Slider>();
        SlidersInv[1] = GameObject.Find("Slider OY").GetComponent<Slider>();
        SlidersInv[2] = GameObject.Find("Slider OZ").GetComponent<Slider>();
        SlidersInv[3] = GameObject.Find("Slider DX").GetComponent<Slider>();
        SlidersInv[4] = GameObject.Find("Slider DY").GetComponent<Slider>();
        SlidersInv[5] = GameObject.Find("Slider DZ").GetComponent<Slider>();

        Parts[0] = GameObject.Find("LR Mate-200iC Part 1").GetComponent<PartClass>();
        Parts[1] = GameObject.Find("LR Mate-200iC Part 2").GetComponent<PartClass>();
        Parts[2] = GameObject.Find("LR Mate-200iC Part 3").GetComponent<PartClass>();
        Parts[3] = GameObject.Find("LR Mate-200iC Part 4").GetComponent<PartClass>();
        Parts[4] = GameObject.Find("LR Mate-200iC Part 5").GetComponent<PartClass>();
        Parts[5] = GameObject.Find("LR Mate-200iC Part 6").GetComponent<PartClass>();

        PanelInv.SetActive(false);
    }
    public void Reset()
    {
        if (PanelFor.activeSelf == true)
        {
            for (int i = 0; i < 6; i++)
            {
                SlidersFor[i].value = 0;
                Parts[i].RotValue = 0;
            }
        }
        else
        {
            SlidersInv[0].value = 0.475f;
            SlidersInv[1].value = 0.705f;
            SlidersInv[2].value = 0;
            SlidersInv[3].value = 0;
            SlidersInv[4].value = 0;
            SlidersInv[5].value = 90;

        }
    }
    public void SavePosition()
    {
        for(int i = 0; i <6; i++)
        {
            SaveRotateValue[i] = Parts[i].RotValue;
        }
    }

    public void LoadPosition()
    {
        if (PanelFor.activeSelf == true)
        {
            for (int i = 0; i < 6; i++)
            {
                SlidersFor[i].value = SaveRotateValue[i];
                Parts[i].RotValue = SaveRotateValue[i];
            }
        }
        else
        {

        }
    }


    public void PanelVisibility()
    {
        if (PanelFor.activeSelf == true)
        {
            PanelFor.SetActive(false);
            PanelInv.SetActive(true);

            Cube.GetComponent<MoveCube>().enabled = true;
            Cube.GetComponent<CalcRot>().enabled = false;
            Cube.GetComponent<CalcXYZ>().enabled = false;

            SwitchButton.GetComponent<Text>().text = "Zadanie Proste";

            SlidersInv[0].value = Round(Cube.transform.position.x * 10000)/10000;
            SlidersInv[1].value = Round(Cube.transform.position.y * 10000) / 10000;
            SlidersInv[2].value = Round(Cube.transform.position.z * 10000) / 10000;

            if (Cube.transform.rotation.eulerAngles.x > 180)
            {
                SlidersInv[3].value = SlidersInv[3].value = Cube.transform.rotation.eulerAngles.x - 360;
            }
            else
            {
                SlidersInv[3].value = Cube.transform.rotation.eulerAngles.x;
            }
            if (Cube.transform.rotation.eulerAngles.y > 180)
            {
                SlidersInv[4].value = Cube.transform.rotation.eulerAngles.y - 360;
            }
            else
            {
                SlidersInv[4].value = Cube.transform.rotation.eulerAngles.y;
            }
            if (Cube.transform.rotation.eulerAngles.z > 180)
            {
                SlidersInv[5].value = Cube.transform.rotation.eulerAngles.z - 360;
            }
            else
            {
                SlidersInv[5].value = Cube.transform.rotation.eulerAngles.z;
            }

            Debug.Log($"{SlidersInv[3].value }, {SlidersInv[4].value }, {SlidersInv[5].value }");

        }
        else
        {
            PanelInv.SetActive(false);
            PanelFor.SetActive(true);

            Cube.GetComponent<MoveCube>().enabled = false;
            Cube.GetComponent<CalcRot>().enabled = true;
            Cube.GetComponent<CalcXYZ>().enabled = true;

            SwitchButton.GetComponent<Text>().text = "Zadanie Odwrotne";

            for(int i = 0; i < 6; i++)
            {
                SlidersFor[i].value = Parts[i].RotValue;
            }
        }         
    }


}