using UnityEngine;
using System.Collections;
using System.IO;


public class UIManager : MonoBehaviour {

	static public GameObject CharacterPrefab;
	public GameObject Character;
	static public string FilePath = "./Saves/SavedGame.txt";

	int PlayerHealth;

	static int currentLevel;
	static public string levelState;
	static int[] Missions = {0, 0, 0};


	void Start () {
		// stop WorldManager from being destroyed
		DontDestroyOnLoad(transform.gameObject);

		CharacterPrefab = Character;
	}

	static public void SaveGame( )
	{
		//  open the file for writing
		StreamWriter file = new StreamWriter(Application.dataPath + "/Saves/SavedGame.txt");

		// write the level the Player is on to the file
		file.WriteLine(currentLevel);
		// write the Player SpawnPoint to the file
		//file.WriteLine(CurrentSpawnPointIndex);


		// check if if the player exists so the information can be stored in the file
		if (GameObject.FindWithTag("Player"))
		{
			// grab the Stat file to grab the information
			//"gameobject" looks for the game object, the get component finds its components
			PlayerHealth pHealth = GameObject.FindWithTag("Player").GetComponent<PlayerHealth>();

			// write the health of the Player to the file
			file.WriteLine(pHealth.currentHealth); // or file.WriteLine(pStats.GetHealth();

			// write the Primary Ammo of the Player to the file
			//file.WriteLine(pStats.ammoPrimary);

			// write the Secondary Ammo of the Player to the file
			//file.WriteLine(pStats.ammoSecondary);
		}

		// write the Mission status to the file
		file.WriteLine(Missions[0]);
		file.WriteLine(Missions[1]);
		file.WriteLine(Missions[2]);

		// make sure to write the information to the file
		file.Flush();

		// close the file
		file.Close();


	}

	public void SetStats( int PlayerHealth)
	{ 
		PlayerHealth playerHealth = GameObject.FindWithTag("Player").GetComponent<PlayerHealth>();	

		playerHealth.RegenHealth(PlayerHealth);
		//playerStats.AddAmmo (0, AmmoPrime, 0);
		//playerStats.AddAmmo (1, AmmoPrime, 0);
	}

	IEnumerator Initialize()
	{
		// set the state to Playing
		SetLevelState("Playing");

		// load saved gameinfo if exists
		if( !Directory.Exists( "Assets/Saves/" ) )
		{	
			// if the directory doesnt exist, create it
			Directory.CreateDirectory( "Assets/Saves/"  );
		}  

		// check to see if the file exists before tryign to read information
		if (File.Exists(Application.dataPath + "/Saves/SavedGame.txt"))
		{
			// file exists, open the file for reading
			StreamReader fileRead = new StreamReader(Application.dataPath + "/Saves/SavedGame.txt");

			// read the information stored in the file and store them in variables
			currentLevel = int.Parse(fileRead.ReadLine());    // take the info from the appropriate line and make an int
			//CurrentSpawnPointIndex = int.Parse(fileRead.ReadLine());
			PlayerHealth = int.Parse(fileRead.ReadLine());
			//AmmoPrime = int.Parse(fileRead.ReadLine());
			//AmmoAlt = int.Parse(fileRead.ReadLine());

			Missions[0] = int.Parse(fileRead.ReadLine());
			Missions[1] = int.Parse(fileRead.ReadLine());
			Missions[1] = int.Parse(fileRead.ReadLine());


			// close the file
			fileRead.Close();

		}
		// file does not exist, create with default values (Brand New Game)
		else
		{
			// set default values for the New Game being created
			currentLevel = 1;
			//CurrentSpawnPointIndex = 1;
			PlayerHealth = 100;
			//AmmoPrime = 20;
			//AmmoAlt = 20;

			Missions [0] = 0;
			Missions [1] = 0;
			Missions [2] = 0;



			// open the file for Writing
			StreamWriter file = new StreamWriter(Application.dataPath + "/Saves/SavedGame.txt");

			// write the information to the file
			file.WriteLine(currentLevel);
			//file.WriteLine (CurrentSpawnPointIndex);
			file.WriteLine(PlayerHealth);
			//file.WriteLine(AmmoPrime);
			//file.WriteLine(AmmoAlt);

			file.WriteLine(Missions [0]);
			file.WriteLine(Missions [1]);
			file.WriteLine(Missions [2]);


			//close file for writing
			file.Close();
		}

		LoadingLevels();

		while(true)
		{
			GameObject SpawnPlace = GameObject.FindWithTag("spawnPoint");	//GameObject SpawnPlace = GameObject.FindWithTag("spawnPoint" + CurrentSpawnPointIndex);	

			if(Application.GetStreamProgressForLevel(currentLevel) == 1 && SpawnPlace != null)
			{
				//SpawnPlayer(CurrentSpawnPointIndex);
				SetStats(PlayerHealth);
				break;
			}
			else
			{
				yield return new WaitForSeconds(1);
			}
		}

	}

	void LoadingLevels()
	{
		// check mission 1 status, if its not done, load level 1
		if(Missions[0]==0)
		{
			Debug.Log("Loading Level 1");
			Application.LoadLevel(currentLevel);
		}

		// check mission 2 status, if its not done, load level 1 and 2
		else if(Missions[1]==0)
		{
			Application.LoadLevel(currentLevel);
			Application.LoadLevelAdditiveAsync(currentLevel - 1);
			Debug.Log("Loading Level 1 and 2");
		}
		// check mission 3 status, if its not done, load level 1, 2 and 3
		else if(Missions[2]==0)
		{
			Application.LoadLevel(currentLevel);
			Application.LoadLevelAdditive(currentLevel - 1);
			Application.LoadLevelAdditive(currentLevel - 2);
			Debug.Log("Loading All Levels");
		}

	}
	public void StartGame()
	{
		Application.LoadLevel("Project_Lvl1");
		//GetComponent<AudioSource>().Play();

		Debug.Log ("Started Game");
		GetComponent<Light> ();

		if (Application.loadedLevel == 0 ) // starting a New Game ///////////////////////////////////////
		{
			// start the game from where the player last did well
			StartCoroutine(Initialize());

		}
	}
	
	
	public void Credits()
	{
		Application.LoadLevel("Credits");
		Debug.Log ("Credits");
	}
	
	
	public void QuitGame()
	{
		Application.Quit();
		Debug.Log ("Quit Game");
	}
	
	public void Back()
	{
		Time.timeScale = 1;
		Application.LoadLevel("MainMenu");
		Debug.Log ("Main Menu");
	}
	
	public void Options()
	{
		Application.LoadLevel("Options");
		Debug.Log ("Options");
	}
	
	
	static public int MissionStatusCheck (int missionIndex)
	{
		// what is the status of the mission
		return Missions[missionIndex];
	}

	// function is used to change the mission status, was it passed?
	static public void SetMissionStatus( int missionIndex, int status)
	{
		// status in the array is updated
		Missions[missionIndex] = status;
	}

	//changing level states
	static public void SetLevelState(string newState)
	{
		levelState = newState;
	}

//	static public void SetCheckPoint( int newCheckPoint )
//	{
//		CurrentSpawnPointIndex = newCheckPoint;
//	}

	static public void SetCurrentLevel (int newLevel)
	{
		currentLevel = newLevel;
	}
	
	
}
