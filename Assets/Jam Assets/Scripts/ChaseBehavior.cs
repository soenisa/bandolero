using UnityEngine;
using System.Collections;

public class ChaseBehavior : MonoBehaviour
{
	bool chaseActivated = false;
	public GameObject chasee;
	public float triggerProximity;
	public float speed;

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
			chaseActivated = distance < triggerProximity;
		} else {
			transform.position += new Vector3(Time.deltaTime * speed, 0);
		}
	}
}
