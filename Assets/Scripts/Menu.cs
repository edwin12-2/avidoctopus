using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private int index;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void option(){
		Application.LoadLevel ("Options");
	}
    public void IniciarJuego(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Exit(){
		Application.Quit ();
	}
}
