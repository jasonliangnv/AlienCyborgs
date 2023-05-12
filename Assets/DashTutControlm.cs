using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEditor.Presets;
using UnityEngine;

public class DashTutControlm : MonoBehaviour
{
    public GameObject canvas;
    Animator animator;

    bool dashTuttrigger;
    bool runOnce;
    // Start is called before the first frame update
    void Start()
    {
        animator = canvas.GetComponentInChildren<Animator>();
        canvas.SetActive(false);
        animator.enabled = false;
        dashTuttrigger = false;
        runOnce = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (dashTuttrigger && runOnce)
        {
            canvas.SetActive(true);
            animator.enabled = true;
            PlayerMovementm.canMove = false;

            if (canvas != null && animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1f)
            {
                canvas.SetActive(false);
                PlayerMovementm.canMove = true;
                dashTuttrigger = false;
                runOnce = false;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            dashTuttrigger = true;
        }
    }
}
