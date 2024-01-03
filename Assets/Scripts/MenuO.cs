using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuO : MonoBehaviour
{
  public static int nMove = 1;
    // Start is called before the first frame update
    void Start()
    {
        nMove = 1;
    }

    public void regresar(){
		Application.LoadLevel ("Principal");
	}
   public void bJostick(){
		nMove = 1;
	}

   public void bDrag(){
		nMove = 2;
	}
}
