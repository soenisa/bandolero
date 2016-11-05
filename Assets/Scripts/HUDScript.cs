using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class HUDScript : MonoBehaviour {

	public int score;
	public Text scoreText;
	public Character lv1char;
	//public Character lv2char;
	//public Character lv3char;



	// Use this for initialization
	void Start () {
	
		DontDestroyOnLoad(gameObject);

	}
	
	// Update is called once per frame
	void Update () {
	
		//add up the scores from lvl 1 2 and 3 then display em 

		score = lv1char.score;

		Debug.Log ("Current score passed from char is = " + score);


		if (!scoreText) 
		{
			scoreText = GameObject.Find ("ScoreUI").GetComponent <Text> ();// looks for "ScoreUI". As long as it is a UI Text, it's good. Helps if you forget to drag the UI Text into the variable
		}

		scoreText.text = "Score: " + score.ToString(); // takes the score value and prits it out as a string to show it on the screen

	}

	public void UpdateScore(int value)// to make sure 
	{
		score += value;
		scoreText.text = "Score: " + score.ToString();
	}

}
