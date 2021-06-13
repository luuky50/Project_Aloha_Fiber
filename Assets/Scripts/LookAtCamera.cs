using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    public bool isText;
    void Update()
    {
        if (isText)
        {
            transform.LookAt(transform.position - CameraManager.instance.arealCamera.transform.position);
        }
        else
        {
            transform.LookAt(CameraManager.instance.arealCamera.transform.position);
        }
    }
}
