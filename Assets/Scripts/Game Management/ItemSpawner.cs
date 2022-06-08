using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour {
    public GameObject snack;
    public GameObject obstacle;
    public GameObject[] effects;
    public GameObject treat;
    public string[] tags;
    public float maxPos;
    GameManager gameManager;
    KittenMovement kittenMovement;

    // Start is called before the first frame update
    void Start () {
        gameManager = GameObject.Find ("GameManager").GetComponent<GameManager> ();
        kittenMovement = GameObject.Find ("Kitten").GetComponent<KittenMovement> ();
        StartCoroutine (SpawnItem ());
    }

    public IEnumerator SpawnItem () {
        float xPos = Random.Range (-maxPos, maxPos);
        int randomNum = Random.Range (0, 100);
        if (randomNum < 5 && gameManager.lives < 9) {
            Instantiate (treat, new Vector3 (xPos, transform.position.y, transform.position.z), Quaternion.identity);
        } else if (randomNum < 5) {
            Instantiate (snack, new Vector3 (xPos, transform.position.y, transform.position.z), Quaternion.identity);
        } else if (randomNum >= 5 && randomNum < 20) {
            int effectIdx = Random.Range (0, effects.Length);
            Instantiate (effects[effectIdx], new Vector3 (xPos, transform.position.y, transform.position.z), Quaternion.identity);
        } else if (randomNum >= 20 && randomNum < 40) {
            Instantiate (obstacle, new Vector3 (xPos, transform.position.y, transform.position.z), Quaternion.identity);
        } else {
            Instantiate (snack, new Vector3 (xPos, transform.position.y, transform.position.z), Quaternion.identity);
        }

        yield return new WaitForSeconds (1f);
        if (!gameManager.gameOver && !kittenMovement.isHiding) {
            StartCoroutine (SpawnItem ());
        }

    }

    public void DestroyAllItems () {
        foreach (string tag in tags) {
            GameObject[] items = GameObject.FindGameObjectsWithTag (tag);
            foreach (GameObject item in items) {
                Destroy (item);
            }
        }
    }
}