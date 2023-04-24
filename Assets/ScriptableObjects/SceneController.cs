using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "SceneController", menuName = "Scenes")]
public class SceneController : ScriptableObject
{
    public bool isNextScene;

    void OnEnable()
    {
        isNextScene = true;
    }
}
