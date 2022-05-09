using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoundaryLine : MonoBehaviour {
    public Text livesText;
    // Start is called before the first frame update
    void Start () {

    }

    // Update is called once per frame
    void Update () {

    }

    void OnCollisionEnter2D (Collision2D other) {
        GameManagement.lives--;
        livesText.text = "Lives: " + GameManagement.lives;
        Destroy (other.gameObject);
    }
}