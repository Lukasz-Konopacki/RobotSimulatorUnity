using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPanel : MonoBehaviour
{
    public GameObject PanelFor;
    public GameObject PanelInv;

    public void PanelVisibility()
    {
       

        if(PanelFor.activeSelf == true)
        {
            PanelFor.SetActive(false);
            PanelInv.SetActive(true);
        }
        else
        {
            PanelInv.SetActive(false);
            PanelFor.SetActive(true);
        }
            

    }
}