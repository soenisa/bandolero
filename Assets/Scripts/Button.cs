using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {

	public int ButtonType;
	bool bActivated = false;

	public GameObject Door1;
	public GameObject Door2;
	static int Activated = 0;

	bool canBeActivated = true;

	Vector3 DoorOneStartPosition;
	Vector3 DoorTwoStartPosition;
	Vector3 ThisStartPosition;

	// Use this for initialization
	void Awake () {
		// keep track of the start position of the button
		ThisStartPosition = transform.position;

		// does door1 exist
		if(Door1)
		{
			// keep track of the start position of the door
			DoorOneStartPosition = Door1.transform.position;
		}

		// does door1 exist
		if(Door2)
		{
			// keep track of the start position of the door
			DoorTwoStartPosition = Door2.transform.position;
		}
	}
	
	// Update is called once per frame
	void Update () {
		// the button has been activated
		if(bActivated == true)
		{
			// level 1 button check
			if (ButtonType == 1)
			{
				transform.position = Vector3.Lerp(this.transform.position, ThisStartPosition + new Vector3(0.5f, 0, 0), Time.deltaTime);
				Door1.transform.position = Vector3.Lerp(Door1.transform.position, DoorOneStartPosition + new Vector3(0,7,0), Time.deltaTime);
			}
			// level 2 button check
			else if (ButtonType == 2)
			{
				if(WorldManager.MissionStatusCheck(1)==0 && Activated == 2)
				{
					WorldManager.SetMissionStatus(1, 1);
					WorldManager.SetCurrentLevel(3);
					WorldManager.SetCheckPoint(3);
					WorldManager.SaveGame();
					Application.LoadLevelAdditiveAsync(3);

				}

				transform.position = Vector3.Lerp(transform.position, ThisStartPosition + new Vector3(0, -0.5f, 0), Time.deltaTime);
				//transform.position = Vector3.Lerp(transform.position, ThisStartPosition + Vector3(-0.5, 0, 0), Time.deltaTime);

				if (Activated == 2)
					Door2.transform.position = Vector3.Lerp(Door2.transform.position, DoorTwoStartPosition + new Vector3(0, 7, 0), Time.deltaTime);
			}
		}		
	}


	void OnCollisionEnter(Collision c)
	{
		if (!canBeActivated)
			return;

		// was level 1 button hit with a projectile?	
		if (ButtonType == 1 && c.gameObject.tag.Equals("projectile"))
		{

			bActivated = true;

			// stop checking collision on the button
			canBeActivated = false;

			WorldManager.SetMissionStatus(0, 1);
			WorldManager.SetCurrentLevel(2);
			WorldManager.SetCheckPoint(2);
			WorldManager.SaveGame();

			Debug.Log("Level is loaded");

			Application.LoadLevelAdditiveAsync(2);
		}
		// was level 2 button stepped on by Player?	
		else if (ButtonType == 2 && c.gameObject.tag.Equals("Player"))
		{
			bActivated = true;
			Activated ++;
			canBeActivated = false;
			GetComponent<Renderer>().material.color = Color.green;
		}
	}
}
