using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnD : MonoBehaviour
{
    public GameObject[] enC;
    int encNo;
    public float maxPos = 7f;
    public float delayTimer = 2f;
    float timer;

    public void enemD()
    {
        timer -= Time.deltaTime;
        if (timer <= 0){
            Vector3 encPos = new Vector3(transform.position.x,Random.Range(-4.8f,4.8f),transform.position.y);
            encNo = Random.Range (0,2);
            Instantiate (enC[encNo], encPos,transform.rotation);
			timer = delayTimer;
        }
    }

}
