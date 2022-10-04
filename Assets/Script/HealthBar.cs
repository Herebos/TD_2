using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
    }
    void Update()
    {

        Vector3 cameraPosition = mainCamera.transform.position;
        cameraPosition.y = transform.position.y;
        transform.LookAt(cameraPosition);
    }
}
