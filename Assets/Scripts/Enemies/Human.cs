using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : MonoBehaviour
{
    GameManager gameManager;
    KittenMovement kittenMovement;
    public GameObject kitten;

    // Update is called once per frame
    void Update()
    {
        if (!kittenMovement.isHiding) {
            gameManager.GameOver();
        }
    }

    private void OnEnable() {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        kittenMovement = GameObject.Find("Kitten").GetComponent<KittenMovement>();

        StartCoroutine(Disappear());
    }

    IEnumerator Disappear() {
        yield return new WaitForSeconds(5f);
        gameObject.SetActive(false);
    }
}
