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


		// TODO: remove hacky translation of transform.position
		// cube position was relative to parent which was at -130
		public Spawner(int playerXPos, int objXPos, GameObject go)
		{	
			triggerXPosition = playerXPos - 150;
			objInitXPosition = objXPos - 150;
			objToSpawn = go;
		}

		public Spawner(int objXPos, GameObject go)
		{
			triggerXPosition = objXPos - 160;
			objInitXPosition = objXPos - 150;
			objToSpawn = go;
		}
	}
}

