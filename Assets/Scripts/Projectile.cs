using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
	
	public float lifeTime; //Notice variable for how long it will take for bullet to disappear
	
	// Use this for initialization
	void Start () {
		
		lifeTime = 1.0f;//The bullet will only stay alive for one second after being fired.
		
		//if(lifeTime == 0){
		//Debug.Log("Set the Life Time variable in Inspector");      <---- Use tis if you want to set the lifetime yourself in the inspector, rather than have a locked value like above ^
		//}
		
		
		Destroy (gameObject, lifeTime);
		
		
		
		
		
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	//-----------------------------------------------------------------------------------     BREAKING OBJECTS WHEN THEY'VE BEEN HIT     ---------------------------------------------------------------------------------------
	
	void OnTriggerEnter(Collider c) //Only works with game objects that both have colliders. Only works if at least one has a Rigidbody
	{
		Debug.Log (c.gameObject.tag);//tell me what the bullet has hit
		
		if (c.gameObject.tag == "Enemy") //if the tag of what the prjectile colldies with is "Enemy"
		{
			
			Destroy (gameObject);// This destroys what script this is attached to (bullet)
			Destroy (c.gameObject);// This destroys what the projectile collides with (wall,enemy,etc)
			
		}
		
		
		if (c.gameObject.tag == "Breakable") //if the tag of what the prjectile colldies with is "Enemy"
		{
			
			Destroy (gameObject);// This destroys what script this is attached to (bullet)
			Destroy (c.gameObject);// This destroys what the projectile collides with (wall,enemy,etc)
			
		}
		
		
		if (c.gameObject.tag == "Fire") //if the tag of what the prjectile colldies with is "Enemy"
		{
			Debug.Log ("Bullet hit");
			Destroy (gameObject);// This destroys what script this is attached to (bullet)
			Destroy (c.gameObject);// This destroys what the projectile collides with (wall,enemy,etc)
			
		}
		
		
	}
	
}
