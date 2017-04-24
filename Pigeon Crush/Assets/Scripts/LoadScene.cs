using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class LoadScene : MonoBehaviour {

	bool entered;
	// Use this for initialization
	void Start () {
		
	}

	void Update(){
		if (Input.GetMouseButtonDown (0) && entered == true) {
			SceneManager.LoadScene ("Game");
			Debug.Log ("CLICK");
		}
	}

	void OnMouseEnter(){
		Debug.Log ("IN");
		entered = true;
	}
}
