using UnityEngine;
using System.Collections;

public class FireDamage : MonoBehaviour {

	public bool burning = false;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	



		if (burning) {
			Debug.Log ("on fire");


		}

		if (burning == false) {
			Debug.Log ("not fire");
			
		}



	}

	void OnTriggerEnter(Collider c) //Only works with game objects that both have colliders. Only works if at least one has a Rigidbody
			{
		burning = true;			
			}

	void OnTriggerExit(Collider c) //Only works with game objects that both have colliders. Only works if at least one has a Rigidbody
	{
		burning = false;			
	}


}
