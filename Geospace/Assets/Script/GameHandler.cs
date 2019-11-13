using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{
    public String scene;
    [SerializeField] private HealthBar healthBar;


    public void loadScene()
    {
        SceneManager.LoadScene(scene);
    }

    public void pauseGame()
    {
        Time.timeScale = 0;
    }

    public void continueGame()
    {
        Time.timeScale = 1;
    }
}
