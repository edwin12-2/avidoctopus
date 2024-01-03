using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscuro : MonoBehaviour
{
    public GameObject quad;
    public GameObject quad2;

    void Update()
    {
    if (uiManager.score >= 2000){
        //GetComponent<SpriteRenderer>().color = Color.blue;
        GetComponent<SpriteRenderer>().color = new Color(0f,0f,0f,0.2f);
    }
        if (uiManager.score >= 4000){
        //GetComponent<SpriteRenderer>().color = Color.blue;
        GetComponent<SpriteRenderer>().color = new Color(0f,0f,0f,0.3f);
        quad.gameObject.SetActive(false);
        quad2.gameObject.SetActive(true);
    }
    }
}
