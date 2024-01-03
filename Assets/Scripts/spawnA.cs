using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnA : MonoBehaviour
{
	public GameObject[] enA;
	int enNo;
	public float maxPos = 9f;
	public float delayTimer = 2f;
	float timer;
    
    void Start()
    {
		timer = delayTimer;
    }

    //void Update()
    public void enemA()
    {
        timer -= Time.deltaTime;	
		if (timer <= 0) {
			Vector3 enPos = new Vector3(transform.position.x,Random.Range(-4.7f,4.7f),transform.position.y);
			enNo = Random.Range (0,5);
			Instantiate (enA[enNo], enPos, transform.rotation);	
			timer = delayTimer;
		}
    }
}
