using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class HealthCollectible : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void OnTriggerEnter (Collider c) {// use this same method and function to implement damage to player's health instead of score!!

		if (c.gameObject.tag == "Player") //When the character collides with our cube, this will make the cube add 50 score
		{

			//c.GetComponent<PlayerHealth> ().UpdateHealth (20); 


			Destroy (gameObject);
			// use this for Get and Set method  :   c.GetComponent<character> ().score += 50; // the "c.GetComponent<character>" refers to the script of the character, and we put the "c" there because "c" is what we have hit, which has the script on it
			//Debug.Log ("not working");
		}

	}
}
