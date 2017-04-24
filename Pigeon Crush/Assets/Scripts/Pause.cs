using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
	private bool entered;
	public bool isPaused;

	public GameObject menuHolder;
	public SpawnTest Death;
	// Use this for initialization
	void Start ()
	{
		Death = FindObjectOfType <SpawnTest> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (isPaused && Death.rip == false) {
			menuHolder.SetActive (true);
			Time.timeScale = 0f;
		} else if (!isPaused && Death.rip == false) {
		
			menuHolder.SetActive (false);
			Time.timeScale = 1f;
		}

		if (Input.GetMouseButtonDown (0) && entered == true) {
			isPaused = !isPaused;
		}

		/*if (!isPaused || Death.rip == true) {
			Time.timeScale = 0f;
		}*/

	}

	public void Continue(){
		isPaused = false;
	}
		

	public void Restart(){
		SceneManager.LoadSceneAsync (SceneManager.GetActiveScene ().buildIndex);
	}


	void OnMouseEnter(){

		entered = true;
	}

	void OnMouseExit(){
		entered = false;
	}
}

