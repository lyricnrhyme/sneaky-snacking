using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KittenMovement : MonoBehaviour {
    public int moveSpeed;
    public float maxPos;
    GameManagement gameManagement;

    // Start is called before the first frame update
    void Start () {
        gameManagement = GameObject.Find ("GameManagement").GetComponent<GameManagement> ();
    }

    // Update is called once per frame
    void Update () {
        if (!gameManagement.gameOver) {
            Move ();
        }
    }

    void Move () {
        if (Input.GetKey ("a") || Input.GetKey ("left")) {
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        } else if (Input.GetKey ("d") || Input.GetKey ("right")) {
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;
        }
        float xPos = Mathf.Clamp (transform.position.x, -maxPos, maxPos);
        transform.position = new Vector3 (xPos, transform.position.y, transform.position.z);
    }

    void OnCollisionEnter2D (Collision2D other) {
        if (other.gameObject.tag == "Snack") {
            gameManagement.points++;
            gameManagement.UpdatePointsText ();
        } else if (other.gameObject.tag == "Obstacle") {
            gameManagement.ReduceLife ();
        }
        if (gameManagement.points >= gameManagement.goalPoints) {
            gameManagement.Win ();
        }
        Destroy (other.gameObject);
    }
}