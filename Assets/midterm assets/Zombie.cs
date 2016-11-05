


using UnityEngine;
using System.Collections;

public class Zombie : MonoBehaviour {
	//Add variables here
	public int speed1; //public means you can change this value anywhere. Here in monodevelop and also in unity. **Just always use public**
	public bool Run;

	//public float speed1 = 5.5f;   Use "float" when you want to use a number with a decimal, not a whole number. If you use this, put "speed1 = 5.0f;" under "void Start"..?

	//public float stopDistance = 1f; //so the object following cannot come closer than this distance to the object being followed


	// Create a reference to a compontent
	// A Component can be anything from a Script, Rigidbody, transform... anything (week4, making an object follow you
	public Transform target; 
	public Animator zombieAnimator;
	Animator animator;



	// Called once, GameObject can be enabled. It may not be in the file.
	void Awake () {

	}

	// Use this for initialization
	//Called once. GameObject must be enabled . It may not be in the file.
	// Only used if you want to add attributes, like health and other stats
	void Start () {

		Run = true;

		if(!target) 
		{
			Debug.Log ("No target found"); //If there is no target, say "no target found
		}


//		animator = GetComponent<Animator>(); //grab the referenced animator
//		if (!animator)
//			Debug.Log("No animator found");
//
//		zombieAnimator = gameObject.GetComponent<Animator>();




	}

	// Update is called once per frame. Where we put things that are not physics related
	void Update () {




		//-------------------------------------------------------------------------------       Raycasting       ------------------------------------------------------------------------------------

		//Use raycast to check distance between objects

		RaycastHit hit; //Variable to hold info about the thing the raycast hits

		//Debug.Drawline
		Debug.DrawRay(transform.position, transform.forward*10, Color.red);//Visually show the ray cast because raycast is invisible. transform.forward means the direction the cube is facing, only to a max distance on ten units

		if (Physics.Raycast (transform.position, transform.forward, out hit, 10)) { //transform.position is the cube's position. transform. Out hit is a way to pass a variable to something

		}

		//----------------------------------------------------------------------     MOVING (TRANSFORMING) OUR OBJECTS     --------------------------------------------------------------------------

		//Make the cube move forward. This vector moves it "forward", if the object is facing Z, the blue arrow
		//A vector3 is a thing with 3 axis (x,y,z);
		//Vector3 (0,0,1);
		//transform.Translate(Vector3.forward * Time.deltaTime);   //** this is commented out because we are using a replacement below, which involves a variable for speed.

		//this adds speed for the movement
		//only use one speed function per object
		//transform.Translate(new Vector3(0,0,5) * Time.deltaTime); // <Use his one if you want to add finite speed in script. You can't edit in in the inspector

		transform.Translate(Vector3.forward * Time.deltaTime * speed1);// use this one if you want to be able to edit the speed in unity inspector



		//---------------------------------------------------------------------------- Making something follow you ----------------------------------------------------------------------------------


		transform.LookAt (target);


		//Vector3.Distance (target.position, transform.position)//how far the "follower" is from the target. You can plug this into a debug.log to print the value, or add an if statement to control the distance.

		if (Vector3.Distance (target.position, transform.position) < 10) 
			{
			speed1 = 5;
			Run = true;
			Debug.Log ("chasing you");

			if (!zombieAnimator.GetBool ("Run")) //if (aController.GetBool ("DoorOpen")== false) 
			{
				zombieAnimator.SetBool ("Run", true);
			}

			else if (Vector3.Distance (target.position, transform.position) > 10)
			{
				speed1 = 5;
				Run = true;
			}
		}

//		if (Vector3.Distance (target.position, transform.position) > 11) {
//			speed1 = 0;
//			Run = false;
//			Debug.Log ("Not close enough");
//		}



		//--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------



		//---------------------------------------------------------------------------      ROTATING OUR OBJECTS     ----------------------------------------------------------------------------------


		//transform.Rotate(Vector3.right, Time.deltaTime);
		//transform.Rotate(Vector3.up, Time.deltaTime, Space.World);




		//--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
















	}


	// Update is called once per frame at the end of the Update. 
	void LateUpdate () {

	}

	// Linked to Physics Update. Where you would put rigid body and other physics based functions.
	void FixedUpdate () {

	}













}


