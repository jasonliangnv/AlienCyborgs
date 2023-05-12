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
    public Texture2D cursorTexture;
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
        Vector2 cursorOffset = new Vector2(cursorTexture.width / 2, cursorTexture.height / 2);
        Cursor.SetCursor(cursorTexture, cursorOffset, CursorMode.ForceSoftware);
        paused = false;
        
    }

    public void PauseGame()
    {
        player.GetComponent<PlayerMovementm>().enabled = false;
        player.GetComponent<FireBulletm>().enabled = false;
        paused = true;
        Time.timeScale = 0;
        //canvasUI.SetActive(false);
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        pauseMenuUI.SetActive(true);
        
    }

    public void QuitLevel()
    {
        Time.timeScale = 1;
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        SceneManager.LoadScene(0);
    }
}