using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour {
    public GameObject snack;
    public GameObject obstacle;
    public GameObject[] effects;
    public GameObject treat;
    public float maxPos;
    GameManagement gameManagement;

    // Start is called before the first frame update
    void Start () {
        gameManagement = GameObject.Find ("GameManagement").GetComponent<GameManagement> ();
        StartCoroutine (SpawnItem ());
    }

    // Update is called once per frame
    void Update () {

    }

    IEnumerator SpawnItem () {
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
        if (!gameManagement.gameOver) {
            StartCoroutine (SpawnItem ());
        }

    }
}