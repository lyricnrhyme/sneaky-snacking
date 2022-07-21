using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterManager : MonoBehaviour
{
    public GameObject[] kittenPlayers;
    public Sprite[] pauseSprites;
    public Sprite[] gameOverSprites;
    public Sprite[] winSprites;
    public Image pauseImage;
    public Image gameOverImage;
    public Image winImage;
    int selectedCharacter;

    // Start is called before the first frame update
    void Start()
    {
        // Get playerprefs here after testing
        selectedCharacter = PlayerPrefs.GetInt("SelectedCharacter", 0);
        Instantiate(kittenPlayers[selectedCharacter], new Vector3(0f, -3.02f, 0f), Quaternion.identity);
        pauseImage.sprite = pauseSprites[selectedCharacter];
        gameOverImage.sprite = gameOverSprites[selectedCharacter];
        winImage.sprite = winSprites[selectedCharacter];
    }
}
