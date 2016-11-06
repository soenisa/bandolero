using UnityEngine;
using System.Collections;

public class ChaseBehavior : MonoBehaviour
{
	bool chaseActivated = false;
	public GameObject chasee;

	// Use this for initialization
	void Start ()
	{
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (!chaseActivated) {
			var distance = gameObject.transform.position.x - chasee.transform.position.x;
			Debug.Log(distance);
			chaseActivated = distance < 10;
		} else {
			transform.position -= new Vector3(Time.deltaTime * 6, 0);
		}
	}
}
