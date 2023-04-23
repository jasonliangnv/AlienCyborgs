using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public bool paused;
    public GameObject pauseMenuUI;
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
        Time.timeScale = 1;
        //canvasUI.SetActive(true);
        pauseMenuUI.SetActive(false);
        paused = false;
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        //canvasUI.SetActive(false);
        pauseMenuUI.SetActive(true);
        paused = true;
    }

    public void QuitLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}