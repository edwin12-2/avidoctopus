using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverObjeto : MonoBehaviour
{
    private bool dragging = false;
    private Vector3 offset;
    public Transform otro;
    public float Speed = 1f;

    void FixedUpdate()
    {
        if (MenuO.nMove == 2){
            if (dragging){
                otro.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
            }
            transform.position = new Vector3(
                Mathf.Clamp(transform.position.x, -8.5f, 6f),
                Mathf.Clamp(transform.position.y, -4.2f, 4.2f),
                transform.position.z
            );
        }
    }
    private void OnMouseDown() {
        offset = otro.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        dragging = true;    
    }
    private void OnMouseUp()
    {
        dragging = false;
    }
}
