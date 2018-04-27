using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card_Test : MonoBehaviour {

    private Vector2 origPos;
    public string cardName;
    public bool returnToOrigin = false; // if true, snaps to world origin

    void Start() {
        origPos = transform.position;
    }

    void OnMouseUp() {
        if (returnToOrigin)
            transform.position = origPos;
    }
}
