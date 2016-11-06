using UnityEngine;
using System.Collections;

namespace Bandolero {
	public class PlayerStatus : MonoBehaviour {

		public int hitpoints = 100;
		private CharacterController controller;
		private GameObject player;
		private UIManager UI;
		private LevelManager level;


		// Use this for initialization
		void Start () {

			controller = GetComponent<CharacterController>();
			UI = GameObject.Find("LevelManager").GetComponent<UIManager>();
			level = GameObject.Find ("LevelManager").GetComponent<LevelManager> ();
			player = gameObject;
		}
		
		// Update is called once per frame
		void Update () {

		}

		void OnControllerColliderHit(ControllerColliderHit hit){
			if (hit.transform.tag == "Enemy") {
				Debug.Log ("we hit an enemy!");
				collideEnemy ();
			}
		}

		void collideEnemy() {
			knockBack ();

			// Damage player :'(
			hitpoints -= 10;
			Debug.Log (string.Format("HP: {0}", hitpoints));
			UI.updateHealth (hitpoints);
			if (hitpoints <= 0) {
				gameOver ();
			}
		}

		void knockBack() {
			// Knockback the player (to stop continuous collision)
			Vector3 knockbackPos = player.transform.position;
			knockbackPos.x -= 1;
			player.transform.position = knockbackPos;
		}

		void gameOver() {
			controller.enabled = false;
			gameObject.GetComponent<BandaleroInputController>().enabled = false;

			UI.gameOver ();

		}
	}
}