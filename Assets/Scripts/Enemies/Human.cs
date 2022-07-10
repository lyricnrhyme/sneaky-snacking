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

    // Update is called once per frame
    void Update()
    {
        if (!kittenMovement.isHiding && !gameManager.gameOver) {
            StartCoroutine(CaughtPlayer());
        }
    }

    private void OnEnable() {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        kittenMovement = GameObject.Find("Kitten").GetComponent<KittenMovement>();
        itemSpawner = GameObject.Find ("ItemSpawner").GetComponent<ItemSpawner> ();
        kittenMovementAnim = GameObject.Find("Kitten").GetComponent<Animator>();

        StartCoroutine(Disappear());
    }

    IEnumerator Disappear() {
        yield return new WaitForSeconds(5f);
        gameObject.SetActive(false);
    }

    IEnumerator CaughtPlayer() {
        itemSpawner.DestroyAllItems ();
        kittenMovementAnim.SetTrigger("Caught");
        yield return new WaitForSeconds(2f);
        gameManager.GameOver();
    }
}
