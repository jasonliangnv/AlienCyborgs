using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool paused;
    public GameObject pauseMenuUI;
    public GameObject player;
    //public GameObject canvasUI;

    // Start is called before the first frame update
    void Start()
    {
        paused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            
            if (paused)
            {
                ResumeGame();
            }
            else
            {
                
                PauseGame();
            }
            
        }
    }

    public void ResumeGame()
    {
        player.GetComponent<PlayerMovementm>().enabled = true;
        player.GetComponent<FireBulletm>().enabled = true;
        Time.timeScale = 1;
        //canvasUI.SetActive(true);
        pauseMenuUI.SetActive(false);
        paused = false;
        
    }

    public void PauseGame()
    {
        player.GetComponent<PlayerMovementm>().enabled = false;
        player.GetComponent<FireBulletm>().enabled = false;
        paused = true;
        Time.timeScale = 0;
        //canvasUI.SetActive(false);
        pauseMenuUI.SetActive(true);
        
    }

    public void QuitLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}