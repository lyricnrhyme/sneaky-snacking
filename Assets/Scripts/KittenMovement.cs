using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KittenMovement : MonoBehaviour {
    int moveSpeed = 15;
    bool invertedControls = false;
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
            Vector3 direction = invertedControls ? Vector3.right : Vector3.left;
            transform.position += direction * moveSpeed * Time.deltaTime;
        } else if (Input.GetKey ("d") || Input.GetKey ("right")) {
            Vector3 direction = invertedControls ? Vector3.left : Vector3.right;
            transform.position += direction * moveSpeed * Time.deltaTime;
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
        } else if (other.gameObject.tag == "Bread") {
            StartCoroutine (ReduceSpeed ());
        } else if (other.gameObject.tag == "Catnip") {
            int catnipEffectIdx = Random.Range (0, 2);
            if (catnipEffectIdx == 0) {
                StartCoroutine (DoubleSpeed ());
            } else {
                StartCoroutine (InvertControls ());
            }
        } else if (other.gameObject.tag == "Treat") {
            gameManagement.AddLife ();
        }
        if (gameManagement.points >= gameManagement.goalPoints) {
            gameManagement.Win ();
        }
        Destroy (other.gameObject);
    }

    IEnumerator ReduceSpeed () {
        moveSpeed = 7;
        yield return new WaitForSeconds (5f);
        moveSpeed = 15;
    }

    IEnumerator DoubleSpeed () {
        moveSpeed = 30;
        yield return new WaitForSeconds (10f);
        moveSpeed = 15;
    }

    IEnumerator InvertControls () {
        invertedControls = true;
        yield return new WaitForSeconds (10f);
        invertedControls = false;
    }
}