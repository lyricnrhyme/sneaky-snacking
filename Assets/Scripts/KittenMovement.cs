using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KittenMovement : MonoBehaviour {
    public int moveSpeed;
    public float maxPos;

    // Start is called before the first frame update
    void Start () {

    }

    // Update is called once per frame
    void Update () {
        Move ();
    }

    void Move () {
        if (Input.GetKey ("a") || Input.GetKey ("left")) {
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        } else if (Input.GetKey ("d") || Input.GetKey ("right")) {
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;
        }
        float xPos = Mathf.Clamp (transform.position.x, -maxPos, maxPos);
        transform.position = new Vector3 (xPos, transform.position.y, transform.position.z);
    }
}