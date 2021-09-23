using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverSceenBehavior : MonoBehaviour
{
    public GameObject pauseGame;

    public void Start()
    {
        pauseGame.SetActive(true);
        Time.timeScale = 0.0f;
    }

    public void Play()
    {
        pauseGame.SetActive(false);
        Time.timeScale = 1.0f;
    }
}
