using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
	private bool entered;
	public bool isPaused;

	public GameObject menuHolder;
	public GameController Death;
	public MusicController musicIcon;

	// Use this for initialization
	void Start ()
	{
		Death = FindObjectOfType <GameController> ();
		musicIcon = FindObjectOfType<MusicController> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (isPaused && Death.rip == false) {
			menuHolder.SetActive (true);
			Time.timeScale = 0f;
			//musicIcon.GetComponent<Renderer> ().enabled = true;
		} else if (!isPaused && Death.rip == false) {
			//musicIcon.GetComponent<Renderer> ().enabled = false;
			menuHolder.SetActive (false);
			Time.timeScale = 1f;
		}

		if (Input.GetMouseButtonDown (0) && entered == true) {
			isPaused = !isPaused;
		}

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

