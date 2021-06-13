using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{

    [SerializeField]
    private Vector3 camStartPos;
    private Transform rotationPoint;

    [SerializeField]
    private float rotationSpeed;

    bool playerInput = false;


    public Vector3 mousePos;

    void Start()
    {
        rotationPoint = gameObject.transform.parent;
        CameraManager.instance.arealCamera.transform.position = camStartPos;
    }

    void Update()
    {
        if (!playerInput)
        {
            rotationPoint.Rotate(Vector3.up * Time.deltaTime * rotationSpeed);

        }
        if (Input.GetMouseButtonDown(0))
        {
            mousePos = Input.mousePosition;
            playerInput = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            playerInput = false;
        }

    }
    private void LateUpdate()
    {
        if (playerInput)
        {
            float _mousePos = Input.GetAxis("Mouse X");
            rotationPoint.Rotate(Vector3.up, _mousePos * rotationSpeed, Space.World);
        }


    }
}
