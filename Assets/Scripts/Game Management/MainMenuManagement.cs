using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManagement : MonoBehaviour {
    public GameObject howToPlayPanel;
    public GameObject shopPanel;
    public GameObject creditsPanel;

    public void NavigateToGamePlay () {
        SceneManager.LoadScene ("GamePlay");
    }

    public void ToggleHowToPlayPanel (bool isOpen) {
        howToPlayPanel.SetActive (isOpen);
    }

    public void ToggleShopPanel (bool isOpen) {
        shopPanel.SetActive (isOpen);
    }

    public void ToggleCreditsPanel (bool isOpen) {
        creditsPanel.SetActive (isOpen);
    }

}