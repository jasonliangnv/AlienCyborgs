using System.Collections;
using System.Collections.Generic;
using UnityEditor.Presets;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CommsRoomComputerm : MonoBehaviour
{
    public GameObject screenHighlight;
    public GameObject canvas;
    public GameObject tileMap;
    public GameObject escapePodTiles;
    public CameraShake shake;
    public bool escapePod = false;
    Animator animator;

    private bool canPlay;
    private bool pressed;
    // Start is called before the first frame update
    void Start()
    {
        animator = canvas.GetComponentInChildren<Animator>();
        canvas.SetActive(false);
        canPlay = false;
        pressed = false;
        shake.start = false;
        animator.enabled = false;
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.E) && canPlay && !pressed && escapePod == true){
            //animator.Play("Image");
            pressed = true;
            canvas.SetActive(true);
            animator.enabled = true;
            screenHighlight.SetActive(false);
            PlayerMovementm.canMove = false;
            tileMap.SetActive(false);
            escapePodTiles.SetActive(true);
            shake.start = true;
            StartCoroutine(loadWinScreen());
        }
        else if (Input.GetKey(KeyCode.E) && canPlay && !pressed){
            //animator.Play("Image");
            pressed = true;
            canvas.SetActive(true);
            animator.enabled = true;
            screenHighlight.SetActive(false);
            PlayerMovementm.canMove = false;
        }
        if (canvas != null && animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1f)
        {
            canvas.SetActive(false);
            screenHighlight.SetActive(false);
            //Debug.Log("Animation playing! ");
            PlayerMovementm.canMove = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !pressed)
        {
            canPlay = true;
            screenHighlight.SetActive(true);

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canPlay = false;
            screenHighlight.SetActive(false);

        }
    }

    public IEnumerator loadWinScreen()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
