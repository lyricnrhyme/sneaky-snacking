using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DogWarning : MonoBehaviour {
    public GameObject dog;
    public Image radialTimer;
    AudioManager audioManager;
    float secondsLeft = 3f;

    private void OnEnable () {
        audioManager = GameObject.Find ("AudioManager").GetComponent<AudioManager> ();
        StartCoroutine (ShowDog ());
        
    }

    private void Update () {
        if (secondsLeft > 0) {
            secondsLeft -= Time.deltaTime;
            radialTimer.fillAmount = secondsLeft / 3f;
        }
    }

    IEnumerator ShowDog () {
        audioManager.PlayWarningSound();
        yield return new WaitForSeconds (secondsLeft);
        dog.SetActive (true);
        gameObject.SetActive (false);
        secondsLeft = 3f;
        radialTimer.fillAmount = 1;
    }
}