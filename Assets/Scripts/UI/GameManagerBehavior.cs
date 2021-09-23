using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerBehavior : MonoBehaviour
{
    [SerializeField]
    private PlayerBehavior _player;

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

    public void Checkpoint()
    {
        _player.transform.position = _player.checkpoint;
    }

    public void Restart()
    {
        SceneManager.LoadScene("PhysicsScene");
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}
