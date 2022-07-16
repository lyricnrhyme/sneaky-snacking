using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snack : MonoBehaviour
{
    GameManager gameManager;
    AudioManager audioManager;

    void Start() {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        audioManager = GameObject.Find ("AudioManager").GetComponent<AudioManager> ();
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == Constants.PLAYER_TAG) {
            audioManager.PlayPointsSound();
            gameManager.UpdatePoints();
            if (gameManager.points >= gameManager.goalPoints) {
                gameManager.Win();
            }
        }

        Destroy(gameObject);
    }
}
