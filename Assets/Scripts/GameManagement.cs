using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagement : MonoBehaviour {
    public int points = 0;
    public int lives = 9;
    public bool gameOver = false;
    public GameObject pausePanel;
    public GameObject winPanel;
    public Text pointsText;
    public Text levelText;
    public int currentLevel = 1;
    public int basePoints = 10;
    public int goalPoints;
    bool gamePaused = false;
    bool gameWin = false;
    // Start is called before the first frame update
    void Start () {
        Time.timeScale = 1f;
        goalPoints = currentLevel * basePoints;
    }

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

    void ResetGame () {
        points = 0;
        lives = 9;
        gameOver = false;
    }

    void RestartGame () {
        ResetGame ();
        SceneManager.LoadScene ("GamePlay");
    }

    void NavigateToMainMenu () {
        ResetGame ();
        SceneManager.LoadScene ("MainMenu");
    }

    void PauseGame () {
        pausePanel.SetActive (true);
        gamePaused = true;
        Time.timeScale = 0f;
    }

    void ResumeGame () {
        pausePanel.SetActive (false);
        gamePaused = false;
        Time.timeScale = 1f;
    }

    public void Win () {
        winPanel.SetActive (true);
        Time.timeScale = 0f;
    }

    public void UpdatePointsText () {
        pointsText.text = "Points: " + points + "/" + goalPoints;
    }

    void UpdateLevelText () {
        levelText.text = "Level: " + currentLevel;
    }

    public void ContinueGame () {
        currentLevel++;
        points = 0;
        goalPoints = currentLevel * basePoints;
        winPanel.SetActive (false);
        Time.timeScale = 1f;
        UpdateLevelText ();
        UpdatePointsText ();
    }
}