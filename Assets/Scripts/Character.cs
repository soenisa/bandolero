using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//class must match file name
public class Character : MonoBehaviour {	//Goes into first person controller
	
	public Rigidbody Bullet; //GameObject to create
	public Rigidbody Bullet2;// second bullet for the lab
	public Rigidbody Bullet3;// 3rd bullet for the lab
	public Rigidbody WaterPower;// 3rd bullet for the lab
	public Rigidbody DoubleTapCube;//for the DOUBLE TAP
	
	public Transform projectileSpawnPoint; //Where to create GameObject
	public float projectileForce;

	public int currentgun = 1;
	
	public float tapSpeed = 0.5f; //for the double tap
	private float lastTapTime = 0; //for the double tap

	public int score;
	public Text scoreText;
	
	
	// Use this for initialization
	void Start () {

		DontDestroyOnLoad(gameObject);

		score = 0;

		if (!scoreText) 
		{
			scoreText = GameObject.Find ("ScoreUI").GetComponent <Text> ();// looks for "ScoreUI". As long as it is a UI Text, it's good. Helps if you forget to drag the UI Text into the variable
		}

		scoreText.text = "Score: " + score.ToString(); // takes the score value and prits it out as a string to show it on the screen


		if(!Bullet){
			Debug.Log ("Please drag prefab into Bullet variable");
		}
		if(!projectileSpawnPoint){
			Debug.Log ("Please drag spawn point into spawn point variable");
		}
		if (projectileForce == 0) {
			Debug.Log ("Assign a force to projectile force in inspector");
		}
		
		
		//Don't destroy Character when level changes
		//DontDestroyOnLoad (gameObject);
		
		lastTapTime = 0;//for the DOUBLE TAP
		
		
	}
	
	// Update is called once per frame
	void Update () {
		
		DontDestroyOnLoad(gameObject);


		if (Input.GetButtonDown ("Fire1")) 
		{
			score += 10;
			scoreText.text = "Score: " + score.ToString(); //upates the score value whenever "Fire1" is pressed. This part not needed if you use the "Get and Set" method to display your score
		}

		if (Input.GetKeyDown("1")) {
			currentgun=1;
			Debug.Log ("gun1");
		}
		
		if (Input.GetKeyDown("2")) {
			currentgun=2;
			Debug.Log ("gun2");
		}
		
		if (Input.GetKeyDown("3")) {
			currentgun=3;
			Debug.Log ("gun3");

				
				if((Time.time - lastTapTime) < tapSpeed){////////////
					
					Debug.Log("Double tap");///////////

					Rigidbody temp = Instantiate (DoubleTapCube, projectileSpawnPoint.position, projectileSpawnPoint.rotation) as Rigidbody;
					temp.AddForce (projectileSpawnPoint.transform.forward*projectileForce, ForceMode.Impulse);

				}//////////////////////////////////////////FOR DOUBLE TAP
				
				lastTapTime = Time.time;///////////



		}
		
		
		if (Input.GetButton ("Shoot")){
			
			if (currentgun == 1){
				Debug.Log ("Shooting 1");
				
				Rigidbody temp = Instantiate (WaterPower, projectileSpawnPoint.position, projectileSpawnPoint.rotation) as Rigidbody;
				temp.AddForce (projectileSpawnPoint.transform.forward*projectileForce, ForceMode.Impulse);
				
				
			}
			if (currentgun == 2){
				
				Debug.Log ("Water Power!");
				Rigidbody temp = Instantiate (WaterPower, projectileSpawnPoint.position, projectileSpawnPoint.rotation) as Rigidbody;
				temp.AddForce (projectileSpawnPoint.transform.forward*projectileForce, ForceMode.Impulse);
			}
			if (currentgun == 3){
				
				Debug.Log ("Shooting 3");
				Rigidbody temp = Instantiate (Bullet3, projectileSpawnPoint.position, projectileSpawnPoint.rotation) as Rigidbody;
				temp.AddForce (projectileSpawnPoint.transform.forward*projectileForce, ForceMode.Impulse);




			}
			
		}
		



		
		
	}

	public void UpdateScore(int value)// to make sure 
	{
		score += value;
		scoreText.text = "Score: " + score.ToString();
	}

}
