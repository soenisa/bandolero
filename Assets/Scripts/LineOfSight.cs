using UnityEngine;
using System.Collections;

public class LineOfSight : MonoBehaviour {
	bool RaycastOn = true; //need this boolean for Raycast toggle

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		
		//-------- 	WEEK 6 LAB	------------------------------------------------------------------------------------------------------------------
		
		
		
		if (Input.GetKeyDown("f")) {
			Debug.Log ("Raycast On");
			RaycastOn = !RaycastOn;
		}
		
		if (RaycastOn) {
			//RaycastHit hit; //Variable to hold info about the thing the raycast hits
			//Debug.Drawline
			Debug.DrawRay(transform.position, transform.forward*10, Color.red);
			
		}
		
		
		if (!RaycastOn) {
			
			Debug.Log ("Raycast Off");
			
		}
		
		
		
		
		
		
		//-------- 	WEEK 6 LAB	------------------------------------------------------------------------------------------------------------------
		






	}
}
