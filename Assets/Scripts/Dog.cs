using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour {
    GameManagement gameManagement;
    public GameObject kitten;

    // Update is called once per frame
    void Update () {
        if (kitten.activeInHierarchy) {
            gameManagement.GameOver ();
        }
    }

    private void OnEnable () {
        gameManagement = GameObject.Find ("GameManagement").GetComponent<GameManagement> ();
        StartCoroutine (Disappear ());
    }

    IEnumerator Disappear () {
        yield return new WaitForSeconds (5f);
        gameObject.SetActive (false);
    }
}