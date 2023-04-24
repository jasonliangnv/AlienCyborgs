using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitScene : MonoBehaviour
{
    public string sceneName;
    public GameObject exit;
    public bool isNextScene = true;
    [SerializeField]
    public SceneController sceneInfo;

    void OnTriggerEnter2D(Collider2D player)
    {
        sceneInfo.isNextScene = isNextScene;
        SceneManager.LoadScene(sceneName);
    }
}
