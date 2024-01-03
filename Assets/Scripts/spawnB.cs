using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnB : MonoBehaviour
{
	public GameObject[] enB;
	int enNo;
	public float maxPos = 9f;
	public float delayTimer = 2f;
	float timer;    
    public void enemB()
    {
        timer -= Time.deltaTime;	
		if (timer <= 0) {
			Vector3 enPos = new Vector3(transform.position.x,Random.Range(-4.7f,4.7f),transform.position.y);
			enNo = Random.Range (0,2);
			Instantiate (enB[enNo], enPos, transform.rotation);	
			timer = delayTimer;
		}
    }
}
