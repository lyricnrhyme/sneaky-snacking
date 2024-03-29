using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoundaryLine : MonoBehaviour {
    GameManager gameManager;

    // Start is called before the first frame update
    void Start () {
        gameManager = GameObject.Find ("GameManager").GetComponent<GameManager> ();
    }

    void OnCollisionEnter2D (Collision2D other) {
        if (other.gameObject.tag == Constants.SNACK_TAG) {
            gameManager.ReduceLife (1);
        }
        if (gameManager.lives <= 0) {
            gameManager.GameOver ();
        }
        Destroy (other.gameObject);
    }
}