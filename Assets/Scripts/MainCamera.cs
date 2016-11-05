using UnityEngine;
using System.Collections;

public class MainCamera : MonoBehaviour {

	static public bool cameraExists = false;

	// Use this for initialization
	void Start () {
		if(!cameraExists)
		{
			DontDestroyOnLoad(gameObject);
			cameraExists = true;
		}
		else
			Destroy(gameObject);
	}
}
