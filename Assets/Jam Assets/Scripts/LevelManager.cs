using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Bandolero
{
	public class LevelManager : MonoBehaviour {

		public GameObject player;
		// List of all objects to spawn
		private List<Spawner> spawnList;
		private Spawner nextSpawn;
		private GameObject newEnemy;


		// Use this for initialization
		void Start () {

			if(!player){
				Debug.Log ("Please drag player into player variable");
			}

			spawnList = new List<Spawner>();

			GameObject cubeEnemy = GameObject.Find("Cube");

			// Add enemies to spawn
			spawnList.Add(new Spawner(5, cubeEnemy));
			spawnList.Add(new Spawner(17, cubeEnemy));
			spawnList.Add(new Spawner(44, cubeEnemy));
			spawnList.Add(new Spawner(55, cubeEnemy));
			spawnList.Add(new Spawner(65, cubeEnemy));
			spawnList.Add(new Spawner(94, cubeEnemy));
			spawnList.Add(new Spawner(104, cubeEnemy));
			spawnList.Add(new Spawner(122, cubeEnemy));
			spawnList.Add(new Spawner(139, cubeEnemy));
			spawnList.Add(new Spawner(156, cubeEnemy));
			spawnList.Add(new Spawner(187, cubeEnemy));
			spawnList.Add(new Spawner(194, cubeEnemy));
			spawnList.Add(new Spawner(213, cubeEnemy));

			// Order list by trigger position
			spawnList = spawnList.OrderBy(o=>o.triggerXPosition).ToList();

			// Pop the first element and set it as nextSpawn
			nextSpawn = spawnList.First();
		}
		
		// Update is called once per frame
		void Update () {

			spawnChecker();
		}

		/***
		* Checks player position against the spawnList 
		* Spawns objects when player reaches their trigger point
		***/
		void spawnChecker() {
			if (nextSpawn != null && player.transform.position.x >= nextSpawn.triggerXPosition) {
				Debug.Log (string.Format("Instantiating object at position {0}", nextSpawn.objInitXPosition));
				// Get original position of obj
				Vector3 initPos = nextSpawn.objToSpawn.transform.position;

				// Change intial x position and spawn clone
				initPos.x = nextSpawn.objInitXPosition;
				newEnemy = (GameObject)Instantiate (nextSpawn.objToSpawn, initPos, Quaternion.identity);
				spawnList.RemoveAt (0);

				if (spawnList.Count > 0) {
					Debug.Log ("Next spawn set");
					nextSpawn = spawnList.First();
				} else {
					Debug.Log ("No more spawns");
					nextSpawn = null;
				}
			}
		}
	}
}