using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class uiManager : MonoBehaviour
{
	public Button[] buttons;
	public Button[] buttonsF;
	public TMPro.TextMeshProUGUI scoreText;
	bool gameOver;
	public static int score;
	public TMPro.TextMeshProUGUI record; 
	public TMPro.TextMeshProUGUI levelText;
	int level;
	private float timer;
	int enerMax = 100;
	int scoreMax = 999999;
	private int enerActual;
	public Image barras;
	public Image barraPocion;
	int barraPMax = 6;
	JPlayer jplayer;

	public static int pocion;

    void Start()
    {
		enerActual = enerMax;
		gameOver = false;
		score = 0;
		level = 1;
		pocion = 0;
		InvokeRepeating("scoreUpdate",1.0f,0.5f);
		InvokeRepeating("levelUpdate",100f,100f);
		InvokeRepeating("energiaUpdate",0.2f,0.2f);
		record.text = PlayerPrefs.GetInt("PuntajeRecord", 0).ToString();
    }

    void Update(){
		scoreText.text = ": " + score;
		levelText.text = ": " + level;
        if (score <= scoreMax){
			if (score >= 0){
				GameObject.Find("spawnerFish").SendMessage("ap");
			} 
			if (score >= 500){
				GameObject.Find("spawnA").SendMessage("enemA");
			}
			if (score >= 1000){
				GameObject.Find("spawnB").SendMessage("enemB");
			}
			if (score >= 2000){
				GameObject.Find("spawnC").SendMessage("enemC");
			}
			if (score >= 4000){
				GameObject.Find("spawnD").SendMessage("enemD");
			}
		}
        if (score >= scoreMax){
			score = scoreMax;
			finJuego();
		}
		barras.fillAmount = (float)enerActual / enerMax;
		barraPocion.fillAmount = (float)pocion / barraPMax;
    }
    public void Pause () {
		if (Time.timeScale ==1) {
			Time.timeScale = 0;
			GameObject.Find("AudioManager").SendMessage("terminar");
		}
	}
	public void Continue () {
		if (Time.timeScale == 0) {
			Time.timeScale = 1;
			GameObject.Find("AudioManager").SendMessage("continuarMusica");
		}
	}
    public void energiaUpdate(){
		if (Time.timeScale == 1){
			if (gameOver == false) {
			    if (enerActual >=1){
				    enerActual -= 1;
			    }
		    }
		}
	}
	public void sumarPocion(){
		if (pocion <= 5){
			pocion += 1;
		}
	}
    public void gameoverEnergia(){
		if (enerActual <= 0){
			gameOvered();
		}
	}
    void scoreUpdate () {
		if (gameOver == false) {
			if (score <= scoreMax){
				score += 1;
				if (score > PlayerPrefs.GetInt("PuntajeRecord", 0)){
					PlayerPrefs.SetInt("PuntajeRecord", score);
					record.text = score.ToString();
				}
			}
		}
	}
    void levelUpdate () {
		if (gameOver == false) {
			if (level <=99){
				level += 1;
			}
		}
	}
    public void barra(){
        if (gameOver == false){
			if (enerActual <= enerMax){
		    	enerActual +=  25;
			}
        }
	}
	public void comerP(){
		
	}
    public void gameOvered(){
		gameOver = true;
		GameObject.Find("AudioManager").SendMessage("terminar");
		GameObject.Find("AudioManager").SendMessage("over");

		foreach (Button button in buttons) {
			button.gameObject.SetActive(true);
		}
		jplayer=GameObject.FindGameObjectWithTag("Player").GetComponent<JPlayer>();
		jplayer.destruirse(gameObject);
	}
	void finJuego(){
		GameObject.Find("AudioManager").SendMessage("terminar");
		foreach (Button button in buttonsF) {
			button.gameObject.SetActive(true);
		}
	}
    public void eat(){
        if (gameOver == false){
            if (score <= scoreMax){
			    score += 15;
			    if (score > PlayerPrefs.GetInt("PuntajeRecord", 0)){
					PlayerPrefs.SetInt("PuntajeRecord", score);
					record.text = score.ToString();
			    }
		    } 
        }
	}
	public void bajar(){
        if (gameOver == false){
            enerActual -= 25;
        }
	}
	public void bajar2(){
        if (gameOver == false){
            enerActual -= 40;
        }
	}
    public void Replay(){
		Application.LoadLevel (Application.loadedLevel);
	}
    public void Menu(){
		Time.timeScale = 1;
		Application.LoadLevel ("Principal");
	}
    public void Exit(){
		Application.Quit ();
	}
}
