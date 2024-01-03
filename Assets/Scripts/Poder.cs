using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poder : MonoBehaviour
{
	public float speedPoder = -10f;

    void Start()
    {
    }
    void Update()
    {
        transform.Translate (new Vector3(1,0,0) * speedPoder * Time.deltaTime);
    }
}
