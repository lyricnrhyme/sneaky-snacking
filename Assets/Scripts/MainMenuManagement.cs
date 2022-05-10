using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManagement : MonoBehaviour {
    public GameObject HowToPlayPanel;
    public GameObject ShopPanel;
    public GameObject CreditsPanel;

    public void NavigateToGamePlay () {
        SceneManager.LoadScene ("GamePlay");
    }

    public void ToggleHowToPlayPanel (bool isOpen) {
        HowToPlayPanel.SetActive (isOpen);
    }

    public void ToggleShopPanel (bool isOpen) {
        ShopPanel.SetActive (isOpen);
    }

    public void ToggleCreditsPanel (bool isOpen) {
        CreditsPanel.SetActive (isOpen);
    }

}