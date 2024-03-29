using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour
{
    public GameObject kitten;
    bool didDamage = false;
    GameManager gameManager;
    KittenMovement kittenMovement;
    Animator kittenMovementAnim;
    AudioManager audioManager;

    void Start() {
        kittenMovementAnim = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<Animator>();
        audioManager = GameObject.Find ("AudioManager").GetComponent<AudioManager> ();
    }

    // Update is called once per frame
    void Update()
    {
        if (!kittenMovement.isHiding && !gameManager.gameOver && !didDamage)
        {
            audioManager.PlayScaredSound();
            kittenMovementAnim.SetTrigger("Scared");
            gameManager.ReduceLife(3);
            didDamage = true;
            if (gameManager.lives == 0) gameManager.GameOver();
        }
    }

    private void OnEnable()
    {
        didDamage = false;
        gameManager =
            GameObject.Find("GameManager").GetComponent<GameManager>();
        kittenMovement =
            GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<KittenMovement>();

        StartCoroutine(Disappear());
    }

    IEnumerator Disappear()
    {
        yield return new WaitForSeconds(5f);
        gameObject.SetActive(false);
    }
}
