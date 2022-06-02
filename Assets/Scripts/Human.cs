using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : MonoBehaviour
{
    GameManagement gameManagement;
    KittenMovement kittenMovement;
    public GameObject kitten;

    // Update is called once per frame
    void Update()
    {
        if (!kittenMovement.isHiding) {
            gameManagement.GameOver();
        }
    }

    private void OnEnable() {
        gameManagement = GameObject.Find("GameManagement").GetComponent<GameManagement>();
        kittenMovement = GameObject.Find("Kitten").GetComponent<KittenMovement>();

        StartCoroutine(Disappear());
    }

    IEnumerator Disappear() {
        yield return new WaitForSeconds(5f);
        gameObject.SetActive(false);
    }
}
