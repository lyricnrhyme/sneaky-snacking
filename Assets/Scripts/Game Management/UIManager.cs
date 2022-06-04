using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
    public GameObject pausePanel;
    public GameObject gameOverPanel;
    public GameObject winPanel;
    public Text pointsText;
    public Text levelText;
    public Text livesText;

    public void UpdatePointsText (int points, int goalPoints) {
        pointsText.text = "Points: " + points + "/" + goalPoints;
    }

    public void UpdateLevelText (int currentLevel) {
        levelText.text = "Level: " + currentLevel;
    }

    public void UpdateLivesText (int lives) {
        livesText.text = "Lives: " + lives;
    }
}