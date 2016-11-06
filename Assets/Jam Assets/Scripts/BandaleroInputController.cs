using UnityEngine;
using System;

enum MovementState
{
	Left,
	Stop,
	Right}
;

public class BandaleroInputController : MonoBehaviour
{
	public Animator animator;
	private CharacterMotor motor;

	private bool dancing;

	void Awake ()
	{
		motor = GetComponent<CharacterMotor> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		var horizontalVelocity = Input.GetAxis ("Horizontal");

		var movementState = (horizontalVelocity == 0 
			? MovementState.Stop
			: (horizontalVelocity > 0
				? MovementState.Right
				: MovementState.Left));

		var shouldRun = movementState != MovementState.Stop;
		var shouldJump = !dancing && Input.GetKeyDown ("space");
		var shouldDance = !shouldRun && !shouldJump && Input.GetKey("s");

		dancing = shouldDance;

		var speed = movementState == MovementState.Stop ? 0 : 1;

		if (shouldJump) {
			animator.SetTrigger ("jump");
		}
		animator.SetBool ("dance", shouldDance);
		animator.SetBool ("moving", horizontalVelocity != 0);

		var newTransform = gameObject.transform.rotation;
		switch (movementState) {
		case MovementState.Left: 
			newTransform.y = 180;
			break;

		case MovementState.Right:
			newTransform.y = 0;
			break;
		}
		transform.rotation = newTransform;

		var directionVector = new Vector3 (speed, 0);
		if (directionVector != Vector3.zero) {
			// Get the length of the directon vector and then normalize it
			// Dividing by the length is cheaper than normalizing when we already have the length anyway
			var directionLength = directionVector.magnitude;
			directionVector = directionVector / directionLength;

			// Make sure the length is no bigger than 1
			directionLength = Mathf.Min (1, directionLength);

			// Make the input vector more sensitive towards the extremes and less sensitive in the middle
			// This makes it easier to control slow speeds when using analog sticks
			directionLength = directionLength * directionLength;

			// Multiply the normalized direction vector by the modified length
			directionVector = directionVector * directionLength;
		}

		// Apply the direction to the CharacterMotor
		motor.inputMoveDirection = gameObject.transform.rotation * directionVector;
		motor.inputJump = shouldJump;
	}
}
