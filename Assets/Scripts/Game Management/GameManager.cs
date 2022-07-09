using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public int points = 0;
    public int lives = 9;
    public bool gameOver = false;
    public int currentLevel = 1;
    public int basePoints = 10;
    public int goalPoints;
    bool gamePaused = false;
    bool gameWin = false;
    public GameObject dogWarning;
    public GameObject humanWarning;

    UIManager uiManager;
    // Start is called before the first frame update
    void Start () {
        Time.timeScale = 1f;
        goalPoints = currentLevel * basePoints;
        StartCoroutine(Warning());
        uiManager = GetComponent<UIManager> ();
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
        uiManager.winPanel.SetActive (true);
        dogWarning.SetActive (false);
        humanWarning.SetActive(false);
        Time.timeScale = 0f;
    }

    void ResetGame () {
        points = 0;
        lives = 9;
        gameOver = false;
        uiManager.gameOverPanel.SetActive (false);
    }

    public void RestartGame () {
        ResetGame ();
        SceneManager.LoadScene ("GamePlay");
    }

    public void NavigateToMainMenu () {
        ResetGame ();
        SceneManager.LoadScene ("MainMenu");
    }

    void PauseGame () {
        uiManager.pausePanel.SetActive (true);
        gamePaused = true;
        Time.timeScale = 0f;
    }

    public void ResumeGame () {
        uiManager.pausePanel.SetActive (false);
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
        uiManager.gameOverPanel.SetActive (true);
        UpdateOverallPoints ();
    }

    public void Win () {
        uiManager.winPanel.SetActive (true);
        Time.timeScale = 0f;
        UpdateOverallPoints ();
    }

    public void ContinueGame () {
        currentLevel++;
        points = 0;
        goalPoints = currentLevel * basePoints;
        uiManager.winPanel.SetActive (false);
        Time.timeScale = 1f;
        uiManager.UpdateLevelText (currentLevel);
        uiManager.UpdatePointsText (points, goalPoints);
    }

    public void ReduceLife (int lostLives) {
        lives = lives < lostLives ? 0 : lives - lostLives;
        uiManager.UpdateLivesText (lives);
    }

    public void AddLife () {
        lives++;
        uiManager.UpdateLivesText (lives);
    }

    public void UpdatePoints () {
        points++;
        uiManager.UpdatePointsText (points, goalPoints);
    }

    IEnumerator Warning() {
        int randomEnemy = Random.Range(0,10);
        if (!gameOver) {
            if (randomEnemy <= 7) {
                int randomTime = Random.Range(15, 30);
                yield return new WaitForSeconds (randomTime);
                dogWarning.SetActive (true);
            } else {
                int randomTime = Random.Range(20, 40);
                yield return new WaitForSeconds(randomTime);
                humanWarning.SetActive(true);
            }
            StartCoroutine(Warning());
        }
    }

    IEnumerator DogWarning () {
        int randomTime = Random.Range(15, 30);
        yield return new WaitForSeconds (randomTime);
        dogWarning.SetActive (true);
    }

    IEnumerator HumanWarning() {
        int randomTime = Random.Range(50, 60);
        yield return new WaitForSeconds(randomTime);
        humanWarning.SetActive(true);
    }
}