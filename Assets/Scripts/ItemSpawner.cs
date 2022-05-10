using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour {
    public GameObject snack;
    public float maxPos;

    // Start is called before the first frame update
    void Start () {
        StartCoroutine (SpawnItem ());
    }

    // Update is called once per frame
    void Update () {

    }

    IEnumerator SpawnItem () {
        float xPos = Random.Range (-maxPos, maxPos);
        Instantiate (snack, new Vector3 (xPos, transform.position.y, transform.position.z), Quaternion.identity);

        yield return new WaitForSeconds (2f);
        if (!GameManagement.gameOver) {
            StartCoroutine (SpawnItem ());
        }

    }
}