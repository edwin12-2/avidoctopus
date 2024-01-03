using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
	public AudioSource fishSound;
	public AudioSource fallSound;
	public AudioSource terminarSound;
	public AudioSource pocionSound;
	public AudioSource overSound;
    
    public void sonar(){
		fishSound.Play();
	}
	public void sonarFall(){
		fallSound.Play();
	}
	public void terminar(){
		terminarSound.Stop();
	}
	public void continuarMusica(){
		terminarSound.Play();
	}
	public void audioPocion(){
		pocionSound.Play();
	}
	public void over(){
		overSound.Play();
	}
}
