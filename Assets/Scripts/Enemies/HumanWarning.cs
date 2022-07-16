using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HumanWarning : MonoBehaviour
{
    public GameObject human;
    public Image radialTimer;
    AudioManager audioManager;
    float secondsLeft = 3;

    private void OnEnable() {
        audioManager = GameObject.Find ("AudioManager").GetComponent<AudioManager> ();
        StartCoroutine(ShowHuman());
    }

    private void Update () {
        if (secondsLeft > 0) {
            secondsLeft -= Time.deltaTime;
            radialTimer.fillAmount = secondsLeft / 3f;
        }
    }

    IEnumerator ShowHuman() {
        audioManager.PlayWarningSound();
        yield return new WaitForSeconds(secondsLeft);
        human.SetActive(true);
        gameObject.SetActive(false);
        secondsLeft = 3f;
        radialTimer.fillAmount = 1;
    }
}
