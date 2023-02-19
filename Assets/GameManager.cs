using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject startScreen;
    public GameObject restartScreen;
    private bool gameStarted = false;

    public void StartGame()
    {
        startScreen.SetActive(false);
        gameStarted = true;
    }

    public bool HasStarted() { return gameStarted; }

    public void RestartGame()
    {
        restartScreen.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void EndGame()
    {
        restartScreen.SetActive(true);
    }
}
