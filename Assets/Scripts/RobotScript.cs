using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]  //------     Automatically adds the animation and character controller components if you don't already have them
[RequireComponent(typeof(Animator))]  //-----------------

public class RobotScript : MonoBehaviour {

	// Used to make the CharacterController move on Keyboard Input
	public float speed = 6.0f;
	public float jumpSpeed = 1.0f;
	public float rotateSpeed = 5.0f;
	public float gravity = 9.8f;
	Vector3 moveDirection = Vector3.zero;
	public Animator anim;

	public bool shootingOneHand;
	public bool shootingTwoHands;

    CharacterController controller;

	Animator animator;//stores a reference to the animator to control animations
	bool jumping;//--------------need this for jumping!!!!

	// Use this for initialization
	void Start () {
       
		animator = GetComponent<Animator>(); //grab the referenced animator
		if (!animator)
			Debug.Log("No animator found");

        controller = GetComponent<CharacterController>();
        if (!controller)
            Debug.Log("No controller found");


		anim = gameObject.GetComponent<Animator>();
		shootingOneHand = true;
		shootingTwoHands = true;

    }
	
	// Update is called once per frame
	void Update () {

		// Check if character is touching the floor
		if (controller.isGrounded) {
			// Strafe
			//moveDirection = new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));

			float moveForward = Input.GetAxis ("Vertical");

			// No strafe
			moveDirection = new Vector3 (0, 0, moveForward);
			
			// Rotate player based on left and right movement keys
			transform.Rotate (0, Input.GetAxis ("Horizontal") * rotateSpeed, 0); 

			// Apply the direction to move the player
			moveDirection = transform.TransformDirection (moveDirection);
			moveDirection *= speed;
			
			// Was jump key pressed?
			if (Input.GetButton ("Jump")) {//--------------need this for jumping!!!!
				jumping = true;
				moveDirection.y = jumpSpeed;	// add a Y value to the moveDirection		
			}	

			animator.SetFloat ("Speed", moveForward);// Tell animator to transition into walk forward or backwards state

			if (Input.GetButtonDown("Fire1") && moveForward >= 0) 
			{
				animator.SetTrigger ("Shoot2Hands");
			}

			if (Input.GetKeyDown (KeyCode.P) && moveForward >= 0.1)
			{
				animator.SetTrigger ("Shoot1Hand");
			}

			if (Input.GetKeyDown (KeyCode.P) && moveForward == 0)
			{
				animator.SetTrigger ("Shooting1Hand");
			}
			
		} 

		else//--------------need this for jumping!!!!
			
			jumping = false;//--------------need this for jumping!!!!
		
		animator.SetBool ("Jump", jumping); //--------------need this for jumping!!!!
			
		// Gravity must be manually applied to the object.
		moveDirection.y -= gravity * Time.deltaTime;
		
		// Moves the player based off of the Vector3 being passed to the object
		controller.Move (moveDirection * Time.deltaTime);



		if (Input.GetKeyDown ("1")) 
		{
			shootingOneHand = true;
			Debug.Log ("Pressing 1");
		}

		if (Input.GetKeyDown ("2")) 
		{
			shootingTwoHands = true;
			Debug.Log ("Pressing 2");
		}
	}
}
