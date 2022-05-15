using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoundaryLine : MonoBehaviour {
    public Text livesText;
    public GameObject gameOverPanel;
    GameManagement gameManagement;

    // Start is called before the first frame update
    void Start () {
        gameManagement = GameObject.Find ("GameManagement").GetComponent<GameManagement> ();
    }

    // Update is called once per frame
    void Update () {

    }

    void OnCollisionEnter2D (Collision2D other) {
        if (other.gameObject.tag == Constants.SNACK_TAG) {
            gameManagement.ReduceLife ();
        }
        if (gameManagement.lives <= 0) {
            gameManagement.GameOver ();
        }
        Destroy (other.gameObject);
    }
}