using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour {
    public GameObject snack;
    public GameObject obstacle;
    public GameObject[] effects;
    public GameObject treat;
    public GameObject hidingKitten;
    public GameObject kitten;
    public string[] tags;
    public float maxPos;
    bool isHiding = false;
    GameManagement gameManagement;

    // Start is called before the first frame update
    void Start () {
        gameManagement = GameObject.Find ("GameManagement").GetComponent<GameManagement> ();
        StartCoroutine (SpawnItem ());
    }

    // Update is called once per frame
    void Update () {
        Hide ();
    }

    void Hide () {
        if (Input.GetKeyDown ("w") || Input.GetKeyDown ("up")) {
            isHiding = true;
            hidingKitten.SetActive (true);
            kitten.SetActive (false);
            DestroyAllItems ();
        } else if (Input.GetKeyDown ("s") || Input.GetKeyDown ("down")) {
            isHiding = false;
            hidingKitten.SetActive (false);
            kitten.SetActive (true);
            StartCoroutine (SpawnItem ());
        }
    }

    public IEnumerator SpawnItem () {
        float xPos = Random.Range (-maxPos, maxPos);
        int randomNum = Random.Range (0, 100);
        if (randomNum < 5) {
            Instantiate (treat, new Vector3 (xPos, transform.position.y, transform.position.z), Quaternion.identity);
        } else if (randomNum >= 5 && randomNum < 20) {
            int effectIdx = Random.Range (0, effects.Length);
            Instantiate (effects[effectIdx], new Vector3 (xPos, transform.position.y, transform.position.z), Quaternion.identity);
        } else if (randomNum >= 20 && randomNum < 50) {
            Instantiate (obstacle, new Vector3 (xPos, transform.position.y, transform.position.z), Quaternion.identity);
        } else {
            Instantiate (snack, new Vector3 (xPos, transform.position.y, transform.position.z), Quaternion.identity);
        }

        yield return new WaitForSeconds (1f);
        if (!gameManagement.gameOver && !isHiding) {
            StartCoroutine (SpawnItem ());
        }

    }

    void DestroyAllItems () {
        foreach (string tag in tags) {
            GameObject[] items = GameObject.FindGameObjectsWithTag (tag);
            foreach (GameObject item in items) {
                Destroy (item);
            }
        }
    }
}