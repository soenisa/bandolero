using UnityEngine;
using System.Collections;

public class SpawnCube : MonoBehaviour {

	public GameObject player;

	// Use this for initialization
	void Start () {
	
		player = GameObject.FindGameObjectWithTag ("Player"); // don't need to have this, only if you're dynamically creating enemies

		player.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
