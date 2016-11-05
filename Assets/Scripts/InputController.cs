using UnityEngine;
using System.Collections;

public class InputController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if(Input.GetKeyDown(KeyCode.E)) //Was left mouse button clicked?
		{
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

			RaycastHit hit;

			if(Physics.Raycast(ray.origin, ray.direction, out hit, 2 ))// where is starts, what direction its going, what it hits, How far away
			{
				Debug.Log (hit.transform.name);

				Door myDoor = hit.transform.GetComponent<Door> ();//We hit something that has the door script on it, call it so we have access to hit

				if (myDoor) 
				{
					Debug.Log ("Touched the door");
					myDoor.PlayAnimation();
				}
			}
		}



		if(Input.GetMouseButtonDown(0)) //Was left mouse button clicked?
		{
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

			RaycastHit hit;

			if(Physics.Raycast(ray.origin, ray.direction, out hit, 2 ))// where is starts, what direction its going, what it hits, How far away
			{
				Debug.Log (hit.transform.name);

				Door myDoor = hit.transform.GetComponent<Door> ();//We hit something that has the door script on it, call it so we have access to hit

				if (myDoor) 
				{
					Debug.Log ("Touched the door");
					myDoor.PlayAnimation();
				}
			}
		}
	}
}
