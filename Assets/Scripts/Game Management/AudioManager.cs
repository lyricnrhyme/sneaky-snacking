using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource gameOverSound;
    public AudioSource winSound;
    public AudioSource clickSound;
    public AudioSource hidingSound;
    public AudioSource caughtSound;
    public AudioSource warningSound;
    public AudioSource pointsSound;
    public AudioSource catnipSound;
    public AudioSource scaredSound;
    public AudioSource healthSound;
    public AudioSource breadSound;
    public AudioSource BGMSound;

    public void PlayGameOverSound() {
        gameOverSound.Play();
    }

    public void PlayWinSound() {
        winSound.Play();
    }

    public void PlayClickSound() {
        clickSound.Play();
    }

    public void PlayHidingSound() {
        hidingSound.Play();
    }

    public void StopHidingSound() {
        hidingSound.Stop();
    }

    public void PlayCaughtSound() {
        caughtSound.Play();
    }

    public void PlayWarningSound() {
        warningSound.Play();
    }

    public void PlayPointsSound() {
        pointsSound.Play();
    }

    public void PlayCatnipSound() {
        catnipSound.Play();
    }

    public void StopCatnipSound() {
        catnipSound.Stop();
    }

    public void PlayScaredSound() {
        scaredSound.Play();
    }

    public void PlayHealthSound() {
        healthSound.Play();
    }

    public void PlayBreadSound() {
        breadSound.Play();
    }

    public void PlayBGMSound() {
        BGMSound.Play();
    }

    public void PauseBGMSound() {
        BGMSound.Pause();
    }

    public void StopBGMSound() {
        BGMSound.Stop();
    }
}
