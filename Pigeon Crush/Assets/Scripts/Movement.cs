using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour {

	public float timeBeforeGone;
	public Animator Anim;
	bool entered;
	public GameController score;
	public GameObject feathers;



	void Start () {
		score = FindObjectOfType<GameController>();

	}


	void Update () {

		GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, score.speed);


		if (score.color == "blue") {
			if (Input.GetMouseButtonDown (0) && entered == true && tag == "Blue Pigeon") {
				Death ();


			} else if (Input.GetMouseButtonDown (0) && entered == true && tag != "Blue Pigeon") {
				Debug.Log ("Nope");
				score.rip = true;
				score.whiteFlash.SetActive (false);
				score.text.rectTransform.anchoredPosition = new Vector2 (0f, -48f);

			}
		}
			
		if (score.color == "red") {
			if (Input.GetMouseButtonDown (0) && entered == true && tag == "Red Pigeon") {
				Death ();
			} else if (Input.GetMouseButtonDown (0) && entered == true && tag != "Red Pigeon") {
				Debug.Log ("Nope");
				//Time.timeScale = 0f;
				score.rip = true;
				score.whiteFlash.SetActive (false);
				score.text.rectTransform.anchoredPosition = new Vector2 (0f, -48f);
			}
		}

		if (score.color == "green") {
			if (Input.GetMouseButtonDown (0) && entered == true && tag == "Green Pigeon") {
				Death ();
			} else if (Input.GetMouseButtonDown (0) && entered == true && tag != "Green Pigeon") {
				Debug.Log ("Nope");
				//Time.timeScale = 0f;
				score.rip = true;
				score.whiteFlash.SetActive (false);
				score.text.rectTransform.anchoredPosition = new Vector2 (0f, -48f);
			}
		}

		if (score.color == "yellow") {
			if (Input.GetMouseButtonDown (0) && entered == true && tag == "Yellow Pigeon") {
				Death ();
			} else if (Input.GetMouseButtonDown (0) && entered == true && tag != "Yellow Pigeon") {
				Debug.Log ("Nope");
				//Time.timeScale = 0f;
				score.rip = true;
				score.whiteFlash.SetActive (false);
				score.text.rectTransform.anchoredPosition = new Vector2 (0f, -48f);
			}
		}

		if (score.color == "gray") {
			if (Input.GetMouseButtonDown (0) && entered == true && tag == "Grey Pigeon") {
				Death ();
			} else if (Input.GetMouseButtonDown (0) && entered == true && tag != "Grey Pigeon") {
				Debug.Log ("Nope");
				//Time.timeScale = 0f;
				score.rip = true;
				score.whiteFlash.SetActive (false);
				score.text.rectTransform.anchoredPosition = new Vector2 (0f, -48f);
			}
		}
	
		
	}
	void OnMouseEnter(){

		entered = true;
	}

	void OnMouseExit(){
		entered = false;
	}
	void OnTriggerEnter2D (Collider2D col){
		if (col.tag == "Spawn") {
			Destroy (gameObject);
		}
	}

	IEnumerator Ded(){
		
		yield return new WaitForSeconds (0.2f);

		Destroy (gameObject);
	}

	void Death(){
		Instantiate (feathers, transform.position, transform.rotation);
		StartCoroutine ("Ded");
		score.score +=1;
		score.speed -= 0.09f;
		gameObject.GetComponent<Renderer> ().enabled = false;
	}
}