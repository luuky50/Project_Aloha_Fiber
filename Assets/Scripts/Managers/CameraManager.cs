using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : SingletonComponent<CameraManager>
{
    public Camera arealCamera;
    public Camera groundCamera;

    bool camSwitch;

    public void SwitchCamera()
    {
        groundCamera = GameObject.FindGameObjectWithTag("Player").GetComponent<Camera>();
        camSwitch = !camSwitch;
        arealCamera.enabled = camSwitch;
        groundCamera.enabled = !camSwitch;
        Debug.Log(camSwitch);
    }

}
