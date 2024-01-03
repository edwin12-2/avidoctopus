using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
	public float speedEnemy = -10f;

    void Start()
    {
    }
    void Update()
    {
        transform.Translate (new Vector3(1,0,0) * speedEnemy * Time.deltaTime);
    }
    void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "Player") {
			//Destroy (col.gameObject);
		}
	}
}
