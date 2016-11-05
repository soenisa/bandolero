using UnityEngine;
using System.Collections;

public class LevelEnder : MonoBehaviour {
	public string nextLevel; // must set variable in inspector to work
	
	// Use this for initialization
	
	
	void Start(){
		if (nextLevel == " ") 
		{
			Debug.Log ("Make sure you set the variable in the Build Settings");
		}
		
		
		
	}
	
	
	
	
	void OnTriggerEnter(Collider c) {
		Debug.Log (c.gameObject.name + " entered trigger area");
		
		//Switch to Level 2
		Application.LoadLevel (nextLevel); //Uses 
		
	}
	
	// Called as long as the GameObject is in trigger area
	void OnTriggerStay(Collider c) {
		
	}
	
	//Only called once when GameObject exits trigger area
	void OnTriggerExit(Collider c) {
		
	}
	
	
	
	
	
	
}

