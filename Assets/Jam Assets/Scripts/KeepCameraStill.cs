using UnityEngine;
using System.Collections;

public class KeepCameraStill : MonoBehaviour {

	//public Vector3 magicnumber = null;
	public float DistanceAway = 10;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		Vector3 PlayerPosition = GameObject.Find("Player").transform.transform.position;
		GameObject.Find("MainCamera").transform.position = new Vector3(PlayerPosition.x, PlayerPosition.y, PlayerPosition.z - DistanceAway);

	}
}
