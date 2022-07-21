using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelect : MonoBehaviour
{
    public Character[] characters;
    public Pronoun[] pronouns;
    public Sprite[] selectCharacters;
    public Sprite[] howToPlayCharacters;
    public Image selectImage;
    public Image howToPlayImage;
    public Text characterInfoText;
    public Text howToPlayText;
    public Text selectCharacterText;
    public Text overallPointsText;
    public Button selectCharacterButton;
    int selectedCharacter;
    int currentCharacter;
    int overallPoints;

    void Awake() {
        selectedCharacter = PlayerPrefs.GetInt("SelectedCharacter", 0);
        overallPoints = PlayerPrefs.GetInt ("OverallPoints", 0);
        UpdateOverallPointsText();
        currentCharacter = selectedCharacter;
        foreach (Character c in characters)
        {
            if (c.price == 0) {
                c.isUnlocked = true;
            } else {
                c.isUnlocked = PlayerPrefs.GetInt(c.name, 0) == 0 ? false : true;
            }
        }

        UpdateSelectedCharacterUI();
    }

    public void NextCharacter() {
        currentCharacter++;
        if (currentCharacter >= characters.Length) currentCharacter = 0;
        UpdateCurrentCharacterUI();
    }

    public void PreviousCharacter() {
        currentCharacter--;
        if (currentCharacter < 0) currentCharacter = characters.Length - 1;
        UpdateCurrentCharacterUI();
    }

    public void UpdateCurrentCharacterUI() {
        selectImage.sprite = selectCharacters[currentCharacter];
        characterInfoText.text = $"Name: {characters[currentCharacter].name}\n Price: {characters[currentCharacter].price}pts";
        UpdateSelectButtonUI();
    }

    public void UpdateSelectedCharacterUI() {
        UpdateCurrentCharacterUI();
        howToPlayImage.sprite = howToPlayCharacters[selectedCharacter];
        UpdateHowToPlayText();
    }

    public void UpdateHowToPlayText() {
        string catName = characters[selectedCharacter].name;
        Pronoun catPronouns = pronouns[characters[selectedCharacter].pronouns];
        howToPlayText.text = $"HOW TO PLAY: {catName} the cat LOVES food, and {catPronouns.pronoun} doesn't want to wait for {catPronouns.possessive} dinner (HMP!) Help {catName} rummage the kitchen to reach {catPronouns.possessive} chonky potential! \n \n Catch the falling food while avoiding anything that may spook {catName}. Make sure to hide from the doggo and hooman or it's game over!";
    }

    public void SelectCharacter() {
        if (characters[currentCharacter].price > overallPoints && !characters[currentCharacter].isUnlocked) return;
        selectedCharacter = currentCharacter;
        PlayerPrefs.SetInt("SelectedCharacter", selectedCharacter);

        if (!characters[currentCharacter].isUnlocked) {
            PlayerPrefs.SetInt(characters[selectedCharacter].name, 1);
            characters[selectedCharacter].isUnlocked = true;

            overallPoints -= characters[selectedCharacter].price;
            PlayerPrefs.SetInt("OverallPoints", overallPoints);
            UpdateOverallPointsText();
        }

        UpdateSelectedCharacterUI();
    }

    public void UpdateSelectButtonUI() {
        if (characters[currentCharacter].isUnlocked) {
            selectCharacterButton.interactable = currentCharacter == selectedCharacter ? false : true;
            selectCharacterText.text = currentCharacter == selectedCharacter ? "Selected" : "Select";
        } else {
            selectCharacterButton.interactable = characters[currentCharacter].price > overallPoints ? false : true;
            selectCharacterText.text = "Unlock";
        }
    }

    public void UpdateOverallPointsText() {
        overallPointsText.text = "Points: " + overallPoints;
    }
}
