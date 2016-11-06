using UnityEngine;
using System.Collections;

public class CloudMover : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		Walking ();

	}

	public void Walking (){
		gameObject.transform.position += gameObject.transform.forward * Time.deltaTime * 8;
	}
}
