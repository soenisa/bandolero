using UnityEngine;
using System.Collections;

public class EnemyMoverJam : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		Walking ();

	}

	public void Walking (){
		gameObject.transform.position += gameObject.transform.right * Time.deltaTime * -6;
	}
}
