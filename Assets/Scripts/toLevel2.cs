using UnityEngine;
using System.Collections;

public class toLevel2 : MonoBehaviour {

	public GameObject player;
	public GameObject Level2Spawn;

	// Use this for initialization
	void Start () {	
		DontDestroyOnLoad(gameObject);
		

	}

	// Update is called once per frame
	void Update () {

		Level2Spawn = GameObject.FindGameObjectWithTag ("Lvl2spawn"); // don't need to have this, only if you're dynamically creating enemies


	}

	void OnTriggerEnter(Collider c) {
		Debug.Log ("to level 2!!");

		//Switch to Level 2
		Application.LoadLevel("Project_Lvl2");
		/////////////////////////////////////////////////////////////////////

	//	player = GameObject.FindGameObjectWithTag ("Player"); // don't need to have this, only if you're dynamically creating enemies

		player.transform.position = Level2Spawn.transform.position;

		//Level2Spawn = GameObject.FindGameObjectWithTag ("Lvl2spawn"); // don't need to have this, only if you're dynamically creating enemies



		WorldManager.SetMissionStatus(0, 1);
		WorldManager.SetCurrentLevel(2);
		WorldManager.SetCheckPoint(2);
		WorldManager.SaveGame();

		Debug.Log("Level is loaded");

		Application.LoadLevelAdditiveAsync(2);
		/////////////////////////////////////////////////////////////////////
	}
}
