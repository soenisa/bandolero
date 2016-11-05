using UnityEngine;
using System.Collections;

public class WinGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider c) {
		Debug.Log ("YOU WIN!");
		
		//Switch to Level 2
		Application.LoadLevel("WinGame");
		
	}



}
