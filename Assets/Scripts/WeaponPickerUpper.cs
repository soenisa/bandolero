using UnityEngine;
using System.Collections;

public class WeaponPickerUpper : MonoBehaviour {

	public GameObject weapon;
    public GameObject weaponAttach;
	public int numberOfGuns = 0;

	// Use this for initialization
	void Start () 
    {

		if (!weaponAttach) {
			weaponAttach = GameObject.Find ("WeaponPlacement");
		}
	}
	
	// Update is called once per frame
	void Update () {
	    // Drop the weapon when the 'T' key is pressed
		Debug.Log(numberOfGuns);

	    if(Input.GetKeyDown(KeyCode.T))
	    {
		    // Is there a weapon to drop
		    if(weapon!=null)
		    {			    // Remove the weapon as a Child of the Player
				weaponAttach.transform.DetachChildren();

				numberOfGuns--;
			
			    // Turn the collision check back on
				Physics.IgnoreCollision(transform.GetComponent<Collider>(), weapon.GetComponent<Collider>(),false);

			
			    // Turn Physics back on
				weapon.GetComponent<Rigidbody>().isKinematic = false;

			    // Throw the weapon forward
			    weapon.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * 10, ForceMode.Impulse);
			
			    // Reset the weapon to null so a new weapon can be collected
				weapon = null;
		    }
	    }

	    // Check if the Fire key was pressed
	    if(Input.GetButtonDown("Fire1"))
	    {
		    // Check if there is weapon attached to the Player
		    if(weapon != null)
		    {
			    // Grab the Weapons Script to enable firing
				weapon.GetComponent<WeaponShoot>().Shoot();
		    }
	    }

		if(Input.GetButtonDown("Fire2"))
		{
			// Check if there is weapon attached to the Player
			if(weapon != null)
			{
				// Grab the Weapons Script to enable firing
				weapon.GetComponent<WeaponShoot>().ShootSecondary();
			}
		}




	}

    void OnTriggerEnter(Collider c)
    {
	    // Move the weapon to the position of the gameobject
		
	
	    // Make the gameobject a parent of the weapon
	
	
	    // Rotate it to the parent identity
	    c.transform.localRotation = Quaternion.identity;	
    }

    // Does not work with the Character Controller
    void OnCollisionEnter(Collision c)
    {
	
	
    }

    // Used when working with a Character Controller to check for collision
    void OnControllerColliderHit(ControllerColliderHit c)
    {
	    // Did the player collide with a weapon
		if(c.collider.tag.Equals("Weapon") && numberOfGuns <1)
	    {

			numberOfGuns++;
		    // Store a copy of the weapon
			weapon = c.gameObject;
	
		    // Stop applying Physics to the weapon	
			weapon.GetComponent<Rigidbody>().isKinematic = true;
		
		    // Move the weapon to the position of the gameobject
			weapon.transform.position = weaponAttach.transform.position;
	
		    // Make the gameobject a parent of the weapon
			weapon.transform.parent = weaponAttach.transform;

		    // Rotate it to the parent identity
		
			weapon.transform.localRotation = Quaternion.identity;
		    // Stop Collision
			Physics.IgnoreCollision(transform.GetComponent<Collider>(), weapon.GetComponent<Collider>());
	    }

	
    }
}