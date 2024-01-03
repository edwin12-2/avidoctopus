using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JPlayer : MonoBehaviour
{
	public Joystick movementJoystick;
	public float playerSpeed;
	private Rigidbody2D rb;
    private float anchoP;
    private float alturaP;

    public Transform jugador;
    public GameObject particulas;
    public GameObject particulasFall;
    private Animator anim;
    Ataque ataque;

    public GameObject moveO;
    private bool dragging = false;
    private Vector3 offset;

    void Start()
    {
 		rb = GetComponent<Rigidbody2D>();
 		anim = gameObject.GetComponent<Animator>();
        anchoP = Screen.width / Screen.width * 8.7f;
        alturaP = Screen.height / Screen.height * 4.2f;
    }
    void Update()
    {
		GameObject.Find("uiManager").SendMessage("gameoverEnergia");
        transform.position = new Vector2(
            Mathf.Clamp(transform.position.x,-anchoP,anchoP),
            Mathf.Clamp(transform.position.y,-alturaP,alturaP));
        if (MenuO.nMove == 2){
            moveO.gameObject.SetActive(false);
        }
    }
    void FixedUpdate()
	{
        if(movementJoystick.joystickVec.y != 0)
        {
            rb.velocity = new Vector2(
            movementJoystick.joystickVec.x * playerSpeed, 
            movementJoystick.joystickVec.y * playerSpeed);
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
	}
    private void OnMouseDown() {
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        dragging = true;    
    }
    private void OnMouseUp()
    {
        dragging = false;
    }
	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "Fish") {
			GameObject.Find("uiManager").SendMessage("barra");
			GameObject.Find("AudioManager").SendMessage("sonar");
            Instantiate(particulas, jugador.position, Quaternion.identity);

		}
        if (col.gameObject.tag == "Enemy") {
            GameObject.Find("AudioManager").SendMessage("sonarFall");
            Instantiate(particulas, jugador.position, Quaternion.identity);
            GameObject.Find("uiManager").SendMessage("bajar");
        }
        if (col.gameObject.tag == "Invensible") {
            GameObject.Find("uiManager").SendMessage("sumarPocion");
            GameObject.Find("AudioManager").SendMessage("audioPocion");
            Destroy(col.gameObject);
		}
        if (col.gameObject.tag == "Trampa") {
            GameObject.Find("AudioManager").SendMessage("sonarFall");
            Instantiate(particulas, jugador.position, Quaternion.identity);
            GameObject.Find("uiManager").SendMessage("bajar");
        }
        if (col.gameObject.tag == "PuEn") {
            GameObject.Find("AudioManager").SendMessage("sonarFall");
            Instantiate(particulas, jugador.position, Quaternion.identity);
            GameObject.Find("uiManager").SendMessage("bajar2");
        }
	}
    public void destruirse(GameObject g){
        Instantiate(particulasFall, jugador.position, Quaternion.identity);
        Destroy(gameObject);
    }
    public void emitirP(GameObject g){
        Instantiate(particulas, jugador.position, Quaternion.identity);
    }
    public void crecer(){
        if (uiManager.pocion >= 1){
            uiManager.pocion -= 1;
            anim.Play("conPoder");
            ataque=GameObject.FindGameObjectWithTag("Ataquet").GetComponent<Ataque>();
            ataque.activarPoder(gameObject);
        }
    }
}
