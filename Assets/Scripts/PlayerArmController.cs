using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArmController : MonoBehaviour
{

    /*
     * The purpose of this is to swap out weapon sprites and point toward mouse
     */
    Vector3 mousePos;
    
    public Camera mainCam;
    public Sprite gunDown;
    public Sprite gunDownRight;
    public Sprite gunRight;
    public Sprite gunRightUp;
    public Sprite gunUp;
    public Sprite gunLeftUp;
    public Sprite gunLeft;
    public Sprite gunLeftDown;
    private SpriteRenderer spriteRenderer;
   

    private void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sortingOrder = 3;

    }
    private void LateUpdate()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;
        Vector3 lookDir = mousePos - transform.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        float sAngle = angle;
        //Debug.Log("Angle is! " + angle);

        // Point gun down to the right
        if (sAngle > -60f && sAngle <= -30f)
        {
            angle += 45f;
            spriteRenderer.sortingOrder = 3;
            spriteRenderer.sprite = gunDownRight;
        }
        // Point gun to the right
        else if (sAngle > -30f && sAngle <= 30f)
        {

            spriteRenderer.sortingOrder = 3;
            spriteRenderer.sprite = gunRight;
        }
        // Point gun up to the right
        else if (sAngle > 30f && sAngle <= 65f)
        {

            angle -= 45f;
            spriteRenderer.sortingOrder = 2;
            spriteRenderer.sprite = gunRightUp;
        }
        // Point gun up
        else if (sAngle > 65f && sAngle <= 120f)
        {

            angle -= 90f;
            spriteRenderer.sortingOrder = 2;
            spriteRenderer.sprite = gunUp;
        }
        // Point gun up to the left
        else if (sAngle > 120f && sAngle <= 155f)
        {
            angle -= 135f;
            spriteRenderer.sortingOrder = 2;
            spriteRenderer.sprite = gunLeftUp;
        }
        // Point gun to the left
        else if (sAngle > 155f || sAngle <= -155f)
        {
            angle += 180f;
            spriteRenderer.sortingOrder = 3;
            spriteRenderer.sprite = gunLeft;
        }
        // Point gun down to the left
        else if (sAngle > -155f && sAngle <= -125f)
        {
            angle -= 225f;
            spriteRenderer.sortingOrder = 3;
            spriteRenderer.sprite = gunLeftDown;
        }
        // Point gun down
        else
        {
            angle += 90f;

            spriteRenderer.sortingOrder = 3;
            spriteRenderer.sprite = gunDown;
        }

        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
  
}
