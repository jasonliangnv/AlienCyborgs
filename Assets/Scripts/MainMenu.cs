using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private bool loading = false;
    public TextMeshProUGUI title;
    public TextMeshProUGUI description;

    void Update()
    {
        if(SceneManager.GetActiveScene().buildIndex == 2 && loading == false)
        {
            loading = true;
            StartCoroutine(showCredits());
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

    public IEnumerator showCredits()
    {
        yield return new WaitForSeconds(5f);
        title.text = "Alien Cyborgs";
        description.text = "Credits\n" + "Coder - Liam Francisco\n" + "Designer - Jason Liang\n" + "Artist - Dennis Brown\n" + "Producer - Randall Fernandez";
    }

    public IEnumerator loadMainMenu()
    {
        yield return new WaitForSeconds(10f);
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        SceneManager.LoadScene(0);
    }
}
