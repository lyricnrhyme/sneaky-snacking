using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KittenMovement : MonoBehaviour {
    int moveSpeed = 18;
    int baseMoveSpeed = 18;
    float secondsLeft = 10f;
    public float maxPos;
    public bool isOnCatnip = false;
    public bool isHiding;
    bool invertedControls = false;
    GameManager gameManager;
    ItemSpawner itemSpawner;
    public GameObject kitten;
    Image hidingTimer;
    AudioManager audioManager;
    Animator anim;

    // Start is called before the first frame update
    void Start () {
        gameManager = GameObject.Find ("GameManager").GetComponent<GameManager> ();
        itemSpawner = GameObject.Find ("ItemSpawner").GetComponent<ItemSpawner> ();
        anim = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<Animator>();
        audioManager = GameObject.Find ("AudioManager").GetComponent<AudioManager> ();
        hidingTimer = GameObject.Find("HidingTimer").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update () {
        if (!gameManager.gameOver) {
            if (!isHiding) {
                Move ();
            }
            Hide();
        }

        if (isHiding && secondsLeft > 0) {
            secondsLeft -= Time.deltaTime;
            hidingTimer.fillAmount = secondsLeft / 10f;
        } else if (isHiding) {
            UnHide();
        }
    }

    void Hide() {
        if (Input.GetKeyDown ("w") || Input.GetKeyDown ("up")) {
            hidingTimer.enabled = true;
            isHiding = true;
            kitten.transform.position = new Vector3 (7.53f, -1.73f, 0f);
            itemSpawner.DestroyAllItems ();
            audioManager.PauseBGMSound();
            audioManager.StopCatnipSound();
            audioManager.PlayHidingSound();
        } else if (Input.GetKeyDown ("s") || Input.GetKeyDown ("down")) {
            UnHide();
        }
        anim.SetBool("Hiding", isHiding);
    }

    void UnHide() {
            hidingTimer.enabled = false;
            isHiding = false;
            kitten.transform.position = new Vector3 (0f, -3.2118f, 0f);
            StartCoroutine (itemSpawner.SpawnItem ());
            audioManager.StopHidingSound();
            if (isOnCatnip) {
                audioManager.PlayCatnipSound();
            } else {
                audioManager.PlayBGMSound();
            }
            secondsLeft = 10f;
    }

    void Move () {
        if (Input.GetKey ("a") || Input.GetKey ("left")) {
            Vector3 direction = invertedControls ? Vector3.right : Vector3.left;
            transform.position += direction * moveSpeed * Time.deltaTime;
        } else if (Input.GetKey ("d") || Input.GetKey ("right")) {
            Vector3 direction = invertedControls ? Vector3.left : Vector3.right;
            transform.position += direction * moveSpeed * Time.deltaTime;
        }
        float xPos = Mathf.Clamp (transform.position.x, -maxPos, maxPos);
        transform.position = new Vector3 (xPos, transform.position.y, transform.position.z);
    }

    public void UpdateSpeed(bool isFaster) {
        if (isFaster) {
            StartCoroutine(DoubleSpeed());
        } else {
            StartCoroutine(ReduceSpeed());
        }
    }

    public void TriggerInvertControls() {
        StartCoroutine(InvertControls());
    }

    public IEnumerator ReduceSpeed() {
        audioManager.PlayBreadSound();
        anim.SetBool("SlowDown", true);
        moveSpeed = 9;
        yield return new WaitForSeconds(5f);
        anim.SetBool("SlowDown", false);
        moveSpeed = baseMoveSpeed;
    }

    public IEnumerator DoubleSpeed () {
        StartCatnipEffect();
        moveSpeed = 30;
        yield return new WaitForSeconds (7f);
        anim.SetBool("Catnip", false);
        moveSpeed = baseMoveSpeed;
        ResumeSoundAfterCatnip();
    }

    public IEnumerator InvertControls () {
        StartCatnipEffect();
        invertedControls = true;
        yield return new WaitForSeconds (8f);
        anim.SetBool("Catnip", false);
        invertedControls = false;
        ResumeSoundAfterCatnip();
    }

    void StartCatnipEffect() {
        isOnCatnip = true;
        audioManager.PauseBGMSound();
        audioManager.PlayCatnipSound();
        anim.SetBool("Catnip", true);
    }

    void ResumeSoundAfterCatnip() {
        if (isHiding) {
            audioManager.PlayHidingSound();
        } else {
            audioManager.PlayBGMSound();
        }
        audioManager.StopCatnipSound();
        isOnCatnip = false;
    }
}