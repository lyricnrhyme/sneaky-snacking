using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanWarning : MonoBehaviour
{
    public GameObject human;

    private void OnEnable() {
        StartCoroutine(ShowHuman());
    }

    IEnumerator ShowHuman() {
        yield return new WaitForSeconds(3f);
        human.SetActive(true);
        gameObject.SetActive(false);
    }
}
