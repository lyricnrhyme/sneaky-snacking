using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treat : MonoBehaviour
{
    GameManager gameManager;
    Animator kittenMovementAnim;
    AudioManager audioManager;

    void Start() {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        kittenMovementAnim = GameObject.Find("Kitten").GetComponent<Animator>();
        audioManager = GameObject.Find ("AudioManager").GetComponent<AudioManager> ();
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == Constants.PLAYER_TAG) {
            audioManager.PlayHealthSound();
            kittenMovementAnim.SetTrigger("GainLife");
            gameManager.AddLife();
        }

        Destroy(gameObject);
    }
}
