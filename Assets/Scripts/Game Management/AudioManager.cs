using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public Image musicOffIcon;
    public Image soundEffectsOffIcon;
    bool isMusicOn;
    bool isSoundEffectsOn;
    KittenMovement kittenMovement;

    void Awake() {
        isMusicOn = PlayerPrefs.GetInt("IsMusicOn", 1) == 1 ? true : false;
        isSoundEffectsOn = PlayerPrefs.GetInt("IsSoundEffectsOn", 1) == 1 ? true : false;
        musicOffIcon.enabled = !isMusicOn;
        soundEffectsOffIcon.enabled = !isSoundEffectsOn;
    }

    void Start() {
        if (GameObject.FindGameObjectsWithTag("Player").Length > 0)
        kittenMovement = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<KittenMovement> ();
    }

    public void PlayGameOverSound() {
        if (isSoundEffectsOn) gameOverSound.Play();
    }

    public void PlayWinSound() {
        if (isSoundEffectsOn) winSound.Play();
    }

    public void PlayClickSound() {
        if (isSoundEffectsOn) clickSound.Play();
    }

    public void PlayHidingSound() {
        if (isMusicOn) hidingSound.Play();
    }

    public void StopHidingSound() {
        hidingSound.Stop();
    }

    public void PlayCaughtSound() {
        if (isSoundEffectsOn) caughtSound.Play();
    }

    public void PlayWarningSound() {
        if (isSoundEffectsOn) warningSound.Play();
    }

    public void PlayPointsSound() {
        if (isSoundEffectsOn) pointsSound.Play();
    }

    public void PlayCatnipSound() {
        if (isMusicOn) catnipSound.Play();
    }

    public void StopCatnipSound() {
        catnipSound.Stop();
    }

    public void PlayScaredSound() {
        if (isSoundEffectsOn) scaredSound.Play();
    }

    public void PlayHealthSound() {
        if (isSoundEffectsOn) healthSound.Play();
    }

    public void PlayBreadSound() {
        if (isSoundEffectsOn) breadSound.Play();
    }

    public void PlayBGMSound() {
        if (isMusicOn) BGMSound.Play();
    }

    public void PauseBGMSound() {
        BGMSound.Pause();
    }

    public void StopBGMSound() {
        BGMSound.Stop();
    }

    public void ToggleMusic() {
        isMusicOn = !isMusicOn;
        PlayerPrefs.SetInt("IsMusicOn", isMusicOn ? 1 : 0);
        musicOffIcon.enabled = !isMusicOn;
    }

    public void ToggleSoundEffects() {
        isSoundEffectsOn = !isSoundEffectsOn;
        PlayerPrefs.SetInt("IsSoundEffectsOn", isSoundEffectsOn ? 1 : 0);
        soundEffectsOffIcon.enabled = !isSoundEffectsOn;
    }

    public void StartSounds() {
        if (kittenMovement.isHiding) {
            PlayHidingSound();
        } else if (kittenMovement.isOnCatnip) {
            PlayCatnipSound();
        } else {
            PlayBGMSound();
        }
    }

    public void StopSounds() {
        StopBGMSound();
        StopHidingSound();
        StopCatnipSound();
    }

    public void HandleSoundsAfterResume() {
        StopSounds();
        StartSounds();
    }
}
