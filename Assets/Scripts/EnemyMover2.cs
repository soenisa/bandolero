using UnityEngine;
using System.Collections;

public class EnemyMover3 : MonoBehaviour {

	public int speed1 = 30;
	public Transform target;
	bool RaycastOn = true; //need this boolean for Raycast toggle

	// Use this for initialization
	void Start () {
	
		if(!target) {
			Debug.Log ("No target found"); //If there is no target, say "no target found"
			
		}
	}
	
	// Update is called once per frame
	void Update () {
	
		transform.Translate(Vector3.forward * Time.deltaTime * speed1);	//Makes the object move forward

		transform.Rotate(Vector3.right, Time.deltaTime*20);
		transform.Rotate(Vector3.up, Time.deltaTime*20, Space.World);


		transform.LookAt (target);// Makes it look at fpcontroller, neccesary to make it follow you


		//-------- 	WEEK 6 LAB	---------------------------------------------------------------
		


		if (Input.GetKeyDown("f")) {
			Debug.Log ("Raycast On");
			RaycastOn = !RaycastOn;
		}

		if (RaycastOn) {
			RaycastHit hit; //Variable to hold info about the thing the raycast hits
			//Debug.Drawline
			Debug.DrawRay(transform.position, transform.forward*10, Color.red);
	
		}


		if (!RaycastOn) {
	
		Debug.Log ("Raycast Off");
	
		}
		





		//-------- 	WEEK 6 LAB	---------------------------------------------------------------

		
		






	}


}
