using UnityEngine;
using System.Collections;

public class WeaponController : MonoBehaviour {

	public Animator animator;
	public bool gunFired = false;
	public Rigidbody Bullet; //GameObject to create
	public Transform projectileSpawnPoint; //Where to create GameObject
	public float projectileForce;

	IEnumerator WaitThenShoot() {
		yield return new WaitForSeconds(0.5f);
		Rigidbody temp = Instantiate (Bullet, projectileSpawnPoint.position, projectileSpawnPoint.rotation) as Rigidbody;
		temp.AddForce (projectileSpawnPoint.transform.forward*projectileForce, ForceMode.Impulse);
		Debug.Log ("Shot Fired");

	}

	// Use this for initialization
	void Start () {
	

	}
	
	// Update is called once per frame
	void Update () {
	


		animator = GetComponent<Animator>(); //grab the referenced animator
		if (!animator)
			Debug.Log("No animator found");

		if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("shooting_gun") && !gunFired)
		{
			//Debug.Log ("shooting gun");
			gunFired = true;

		}

		else //if (!this.animator.GetCurrentAnimatorStateInfo(0).IsName("shooting_gun") && !gunFired)
		{
			//Debug.Log ("not shooting gun");
			gunFired = false;

		}

		if (Input.GetKeyDown ("space")){

			Debug.Log ("Shooting");


			StartCoroutine(WaitThenShoot());
		}


	}
}
