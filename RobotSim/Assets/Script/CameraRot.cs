using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraRot : MonoBehaviour
{
    public float speed;
    private bool checkUI;
    public GameObject target;
    // Update is called once per frame
    private void Start()
    {
        speed = 100f;
    }

    void Update()
    {

        checkUI = EventSystem.current.IsPointerOverGameObject();

        if (Input.GetMouseButton(0)&& !checkUI)
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * speed * Time.deltaTime, 0);
            //transform.Rotate(Input.GetAxis("Mouse Y") * speed * Time.deltaTime, 0, 0);
        }
        else if(Input.GetAxis("Mouse ScrollWheel") > 0 && target.transform.localPosition.z > 1)
        {
            target.transform.Translate(0, 0, speed * Time.deltaTime * Input.GetAxis("Mouse ScrollWheel"));
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0 && target.transform.localPosition.z < 3)
        {
            target.transform.Translate(0, 0, speed * Time.deltaTime * Input.GetAxis("Mouse ScrollWheel"));
        }
    }
}
