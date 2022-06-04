using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snack : MonoBehaviour
{
    GameManager gameManager;

    void Start() {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == Constants.PLAYER_TAG) {
            gameManager.UpdatePoints();
            if (gameManager.points >= gameManager.goalPoints) {
                gameManager.Win();
            }
        }

        Destroy(gameObject);
    }
}
