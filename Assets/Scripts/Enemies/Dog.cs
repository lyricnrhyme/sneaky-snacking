using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour
{
    GameManager gameManager;

    KittenMovement kittenMovement;

    public GameObject kitten;

    bool didDamage = false;

    Animator kittenMovementAnim;

    void Start() {
        kittenMovementAnim = GameObject.Find("Kitten").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!kittenMovement.isHiding && !gameManager.gameOver && !didDamage)
        {
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
            GameObject.Find("Kitten").GetComponent<KittenMovement>();

        StartCoroutine(Disappear());
    }

    IEnumerator Disappear()
    {
        yield return new WaitForSeconds(5f);
        gameObject.SetActive(false);
    }
}
