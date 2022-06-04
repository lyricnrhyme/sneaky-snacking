using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KittenMovement : MonoBehaviour {
    int moveSpeed = 15;
    int baseMoveSpeed = 15;
    public float maxPos;
    public bool isHiding;
    bool invertedControls = false;
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

    public void UpdateSpeed(bool isFaster) {
        if (isFaster) {
            StartCoroutine(DoubleSpeed());
        } else {
            StartCoroutine(ReduceSpeed());
        }
    }

    public void TriggerInvertControls() {
        StartCoroutine(InvertControls());
    }

    public IEnumerator ReduceSpeed() {
        moveSpeed = 7;
        yield return new WaitForSeconds(5f);
        moveSpeed = baseMoveSpeed;
    }

    public IEnumerator DoubleSpeed () {
        moveSpeed = 30;
        yield return new WaitForSeconds (7f);
        moveSpeed = baseMoveSpeed;
    }

    public IEnumerator InvertControls () {
        invertedControls = true;
        yield return new WaitForSeconds (10f);
        invertedControls = false;
    }
}