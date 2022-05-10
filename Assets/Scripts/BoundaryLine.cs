using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoundaryLine : MonoBehaviour {
    public Text livesText;
    public GameObject gameOverPanel;
    // Start is called before the first frame update
    void Start () {

    }

    // Update is called once per frame
    void Update () {

    }

    void OnCollisionEnter2D (Collision2D other) {
        GameManagement.lives--;
        livesText.text = "Lives: " + GameManagement.lives;
        if (GameManagement.lives <= 0) {
            GameManagement.gameOver = true;
            gameOverPanel.SetActive (true);
        }
        Destroy (other.gameObject);
    }
}