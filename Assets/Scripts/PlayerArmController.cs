using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArmController : MonoBehaviour
{

    /*
     * The purpose of this is to point players arms toward mouse while holding gun. Dosent quite work properly yet and needs work
     */
    Vector3 mousePos;
    public Transform armLookPoint;
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
    }
    private void FixedUpdate()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;
        Vector3 lookDir = mousePos - armLookPoint.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        //Debug.Log("Angle is! " + angle);
        if (angle > -60f && angle <= -22.5f)
        {
            angle += 45f;
            spriteRenderer.sprite = gunDownRight;
        }
        /*
        else if (angle > 22.5f && angle <= 45f)
        {
            spriteRenderer.sprite = gunRightUp;
        }
        else if (angle > 45f && angle <= 112.5f)
        {
            spriteRenderer.sprite = gunUp;
        }
        else if (angle > 112.5f && angle <= 135f)
        {
            spriteRenderer.sprite = gunLeftUp;
        }
        else if (angle > 135f && angle >= -135f)
        {
            spriteRenderer.sprite = gunLeft;
        }
        else if (angle < -135f && angle >= -112.5f)
        {
            spriteRenderer.sprite = gunLeftDown;
        }
        */
        else
        {
            angle += 90f;
            spriteRenderer.sprite = gunDown;
        }
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);


        

      

    }
}
