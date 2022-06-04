using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KittenMovement : MonoBehaviour {
    int moveSpeed = 15;
    bool invertedControls = false;
    public float maxPos;
    public bool isHiding;
    GameManager gameManager;
    ItemSpawner itemSpawner;
    public GameObject kitten;

    // Start is called before the first frame update
    void Start () {
        gameManager = GameObject.Find ("GameManager").GetComponent<GameManager> ();
        itemSpawner = GameObject.Find ("ItemSpawner").GetComponent<ItemSpawner> ();
    }

    // Update is called once per frame
    void Update () {
        if (!gameManager.gameOver) {
            if (!isHiding) {
                Move ();
            }
            Hide();
        }
    }

    void Hide() {
        if (Input.GetKeyDown ("w") || Input.GetKeyDown ("up")) {
            isHiding = true;
            kitten.transform.position = new Vector3 (6.86f, -1.21f, 0f);
            itemSpawner.DestroyAllItems ();
        } else if (Input.GetKeyDown ("s") || Input.GetKeyDown ("down")) {
            isHiding = false;
            kitten.transform.position = new Vector3 (0f, -3.2118f, 0f);
            StartCoroutine (itemSpawner.SpawnItem ());
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
        if (other.gameObject.tag == Constants.SNACK_TAG) {
            gameManager.UpdatePoints ();
        } else if (other.gameObject.tag == Constants.OBSTACLE_TAG) {
            gameManager.ReduceLife ();
        } else if (other.gameObject.tag == Constants.BREAD_TAG) {
            StartCoroutine (ReduceSpeed ());
        } else if (other.gameObject.tag == Constants.CATNIP_TAG) {
            int catnipEffectIdx = Random.Range (0, 2);
            if (catnipEffectIdx == 0) {
                StartCoroutine (DoubleSpeed ());
            } else {
                StartCoroutine (InvertControls ());
            }
        } else if (other.gameObject.tag == Constants.TREAT_TAG) {
            gameManager.AddLife ();
        }
        if (gameManager.points >= gameManager.goalPoints) {
            gameManager.Win ();
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