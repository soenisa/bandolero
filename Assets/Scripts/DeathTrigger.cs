using UnityEngine;
using System.Collections;

public class DeathTrigger : MonoBehaviour {

	void OnTriggerEnter(Collider c)
	{
		// did the player fall off the platforms?
		if(c.gameObject.tag.Equals("Player"))
		{
			// change the players health by -1
			c.gameObject.GetComponent<PlayerStats>().AddHealth(-1,0);

			// the player is dead and the last check point can be loaded from (WorldManager.js)
			WorldManager.SetLevelState("Dead");

			// de-parent the camera
			//c.gameObject.Find("Main Camera").transform.parent = null;

			// destroy the player Object
			Destroy(c.gameObject);

			// destory the world manager
			Destroy(GameObject.Find("WorldManager"));

			// go back to title screen 
			Application.LoadLevel(0);
		}
	}
}
