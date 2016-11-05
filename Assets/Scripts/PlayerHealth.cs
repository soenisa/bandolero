using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

	public int startingHealth = 100;	// Amount of health player starts with
	public int currentHealth;					// Current health player has
	public Slider healthSlider;			// Reference to UI health bar
	public Image damageImage;			// Reference to image to flash screen when being hurt/ the red flashing screen that we made "damage image"
	public bool burning = false;
	public float flashSpeed = 20.0f;		// Speed damageImage fades at
	public Color flashColour;			// Colour damageImage will be set to flash
	bool isDead;						// Whether player is dead
	bool damaged; 						// True when player gets damaged
	public FireDamage triggerstatus;
	public bool invincibility;
	public float invincibleTime = 3.0f;

	public GameObject InvincibilityPanel;
	private bool isShowing;
	// Use this for initialization
	void Start () {

		// Use RED as flashing colour
		flashColour = new Color(1f, 0f, 0f, 0.1f);  // set the colour to red automatically

		// Player is not dead
		isDead = false;

		// Player has not been damaged
		damaged = false;

		// Set initial health of player
		currentHealth = startingHealth;

		invincibility = false;


	}


//	void OnCollisionEnter(Collision c) //Only works with game objects that both have colliders. Only works if at least one has a Rigidbody
//	{
//		Debug.Log (c.gameObject.tag);//tell me what the bullet has hit
//		
//		if (c.gameObject.tag == "Fire") //if the tag of what the prjectile colldies with is "Enemy"
//		{
//			Debug.Log ("Burning!!");
//			currentHealth -= 10;
//		}
//	}



	// Update is called once per frame
	void Update () {

		Debug.Log ("playerhp = " + currentHealth);

		if (burning) {

			Debug.Log ("on fire");

			// Set colour of damageImage to flash colour
			damageImage.color = flashColour;
			
			// Reduce current health by damage amount
			currentHealth -= 1;
			
			// Set health bar's value to current health
			healthSlider.value = currentHealth;

		}
		
		if(currentHealth <= 0)
		{
			// Make player should die
			isDead = true;

		}if (burning == false) {
			Debug.Log ("not fire");
			
		}

		// Has player has been hit?
		if(damaged)
		{
			// Set colour of damageImage to flash colour
			damageImage.color = flashColour;

			// Reduce current health by damage amount
			currentHealth -= 5;
			
			// Set health bar's value to current health
			healthSlider.value = currentHealth;
			
			// If player loses all health and death flag isn't set yet
			if(currentHealth <= 0)
			{
				// Make player should die
				isDead = true;
			}
		}

		if (invincibility) 
		{
			Debug.Log ("invincible bool on!");
		

		}


		if (isDead) {
			
			Debug.Log ("ur ded lols ");
			Application.LoadLevel("GameOver");

		}


		// Otherwise...
		else
		{
			// Transition colour back to clear
			damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
		}
		
		// Reset damaged flag
		damaged = false;
		
		if(Input.GetKeyDown(KeyCode.H))
		{
			TakeDamage(-10);
		}
		if(Input.GetKeyDown(KeyCode.J))
		{
			RegenHealth(10);
		}
	}

	void TakeDamage (int amount)
	{
		// Set damaged flag so screen will flash
		damaged = true;
		
		// Reduce current health by damage amount
		currentHealth += amount;
		
		// Set health bar's value to current health
		healthSlider.value = currentHealth;
		
		// If player loses all health and death flag isn't set yet

	}
	
	public void RegenHealth (int amount)
	{	
		if(currentHealth < 100)
		{
			// Increase current health by damage amount
			currentHealth += amount;
			
			// Set health bar's value to current health
			healthSlider.value = currentHealth;
		}
	}

	void RestartLevel ()
	{
		// Reload current level
		Application.LoadLevel (Application.loadedLevel);
	}

	void OnTriggerEnter(Collider c) //Only works with game objects that both have colliders. Only works if at least one has a Rigidbody
	{

		if (c.gameObject.tag == "Fire" &! (invincibility)) 
		{

			//c.GetComponent<Character> ().UpdateScore (50); // c.GetComponent<character>().UpdateScore (50); // the "c.GetComponent<character>" refers to the script on the character, and we put the "c" there because "c" is what we have hit, which has the script on it. The "UpdateScore" refers to the function within that script that we're calling

			burning = true;	
		}

		if (c.gameObject.tag == "Health") 
		{
			RegenHealth (30);
			GetComponent<AudioSource>().Play();

		}

		if (c.gameObject.tag == "Points") 
		{
			GetComponent<AudioSource>().Play();

		}

		if (c.gameObject.tag == "Damage" &! (invincibility)) 
		{
			TakeDamage(-25);
			GetComponent<AudioSource>().Play();

		}

		if (c.gameObject.tag == "Invincibility") 
		{
			Debug.Log ("invincible!");
			GetComponent<AudioSource>().Play();
			invincibility = true;

		}

	}


	
	void OnTriggerExit(Collider c) //Only works with game objects that both have colliders. Only works if at least one has a Rigidbody
	{
		burning = false;			
	}
	
	public void UpdateHealth (int value) 
	{
		//currentHealth + 20;
		Debug.Log ("healed");
	}
	
}
