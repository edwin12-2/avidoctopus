using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fish : MonoBehaviour
{
	public float speed = -10f;
  private Animator anim;
    public GameObject particulas;

    void Start()
    {
 		  anim = gameObject.GetComponent<Animator>();

    }
  void Update()
    {
		transform.Translate (new Vector3(1,0,0) * speed * Time.deltaTime);
    }
  void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "Player") {
			GameObject.Find("uiManager").SendMessage("eat");
      Destroy(gameObject);
		}
    if (col.gameObject.tag == "Ataquet") {
			GameObject.Find("AudioManager").SendMessage("sonar");
			GameObject.Find("uiManager").SendMessage("eat");
      Destroy(gameObject);
		}
	}
}
