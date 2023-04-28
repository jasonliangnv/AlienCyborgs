using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TutorialControl : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        PlayerMovementm.canMove = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Check if tutorial animation is done
        if (gameObject != null && animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.25f)
        {
            Debug.Log("Animation playing! ");
            PlayerMovementm.canMove = false;
        }
        else if (gameObject != null)
        {
            animator.enabled = false;

            PlayerMovementm.canMove = true;
        }
        // Destory animation window
        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)) && gameObject != null && PlayerMovementm.canMove)
        {
            Destroy(gameObject);
        }
    }
}
