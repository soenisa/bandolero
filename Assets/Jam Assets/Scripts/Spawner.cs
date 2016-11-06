using UnityEngine;
using System.Collections;

namespace Bandolero
{
	public class Spawner
	{
		// X position player should be at to trigger spawn
		public int triggerXPosition;
		// Initial x position of spawned (assumes identical y,z positions)
		public int objInitXPosition;
		public GameObject objToSpawn;

		public Spawner(int playerXPos, int objXPos, GameObject go)
		{
			triggerXPosition = playerXPos;
			objInitXPosition = objXPos;
			objToSpawn = go;
		}

		public Spawner(int objXPos, GameObject go)
		{
			triggerXPosition = objXPos - 10;
			objInitXPosition = objXPos;
			objToSpawn = go;
		}
	}
}

