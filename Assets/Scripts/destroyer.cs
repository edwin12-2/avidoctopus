using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyer : MonoBehaviour
{
	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "Fish") {
			Destroy (col.gameObject);
		}
		if (col.gameObject.tag == "Enemy") {
			Destroy (col.gameObject);
		}
		if (col.gameObject.tag == "Trampa") {
			Destroy (col.gameObject);
		}
		if (col.gameObject.tag == "Invensible") {
			Destroy (col.gameObject);
		}
	}
}
