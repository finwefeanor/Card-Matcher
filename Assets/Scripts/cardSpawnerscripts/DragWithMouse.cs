using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragWithMouse : MonoBehaviour {

    private Vector3 offset;

    // dont forget the box collider
    void OnMouseDown() {
        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
        offset = transform.position - Camera.main.ScreenToWorldPoint(mousePos);
    }

    void OnMouseDrag() {
        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
        transform.position = Camera.main.ScreenToWorldPoint(mousePos) + offset;
    }
}
