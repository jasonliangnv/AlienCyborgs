using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private bool loading = false;

    void Update()
    {
        if(SceneManager.GetActiveScene().buildIndex == 2 && loading == false)
        {
            loading = true;
            StartCoroutine(loadMainMenu());
        }
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public IEnumerator loadMainMenu()
    {
        yield return new WaitForSeconds(5f);
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        SceneManager.LoadScene(0);
    }
}
