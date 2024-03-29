using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    GameManager gameManager;
    Animator kittenMovementAnim;
    AudioManager audioManager;

    void Start() {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        kittenMovementAnim = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<Animator>();
        audioManager = GameObject.Find ("AudioManager").GetComponent<AudioManager> ();
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == Constants.PLAYER_TAG) {
            audioManager.PlayScaredSound();
            kittenMovementAnim.SetTrigger("Scared");
            gameManager.ReduceLife(1);
            if (gameManager.lives == 0) gameManager.GameOver();
        }

        Destroy(gameObject);
    }
}
