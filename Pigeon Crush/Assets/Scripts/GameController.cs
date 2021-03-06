﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class GameController : MonoBehaviour {

	public Transform[] spawnPoints;
	public GameObject[] birds;

	public GameObject[] blue;
	public GameObject[] red;
	public GameObject[] green;
	public GameObject[] yellow;
	public GameObject[] gray;

	public GameObject whiteFlash;
	public GameObject gameOver;
	public GameObject restartButton;
	public GameObject displayHighScore;
	public Pause pauseButton;
	public MusicController musicButton;

	public bool rip;

	public AudioSource sfx;
	public AudioClip wrong;

	public string color;

	int spawn_num;
	int birds_num;
	int blue_num;
	int red_num;
	int green_num;
	int yellow_num;
	int gray_num;
	public bool started = false;

	public float speed;
	public Text text;
	public Text bestscore;

	float colorTime;

	public float waitingForNextSpawn;
	public float theCountdown;
	public float stateTimer;
	public float resetTimer;
	public int score;
	public int highscore;

	public enum States{blue,red,green,yellow,gray,none};
	public States currentState;

	void Start(){ 

		highscore = PlayerPrefs.GetInt ("highscore");
		sfx = GetComponent<AudioSource> ();
		pauseButton = FindObjectOfType<Pause> ();
		musicButton = FindObjectOfType<MusicController> ();

		StateChange();

		Time.timeScale = 1f;

		//Current Color texts
		blue[blue_num].SetActive (false);
		red[red_num].SetActive (false);
		green[green_num].SetActive (false);
		yellow[yellow_num].SetActive (false);
		gray[gray_num].SetActive (false);

		//GameOver Elements
		displayHighScore.SetActive (false);
		whiteFlash.SetActive (false);
		gameOver.SetActive (false);
		restartButton.SetActive (false);

		//Change current state, which color to tap on, every 10 seconds
		InvokeRepeating ("StateChange", 10f, 10f);
	}
		
	//Changing color function, changes color randomly from a range of 5 colors
	void StateChange(){

		currentState = (States)Random.Range(0,5);
		started = false;
	}
		

	void Update(){

		//Text elements on screen, what to display
		text.text = "" + score;
		bestscore.text = "Best: " + highscore;

		//Timers
		theCountdown -= Time.deltaTime;
		stateTimer -= Time.deltaTime;

		Spawning ();

		if (rip == true) {
			StartCoroutine ("DeathFlash");
		}
			
		if (currentState == States.blue && started == false) {
			StartCoroutine ("Blue");
			color = "blue";
			started = true;
		} else if (currentState == States.red && started == false) {
			StartCoroutine ("Red");
			color = "red";
			started = true;
		} else if (currentState == States.green && started == false) {
			StartCoroutine ("Green");
			color = "green";
			started = true;
		} else if (currentState == States.yellow && started == false) {
			StartCoroutine ("Yellow");
			color = "yellow";
			started = true;
		} else if (currentState == States.gray && started == false) {
			StartCoroutine ("Gray");
			color = "gray";
			started = true;
		} else if (currentState == States.none) {
			color = "none";
			text.text = "Score: " + score;
			whiteFlash.SetActive (false);

		}

		if (score > highscore) {
			highscore = score;
			PlayerPrefs.SetInt ("highscore", highscore);
			PlayerPrefs.Save ();
		}


		if (currentState!=States.blue) {
			blue_num = Random.Range (0, 3);
		}
		if (currentState!=States.red) {
			red_num = Random.Range (0, 3);
		}
		if (currentState!=States.green) {
			green_num = Random.Range (0, 3);
		}
		if (currentState!=States.yellow) {
			yellow_num = Random.Range (0, 3);
		}
		if (currentState!=States.gray) {
			gray_num = Random.Range (0, 3);
		}
	}

	public void Spawning(){
		if (theCountdown <= 0) {
			int spawn_num = Random.Range(0,4);
			int birds_num = Random.Range(0,5);


			Instantiate(birds [birds_num], spawnPoints [spawn_num].position, spawnPoints [spawn_num].rotation);
			theCountdown = waitingForNextSpawn;

			if (waitingForNextSpawn > 0.5f) {
				waitingForNextSpawn -= 0.1f;
			}
		}
	}
		

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Blue Pigeon" && currentState == States.blue) {
			Debug.Log ("GameOver");
			rip = true;
			StartCoroutine ("DeathFlash");
			text.rectTransform.anchoredPosition = new Vector2 (0f, -48f);
		} else if (other.tag == "Red Pigeon" && currentState == States.red) {
			Debug.Log ("GameOver");
			rip = true;
			StartCoroutine ("DeathFlash");
			text.rectTransform.anchoredPosition = new Vector2 (0f, -48f);
		} else if (other.tag == "Green Pigeon" && currentState == States.green) {
			Debug.Log ("GameOver");
			rip = true;
			StartCoroutine ("DeathFlash");
			text.rectTransform.anchoredPosition = new Vector2 (0f, -48f);
		} else if (other.tag == "Yellow Pigeon" && currentState == States.yellow) {
			Debug.Log ("GameOver");
			rip = true;
			StartCoroutine ("DeathFlash");
			text.rectTransform.anchoredPosition = new Vector2 (0f, -48f);
		} else if (other.tag == "Grey Pigeon" && currentState == States.gray) {
			Debug.Log ("GameOver");
			rip = true;
			StartCoroutine ("DeathFlash");
			text.rectTransform.anchoredPosition = new Vector2 (0f, -48f);
		} 
	}
		

	IEnumerator Blue(){
		blue[blue_num].SetActive (true);
		yield return new WaitForSeconds (1f);
		blue[blue_num].SetActive (false);
	}

	IEnumerator Red(){
		red[red_num].SetActive (true);
		yield return new WaitForSeconds (1f);
		red[red_num].SetActive (false);
	}

	IEnumerator Green(){
		green[green_num].SetActive (true);
		yield return new WaitForSeconds (1f);
		green[green_num].SetActive (false);
	}

	IEnumerator Yellow(){
		yellow[yellow_num].SetActive (true);
		yield return new WaitForSeconds (1f);
		yellow[yellow_num].SetActive (false);
	}

	IEnumerator Gray(){
		gray[gray_num].SetActive (true);
		yield return new WaitForSeconds (1f);
		gray[gray_num].SetActive (false);
	}

	IEnumerator DeathFlash(){
		whiteFlash.SetActive (true);
		yield return new WaitForSeconds (0.1f);
		whiteFlash.SetActive (false);
		currentState = States.none;
		gameOver.SetActive (true);
		restartButton.SetActive (true);
		sfx.PlayOneShot(wrong);
		pauseButton.GetComponent<Renderer> ().enabled = false;
		musicButton.GetComponent<Renderer> ().enabled = false;
		text.text = "Score: " + score;
		Time.timeScale = 0f;
		displayHighScore.SetActive (true);
	}
}
