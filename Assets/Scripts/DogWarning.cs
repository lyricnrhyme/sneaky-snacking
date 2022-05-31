using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogWarning : MonoBehaviour {
    public GameObject dog;

    private void OnEnable () {
        StartCoroutine (ShowDog ());
    }

    IEnumerator ShowDog () {
        yield return new WaitForSeconds (5f);
        dog.SetActive (true);
        gameObject.SetActive (false);
    }
}