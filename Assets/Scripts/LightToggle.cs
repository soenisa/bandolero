using UnityEngine;
using System.Collections;

public class LightToggle : MonoBehaviour {
	//public float duration = 1.0F;
	public Light lt;
	bool LightOn = true; //need this boolean for light toggle


	// Use this for initialization
	void Start () {
	
		lt = GetComponent<Light>();//need this variable for light toggle


	}
	
	// Update is called once per frame
	void Update () {
	


		if (Input.GetKeyDown("o")) {
			Debug.Log ("Light Off");
			LightOn = !LightOn;
		}

		if (LightOn) {

			lt.intensity = 1;

		}


		if (!LightOn) {
			
			lt.intensity = 0;
			
		}






		//if (Input.GetKeyDown("o")) {
			//Debug.Log ("Light Off");

			//lt.intensity = 0;
		//}




	}
}
