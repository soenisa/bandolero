using UnityEngine;
using System.Collections;

public class AIPathFinder : MonoBehaviour {

	public NavMeshAgent nmAgent; // used to control AI
	public GameObject currentNode; // used to tell AI what to move towards

	public Animator anim;


	public GameObject[] path; // this is an array to hold all the PathNodes
	public int pathNodeIndex = 0; // used to tell what Path Node to go to, one after the other

	public float nodeDistance = 2.0f; // used to tell AI when to change PathNode, based on distance

	public bool isChasing = false;
	public GameObject player; 
	public float chaseDistance = 5.0f;


	// Use this for initialization
	void Start () {
	
		//ink NavMeshAgent Component to variable nmAgent
		nmAgent = GetComponent<NavMeshAgent> ();
		if (!nmAgent) // check if NavMeshAgent is attached to GameObject
		{
			//if it's not attached...
			Debug.Log ("NavMeshAgent Component not found on GameObject");
		}

		//Only use if not setting a path manually
		//Finds and adds al GameObjects tagged as PathNode to path array
		path = GameObject.FindGameObjectsWithTag("PathNode"); // puts all of your path nodes into an array, usually in the order they were added or loaded

		//tell NavMeshAgent what the currentNode is
		currentNode = path [pathNodeIndex];

		nmAgent.SetDestination (currentNode.transform.position);

		//The other way is to click on ThirdPersonController, scroll to AI Path Finder Component, find "path", add how mny spots you want and then drag the nodes in

		// Tell NavMeshAgent to go to first node in path array
		//nmAgent.SetDestination (path[0].transform.position);

		//Find player in scene
		player = GameObject.FindGameObjectWithTag ("Player"); // don't need to have this, only if you're dynamically creating enemies
	}

	
	// Update is called once per frame
	void Update () {



		// This refreshes to always send the AI to a different node
		nmAgent.SetDestination (currentNode.transform.position);

		if (!isChasing && Vector3.Distance (transform.position, path [pathNodeIndex].transform.position) < nodeDistance) 
		{
			pathNodeIndex++; // add one to the current index/move to the next one

			// Method 1: Cycle back to the beginning of "path" Array
			pathNodeIndex %= path.Length; // says, when I get to the end, if there is no remainder, start back at zero

			// Method 2: 
			//if (pathNodeIndex >= path.Length) // If the current node = the final node, start again from the beginning
			//{
			//	pathNodeIndex = 0;
			//}

			currentNode = path [pathNodeIndex]; // the current node becomes the next one in line
		}

	
		if (Vector3.Distance (transform.position, player.transform.position) < chaseDistance) 
		{
			currentNode = player; // current node is now the player

			Debug.Log ("hot");

			isChasing = true; // NavMeshAgent is now chasing player



		}

		if (Vector3.Distance (transform.position, player.transform.position) > chaseDistance) 
		{
			currentNode = path [pathNodeIndex];

			Debug.Log ("cold");

			isChasing = false; // NavMeshAgent is now chasing player
		}

	}
}
