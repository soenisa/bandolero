using UnityEngine;
using System.Collections;

public class StoneDoor : MonoBehaviour {

	public Animator aController; //make sure you drag DoorHinge into "A Controller" slot in Inspector

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame



	public void Update () {


		//-------------------------------------------------------------------------------       Raycasting       ------------------------------------------------------------------------------------

		//Use raycast to check distance between objects

		RaycastHit hit; //Variable to hold info about the thing the raycast hits

		//Debug.Drawline
		Debug.DrawRay(transform.position, transform.forward*10, Color.red);//Visually show the ray cast because raycast is invisible. transform.forward means the direction the cube is facing, only to a max distance on ten units

		if (Physics.Raycast (transform.position, transform.forward, out hit, 10)) { //transform.position is the cube's position. transform. Out hit is a way to pass a variable to something

		}



	}


	public void PlayAnimation () {

		if (aController.GetBool ("StoneDoorOpen")) //if (aController.GetBool ("DoorOpen")== true) 
		{
			aController.SetBool ("StoneDoorOpen", false);
			Debug.Log ("Open");
		}

		else if (!aController.GetBool ("StoneDoorOpen")) ////if (aController.GetBool ("DoorOpen")== false) 
		{
			aController.SetBool ("StoneDoorOpen", true);
			Debug.Log ("Closed");
		}




	}
}
