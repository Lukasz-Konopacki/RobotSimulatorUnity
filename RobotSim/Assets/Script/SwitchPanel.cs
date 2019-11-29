using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchPanel : MonoBehaviour
{
    public GameObject PanelFor;
    public GameObject PanelInv;
    public GameObject Cube;
    public GameObject Button;
    private Slider[] SlidersFor = new Slider[6];
    private Slider[] SlidersInv = new Slider[6];
    private PartClass[] Parts = new PartClass[6];
    public void Start()
    {
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

            Button.GetComponent<Text>().text = "Zadanie Proste";

            SlidersInv[0].value = Cube.transform.position.x;
            SlidersInv[1].value = Cube.transform.position.y;
            SlidersInv[2].value = Cube.transform.position.z;
            SlidersInv[3].value = Cube.transform.rotation.eulerAngles.x;
            SlidersInv[4].value = Cube.transform.rotation.eulerAngles.y;
            SlidersInv[5].value = Cube.transform.rotation.eulerAngles.z;

            Debug.Log($"{Cube.transform.rotation.eulerAngles.x}, {Cube.transform.rotation.eulerAngles.y}, {Cube.transform.rotation.eulerAngles.z}");

        }
        else
        {
            PanelInv.SetActive(false);
            PanelFor.SetActive(true);

            Cube.GetComponent<MoveCube>().enabled = false;
            Cube.GetComponent<CalcRot>().enabled = true;
            Cube.GetComponent<CalcXYZ>().enabled = true;

            Button.GetComponent<Text>().text = "Zadanie Odwrotne";

            for(int i = 0; i < 6; i++)
            {
                SlidersFor[i].value = Parts[i].RotValue;
            }
        }         
    }
}