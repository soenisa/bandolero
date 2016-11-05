using UnityEngine;
using System.Collections;

public class AudioTrigger : MonoBehaviour {

	public AudioClip jumpSnd;
	public AudioSource audio;


	void Start()
	{

		if (!jumpSnd)
			Debug.Log ("No sound found");

		if (!audio) //if you didnt drag anything into the audio slot
			audio = GetComponent<AudioSource> ();//you dont neer this if you drag a sound into the inspector slot

		audio.Play ();// after adding this, drag a audio clip into "Audio Clip" slot in Audio Source Script in the Trigger Cube's inspector. This will make this sound play at the very start of the game

	}



	//void OnTriggerEnter(Collider c){

		//audio.PlayOneShot (jumpSnd);
	
	//}





	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetMouseButtonDown(0))

			audio.PlayOneShot (jumpSnd);

			Debug.Log("Pressed left click.");





	}
}
