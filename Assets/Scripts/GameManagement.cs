using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagement : MonoBehaviour {
    public static int points = 0;
    public static int lives = 9;
    public static int goalPoints = 10;
    public static bool gameOver = false;
    public GameObject pausePanel;
    public GameObject winPanel;
    bool gamePaused = false;
    bool gameWin = false;
    // Start is called before the first frame update
    void Start () { }

    // Update is called once per frame
    void Update () {
        if ((Input.GetKeyDown (KeyCode.Escape) || Input.GetKeyDown ("q")) && !gamePaused) {
            PauseGame ();
        }

        if (points >= goalPoints && !gameWin) {
            WinGame ();
        }

    }

    public void WinGame () {
        gameWin = true;
        winPanel.SetActive (true);
        Time.timeScale = 0f;
    }

    public void RestartGame () {
        SceneManager.LoadScene ("GamePlay");
        points = 0;
        lives = 9;
        gameOver = false;
    }

    public void NavigateToMainMenu () {
        SceneManager.LoadScene ("MainMenu");
    }

    public void PauseGame () {
        pausePanel.SetActive (true);
        gamePaused = true;
        Time.timeScale = 0f;
    }

    public void ResumeGame () {
        pausePanel.SetActive (false);
        gamePaused = false;
        Time.timeScale = 1f;
    }
}