using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ataque : MonoBehaviour
{
    private Animator anim;
	JPlayer jplayer;

    private bool dragging = false;
    private Vector3 offset;

    void Start()
    {
 		anim = gameObject.GetComponent<Animator>();
    }
    void Update()
    {
    }
    private void OnMouseDown() {
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        dragging = true;    
    }
    private void OnMouseUp()
    {
        dragging = false;
    }
    void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "Enemy") {
			Destroy(col.gameObject);
			GameObject.Find("AudioManager").SendMessage("sonar");
			GameObject.Find("uiManager").SendMessage("eat");
            jplayer=GameObject.FindGameObjectWithTag("Player").GetComponent<JPlayer>();
		    jplayer.emitirP(gameObject);
		}
        if (col.gameObject.tag == "Fish") {
			Destroy(col.gameObject);
			GameObject.Find("AudioManager").SendMessage("sonar");
			GameObject.Find("uiManager").SendMessage("barra");
            jplayer=GameObject.FindGameObjectWithTag("Player").GetComponent<JPlayer>();
		    jplayer.emitirP(gameObject);
		}
        if (col.gameObject.tag == "Trampa") {
            GameObject.Find("AudioManager").SendMessage("sonarFall");
            GameObject.Find("uiManager").SendMessage("bajar");
            jplayer=GameObject.FindGameObjectWithTag("Player").GetComponent<JPlayer>();
		    jplayer.emitirP(gameObject);
        }
        if (col.gameObject.tag == "Invensible") {
            GameObject.Find("uiManager").SendMessage("sumarPocion");
            GameObject.Find("AudioManager").SendMessage("audioPocion");
            Destroy(col.gameObject);
		}
	}
    public void activarPoder(GameObject g){
        anim.Play("atacar");
    }

}
