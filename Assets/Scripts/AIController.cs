using UnityEngine;
using System.Collections;

public class AIController : MonoBehaviour {

	public GameObject target; // what is being chased. Drag in FPS in the empty slot in Inspector
	public NavMeshAgent nmAgent; // what is chasing the target. Drag in ThirdPersonController in the empty slot in Inspector


	public Animator anim;

	public Rigidbody Bullet; //GameObject to create

	public Transform ProjectileSpawnPoint; //Where to create GameObject
	public float ProjectileForce;

	// Use this for initialization
	void Start () {
	
		//if (!nmAgent)
			//nmAgent = GetComponent<NavMeshAgent> ();  Use this if you don't want o drag and drop the variables in the Inspector

		//nmAgent.SetDestination (target.transform.position); // where do we want the AI to go? To wherever the target is

	}
	
	// Update is called once per frame
	void Update () {

		nmAgent.SetDestination (target.transform.position); // where do we want the AI to go? To wherever the target is
		//anim.SetFloat("Forward", nmAgent.speed);

		RaycastHit hit; //Variable to hold info about the thing the raycast hits

		//Debug.Drawline
		Debug.DrawRay(transform.position, transform.forward*5, Color.red);//Visually show the ray cast because raycast is invisible. transform.forward means the direction the cube is facing, only to a max distance on ten units

		if (Physics.Raycast (transform.position, transform.forward, out hit, 5)) { //transform.position is the cube's position. transform. Out hit is a way to pass a variable to something

		}


//		if (Vector3.Distance (target.transform.position, transform.position) < 5) 
//		{
//
//			Debug.Log ("chasing you");
//
//			anim.SetFloat("Forward", nmAgent.speed);
//
////			if (!zombieAnimator.GetBool ("Run")) //if (aController.GetBool ("DoorOpen")== false) 
////			{
////				zombieAnimator.SetBool ("Run", true);
////			}
//
//
//		}


		if (Vector3.Distance (target.transform.position, transform.position) < 5)
		{

			Debug.Log ("close enough");

			anim.SetFloat("Idle", nmAgent.speed = 0);

			Debug.Log ("Shooting 1");

			Rigidbody temp = Instantiate (Bullet, ProjectileSpawnPoint.position, ProjectileSpawnPoint.rotation) as Rigidbody;
			temp.AddForce (ProjectileSpawnPoint.transform.forward*ProjectileForce, ForceMode.Impulse);

		}

		if (Vector3.Distance (target.transform.position, transform.position) > 5)
		{

			Debug.Log ("coming closer");

			anim.SetFloat("Forward", nmAgent.speed = 3);





		}

		//////////////////////////////////////////////////////////////////////////////////////////////////////


	
	}
}
