using UnityEngine;
using System.Collections;
using UnityEngine.UI; // need this for the score display to work

public class character_score : MonoBehaviour {

	public int score; //makes the score
	public Text scoreText;//makes the score display

	// Use this for initialization
	void Start () {
	
		score = 0;

		if (!scoreText) 
		{
			scoreText = GameObject.Find ("ScoreUI").GetComponent <Text> ();// looks for "ScoreUI". As long as it is a UI Text, it's good. Helps if you forget to drag the UI Text into the variable
		}

		scoreText.text = "Score: " + score.ToString(); // takes the score value and prits it out as a string to show it on the screen
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetButtonDown ("Fire1")) 
		{
			score += 10;
			scoreText.text = "Score: " + score.ToString(); //upates the score value whenever "Fire1" is pressed. This part not needed if you use the "Get and Set" method to display your score
		}
	
	}

	public void UpdateScore(int value)// to make sure 
	{
		score += value;
		scoreText.text = "Score: " + score.ToString();
	}

// --------------------------------------------------------------------different method for displaying current score. if you are using this method, change "score" to "_score", including the varible at the top
//	public int score
//	{
//		get
//		{
//			return _score;// "name" is what the string will return
//		}
//
//		set
//		{
//			_score = value; 
//			scoreText.text = "Score: " + _score.ToString(); //upates the score value whenever "Fire1" is pressed
//		}
//	}--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------



}
