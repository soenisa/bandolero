using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour {
	
	public Canvas pauseCanvas;
	
	void Start()
	{
		// Pause screen should not be shown at Start
		pauseCanvas.enabled = false;
	}
	
	void Update () {
		
		// Check if User pressed Esc
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			
			// Call function to Pause
			Pause();
		}
	}
	
	public void Pause()
	{
		
		// Toggle Canvas off and on
		pauseCanvas.enabled = !pauseCanvas.enabled;
		
		// Change timeScale from 1 to 0 and back again
		if (Time.timeScale == 0)
			Time.timeScale = 1;
		else if (Time.timeScale == 1)
			Time.timeScale = 0;
		
		//Time.timeScale = Time.timeScale == 0 ? 1 : 0;
	}
	
	public void Quit()
	{
		Debug.Log("Quit");
		Application.Quit();
	}
}
