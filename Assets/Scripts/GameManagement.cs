using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagement : MonoBehaviour {
    public int points = 0;
    public int lives = 9;
    public bool gameOver = false;
    public int currentLevel = 1;
    public int basePoints = 10;
    public int goalPoints;
    bool gamePaused = false;
    bool gameWin = false;
    public GameObject hidingKitten;
    public GameObject dogWarning;
    UIHandler uiHandler;
    // Start is called before the first frame update
    void Start () {
        Time.timeScale = 1f;
        goalPoints = currentLevel * basePoints;
        StartCoroutine (DogWarning ());
        uiHandler = GetComponent<UIHandler> ();
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
        uiHandler.winPanel.SetActive (true);
        Time.timeScale = 0f;
    }

    void ResetGame () {
        points = 0;
        lives = 9;
        gameOver = false;
        uiHandler.gameOverPanel.SetActive (false);
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
        uiHandler.pausePanel.SetActive (true);
        gamePaused = true;
        Time.timeScale = 0f;
    }

    void ResumeGame () {
        uiHandler.pausePanel.SetActive (false);
        gamePaused = false;
        Time.timeScale = 1f;
    }

    void UpdateOverallPoints () {
        int overallPoints = PlayerPrefs.GetInt ("OverallPoints", 0);
        PlayerPrefs.SetInt ("OverallPoints", overallPoints + points);
    }

    public void GameOver () {
        gameOver = true;
        Time.timeScale = 0f;
        uiHandler.gameOverPanel.SetActive (true);
        UpdateOverallPoints ();
    }

    public void Win () {
        uiHandler.winPanel.SetActive (true);
        Time.timeScale = 0f;
        UpdateOverallPoints ();
    }

    public void ContinueGame () {
        currentLevel++;
        points = 0;
        goalPoints = currentLevel * basePoints;
        uiHandler.winPanel.SetActive (false);
        Time.timeScale = 1f;
        uiHandler.UpdateLevelText (currentLevel);
        uiHandler.UpdatePointsText (points, goalPoints);
    }

    public void ReduceLife () {
        lives--;
        uiHandler.UpdateLivesText (lives);
    }

    public void AddLife () {
        lives++;
        uiHandler.UpdateLivesText (lives);
    }

    public void UpdatePoints () {
        points++;
        uiHandler.UpdatePointsText (points, goalPoints);
    }

    IEnumerator DogWarning () {
        yield return new WaitForSeconds (30f);
        dogWarning.SetActive (true);
        if (!gameOver) {
            StartCoroutine (DogWarning ());
        }
    }
}