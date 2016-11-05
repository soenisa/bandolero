using UnityEngine;
using System.Collections;

public class PointCollectible : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	void OnTriggerEnter (Collider c) {// use this same method and function to implement damage to player's health instead of score!!

		if (c.gameObject.tag == "Player") //When the character collides with our cube, this will make the cube add 50 score
		{

			c.GetComponent<Character> ().UpdateScore (50); // c.GetComponent<character>().UpdateScore (50); // the "c.GetComponent<character>" refers to the script on the character, and we put the "c" there because "c" is what we have hit, which has the script on it. The "UpdateScore" refers to the function within that script that we're calling
			Destroy (gameObject);
			// use this for Get and Set method  :   c.GetComponent<character> ().score += 50; // the "c.GetComponent<character>" refers to the script of the character, and we put the "c" there because "c" is what we have hit, which has the script on it
			//Debug.Log ("not working");
		}

	}
}
