using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : MonoBehaviour
{
    GameManager gameManager;
    KittenMovement kittenMovement;
    ItemSpawner itemSpawner;
    Animator kittenMovementAnim;
    public GameObject kitten;
    AudioManager audioManager;

    // Update is called once per frame
    void Update()
    {
        if (!kittenMovement.isHiding && !gameManager.gameOver) {
            StartCoroutine(CaughtPlayer());
        }
    }

    private void OnEnable() {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        kittenMovement = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<KittenMovement>();
        itemSpawner = GameObject.Find ("ItemSpawner").GetComponent<ItemSpawner> ();
        kittenMovementAnim = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<Animator>();
        audioManager = GameObject.Find ("AudioManager").GetComponent<AudioManager> ();
        StartCoroutine(Disappear());
    }

    IEnumerator Disappear() {
        yield return new WaitForSeconds(5f);
        gameObject.SetActive(false);
    }

    IEnumerator CaughtPlayer() {
        gameManager.gameOver = true;
        itemSpawner.DestroyAllItems ();
        kittenMovementAnim.SetTrigger("Caught");
        audioManager.PlayCaughtSound();
        yield return new WaitForSeconds(2f);
        gameManager.GameOver();
    }
}
