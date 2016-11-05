using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealth2 : MonoBehaviour {

	public int currentHealth;						// Current health of player
	public Image damageImage;						// Reference to an image to flash on the screen on being hurt.
	
	float flashSpeed = 5.0f;					// Speed damageImage fades
	Color flashColour = new Color(1, 0, 0, 0.1f);// Colour of damageImage is set to, to flash.
	
	bool isDead;					// Whether the player is dead.
	public bool damaged;						// True when the player gets damaged.
	
	public RectTransform healthTransform;
	float cachedY;					// Used to keep Health Filler at same Y Axis
	float minXValue;				// Used to keep track of Health Filler min X, auto calculated
	float maxXValue;				// Used to keep track of Health Filler min X, auto calculated
	
	public int maxHealth = 100;					// Max health player can have
	public Text healthText;						// Text UI that can show health
	
	public Image visualHealth; 					// Image UI Health Fill

	// Use this for initialization
	void Start () {
		cachedY = healthTransform.position.y;
		minXValue = healthTransform.position.x - healthTransform.rect.width;
		maxXValue = healthTransform.position.x;
		currentHealth = maxHealth;
		
		visualHealth.color = new Color32(0, 255, 0, 255);
	}
	
	// Update is called once per frame
	void Update () {
		// If the player has just been damaged...
		if(damaged)
		{
			// ... set the colour of the damageImage to the flash 
			damageImage.color = flashColour;
		}
		// Otherwise...
		else
		{
			// ... transition the colour back to clear.
			damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
		}
		
		// Reset the damaged flag.
		damaged = false;
		
		if(Input.GetKeyDown(KeyCode.H))
		{
			TakeDamage(10);
		}
	}

	void TakeDamage (int amount)
	{
		// Set the damaged flag so the screen will flash.
		damaged = true;
		
		// Reduce the current health by the damage amount.
		currentHealth -= amount;
		
		// Set the health bar's value to the current health.
		// healthSlider.value = currentHealth;
		HandleHealth();
		
		// If the player has lost all it's health and the death flag hasn't been set yet...
		if(currentHealth <= 0 && !isDead)
		{
			// ... it should die.
			isDead = true;
		}
	}

	void RestartLevel ()
	{
		// Reload the level that is currently loaded.
		Application.LoadLevel (Application.loadedLevel);
	}

	private float MapValues(float x, float inMin, float inMax, float outMin, float outMax)
	{
		return Mathf.Floor((x - inMin) * (outMax - outMin) / (inMax - inMin) + outMin);
	}
	
	private void HandleHealth()
	{
		//healthText.text = "Health: " + currentHealth2;
		
		float currentXValue = MapValues(currentHealth, 0, maxHealth, minXValue, maxXValue);
		
		healthTransform.position = new Vector3(currentXValue, cachedY );
		
		if(currentHealth > maxHealth/2)
		{
			visualHealth.color = new Color32(0, 255, 0, 255);
		}
		else
		{
			visualHealth.color = new Color32(255, 0, 0, 255);
		}
	}
}
