using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetSliderVal : MonoBehaviour
{
    public GameObject Slider;
    public Text TextBox { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        TextBox = gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        TextBox.text = Slider.GetComponent<Slider>().value.ToString() + "°";
    }
}
