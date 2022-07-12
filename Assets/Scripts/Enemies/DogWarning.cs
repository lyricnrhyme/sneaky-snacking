using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogWarning : MonoBehaviour {
    public GameObject dog;

    private void OnEnable () {
        StartCoroutine (ShowDog ());
        Debug.Log("SHOW ME PLS");
    }

    IEnumerator ShowDog () {
        yield return new WaitForSeconds (3f);
        dog.SetActive (true);
        gameObject.SetActive (false);
    }
}