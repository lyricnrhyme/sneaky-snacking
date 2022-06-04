using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bread : MonoBehaviour
{
    GameManager gameManager;
    KittenMovement kittenMovement;

    void Start() {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        kittenMovement = GameObject.Find("Kitten").GetComponent<KittenMovement>();
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == Constants.PLAYER_TAG) {
            kittenMovement.UpdateSpeed(false);
        }

        Destroy(gameObject);
    }
}
