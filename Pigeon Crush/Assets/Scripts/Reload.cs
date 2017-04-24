using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reload : MonoBehaviour {

	bool entered;
	// Use this for initialization
	void Start () {

	}

	void Update(){
		if (Input.GetMouseButtonDown (0) && entered == true) {
			SceneManager.LoadSceneAsync (SceneManager.GetActiveScene ().buildIndex);

		}
	}

	void OnMouseEnter(){
		
		entered = true;
	}
}