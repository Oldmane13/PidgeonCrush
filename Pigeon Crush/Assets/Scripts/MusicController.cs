using UnityEngine;
using System.Collections;

public class MusicController : MonoBehaviour
{
	public AudioSource music;
	public bool isMuted;
	public Animator anim;
	public bool entered;
	// Use this for initialization
	void Start ()
	{
		music = GetComponent <AudioSource> ();
		anim = GetComponent <Animator> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (isMuted) {
			music.mute = true;
			anim.SetBool ("muted", true);

		} else{

			music.mute = false;
			anim.SetBool ("muted", false);
		}

		if (Input.GetMouseButtonDown (0) && entered == true) {
			isMuted = !isMuted;
		}
	}

	void OnMouseEnter(){

		entered = true;
	}

	void OnMouseExit(){
		entered = false;
	}
}

