using UnityEngine;
using System.Collections;

public class toLevel3 : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider c) {
		Debug.Log ("to level 3!!");

		//Switch to Level 2
		Application.LoadLevel("Project_Lvl3");

	}
}
