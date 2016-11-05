using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour {

	public Camera topDownView;
	public Camera sideView;
	public Camera deathView;
	public Camera p1View;

	//public Camera[] camList; //this is an array

	
	// Use this for initialization
	void Start () {
	
		p1View.enabled = true;
		topDownView.enabled = false;
		sideView.enabled = false;
		deathView.enabled = false;          //&& noSwitch!


	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKeyDown (KeyCode.Alpha1)) 
		{
			topDownView.enabled = true;
			sideView.enabled = false;
			deathView.enabled = false;

		}

		if (Input.GetKeyDown (KeyCode.Alpha2)) 
		{
			topDownView.enabled = false;
			sideView.enabled = true;
			deathView.enabled = false;
			
		}


		if (Input.GetKeyDown (KeyCode.Alpha3)) 
		{
			topDownView.enabled = false;
			sideView.enabled = false;
			deathView.enabled = true;
			
		}



		/* USE THIS TO ADD A CAMERA TRIGGER IN YOUR SCENE (CHARACTER WALKS INTO A CERTAIN AREA OR EMPTY GAME OBJECT AND THE CAMERA SWITCHES)
		 * ADD THIS ONTO THE TRIGGER OBJECT

		void onTriggerEnter(Collider c)
		{
			topDownView.enabled = false;
			sideView.enabled = true;// when the character walks through a set object, change to this camera. Need to add a trigger object to scene, add collider to it, and check off "is trigger"
			deathView.enabled = false;

		}

		*/




	}
}
