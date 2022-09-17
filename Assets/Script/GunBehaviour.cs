using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBehaviour : MonoBehaviour
{

    public GameObject gunPrefab;
    private void Update()
    {
        //Get mouse position
        Vector3 mouseScenePosition = Input.mousePosition;
        //Change mouse depth to gameObject
        mouseScenePosition.z = transform.position.z;
        //Put mouse on screen as pixel
        Ray ray = Camera.main.ScreenPointToRay(mouseScenePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            //TODO regardez pour X et Y ensemble
            //TODO Work ????!
            gunPrefab.transform.LookAt(new Vector3(hit.point.x, transform.position.y, hit.point.z));
            //gunPrefab.transform.LookAt(new Vector3(hit.point.x, hit.point.y, hit.point.z));
        }

    }



}
