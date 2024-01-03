using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerFish : MonoBehaviour
{
	public GameObject[] en;
	int enNo;
	public float maxPos = 9f;
	public float delayTimer = 2f;
	float timer;
    
    void Start()
    {
		timer = delayTimer;
    }

    public void ap()
    {
        timer -= Time.deltaTime;	
		if (timer <= 0) {
			Vector3 enPos = new Vector3(transform.position.x,Random.Range(-4.6f,4.6f),transform.position.y);
			enNo = Random.Range (0,5);
			Instantiate (en[enNo], enPos, transform.rotation);	
			timer = delayTimer;
		}
    }
}
