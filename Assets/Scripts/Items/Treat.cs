using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treat : MonoBehaviour
{
    GameManager gameManager;
    Animator kittenMovementAnim;

    void Start() {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        kittenMovementAnim = GameObject.Find("Kitten").GetComponent<Animator>();
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == Constants.PLAYER_TAG) {
            kittenMovementAnim.SetTrigger("GainLife");
            gameManager.AddLife();
        }

        Destroy(gameObject);
    }
}
