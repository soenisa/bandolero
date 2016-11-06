using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UI_Manager : MonoBehaviour {

	public Text HP_text;
	public GameObject player;
	private Component playeStat;

	// Use this for initialization
	void Start () {
		playerStat = player.GetComponent<"Player Status"> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
