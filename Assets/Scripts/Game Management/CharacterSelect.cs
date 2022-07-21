using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelect : MonoBehaviour
{
    public Character[] characters;
    public Image[] selectCharacters;
    public Image[] howToPlayCharacters;
    int selectedCharacter;

    void Awake() {
        selectedCharacter = PlayerPrefs.GetInt("SelectedCharacter", 0);
        foreach (Character c in characters)
        {
            if (c.price == 0) {
                c.isUnlocked = true;
            } else {
                c.isUnlocked = PlayerPrefs.GetInt(c.name, 0) == 0 ? false : true;
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
