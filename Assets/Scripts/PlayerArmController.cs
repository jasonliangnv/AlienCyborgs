using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArmController : MonoBehaviour
{

    /*
     * The purpose of this is to point players arms toward mouse while holding gun. Dosent quite work properly yet and needs work
     */
    Vector3 mousePos;
    public Camera mainCam;
   
    private void FixedUpdate()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;
        Vector3 lookDir = mousePos - transform.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg + 90f;
       
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

    }
}
