using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnIn : MonoBehaviour
{
    public GameObject[] invensible;
    int invensibleNo;
    public float maxPos = 6f;
    public float delayTimer = 2f;
    float timer;

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0){
            Vector3 invensiblePos = new Vector3(transform.position.x,Random.Range(-4.6f,4.6f),transform.position.y);
            invensibleNo = Random.Range (0,1);
            Instantiate (invensible[invensibleNo], invensiblePos,transform.rotation);
			timer = delayTimer;
        }
    }
}
