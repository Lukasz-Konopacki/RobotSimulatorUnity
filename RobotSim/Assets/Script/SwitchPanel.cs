using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPanel : MonoBehaviour
{
    public GameObject PanelFor;
    public GameObject PanelInv;
    public GameObject Cube;

    public void PanelVisibility()
    {
       

        if(PanelFor.activeSelf == true)
        {
            PanelFor.SetActive(false);
            PanelInv.SetActive(true);
            Cube.GetComponent<MoveCube>().enabled = true;
            Cube.GetComponent<CalcRot>().enabled = false;
            Cube.GetComponent<CalcXYZ>().enabled = false;
        }
        else
        {
            PanelInv.SetActive(false);
            PanelFor.SetActive(true);
            Cube.GetComponent<MoveCube>().enabled = false;
            Cube.GetComponent<CalcRot>().enabled = true;
            Cube.GetComponent<CalcXYZ>().enabled = true;
        }
            

    }
}