using UnityEngine;
using System.Collections;

public class VideoPlayer : MonoBehaviour {

	Renderer r;
	MovieTexture movie;
	AudioSource audio;

	// Use this for initialization
	void Start () {
	
		r = GetComponent<Renderer> ();
		movie = (MovieTexture)r.material.mainTexture;

		audio = GetComponent<AudioSource> ();

		movie.Play ();
		audio.Play();

	}
	
	// Update is called once per frame
	void Update () {
	
		if(Input.GetButtonDown ("Jump"))
		{
			if(movie.isPlaying)
			{
				movie.Pause();
				audio.Pause();
			}

			else
			{
				movie.Play ();
				audio.UnPause();
			}
		}





	}
}
