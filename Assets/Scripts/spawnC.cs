using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnC : MonoBehaviour
{
    public GameObject[] enC;
    int encNo;
    public float maxPos = 7f;
    public float delayTimer = 2f;
    float timer;

    public void enemC()
    {
        timer -= Time.deltaTime;
        if (timer <= 0){
            Vector3 encPos = new Vector3(transform.position.x,Random.Range(-4.8f,4.8f),transform.position.y);
            encNo = Random.Range (0,1);
            Instantiate (enC[encNo], encPos,transform.rotation);
			timer = delayTimer;
        }
    }

}
