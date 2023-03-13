using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditScript : MonoBehaviour
{
    public string gameSceneName;
    private int timer;

    private void Start()
    {
        timer = (int)Mathf.Floor(Time.realtimeSinceStartup);
    }

    private void Update()
    {
        Debug.Log((int)Mathf.Floor(Time.realtimeSinceStartup) - timer);
        if ((int)Mathf.Floor(Time.realtimeSinceStartup) - timer == 42)
            LoadScene();
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(gameSceneName, LoadSceneMode.Single);
    }
}
