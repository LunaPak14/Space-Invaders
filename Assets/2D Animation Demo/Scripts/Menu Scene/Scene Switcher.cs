using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public string gameSceneName;

    public void LoadScene()
    {
        SceneManager.LoadScene(gameSceneName, LoadSceneMode.Single);
    }
}
