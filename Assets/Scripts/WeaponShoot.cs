using UnityEngine;
using System.Collections;

public class WeaponShoot : MonoBehaviour {

    // Used to Create the bullet

	public Rigidbody bullet;
	public Rigidbody bulletSecondary;


    // Used to keep track of how much ammo there is
    public int ammo;

    // Used to position the bullet once spawned
	public Transform spawnPoint;
	public Transform spawnPointSecondary;

    // Used to apply force to the bullet being fired
	public float bulletForce;


	// Use this for initialization
	void Start () {
        // Set the ammo count to 20
        ammo = 20;

        // Set the bullet force
        bulletForce = 15.0f;
	}

    public void Shoot()
    {
        // Check if there is enough ammo
        if (ammo >= 0)
        {
            // Create the bullet if there is enough ammo
			Rigidbody temp = Instantiate(bullet, spawnPoint.position, spawnPoint.rotation) as Rigidbody;

            // Add the force to fire the bullet
            temp.AddRelativeForce(Vector3.forward * bulletForce, ForceMode.Impulse);

            // Remove one ammo count
            ammo--;
        }
        // Do something if there isnt enough ammo
        else
            Debug.Log("Reload");
    }


	public void ShootSecondary()
	{
		// Check if there is enough ammo
		if (ammo >= 0)
		{
			// Create the bullet if there is enough ammo
			Rigidbody temp = Instantiate(bulletSecondary, spawnPointSecondary.position, spawnPointSecondary.rotation) as Rigidbody;

			// Add the force to fire the bullet
			temp.AddRelativeForce(Vector3.forward * bulletForce, ForceMode.Impulse);

			// Remove one ammo count
			ammo--;
		}
		// Do something if there isnt enough ammo
		else
			Debug.Log("Reload");
	}




}
