using UnityEngine;
using System.Collections;

namespace Bandolero {
	public class PlayerStatus : MonoBehaviour {

		public int hitpoints = 100;
		private CharacterController controller;
		private GameObject player;
		private UIManager UI;
		private LevelManager level;
		private bool canCollide = true;


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
			if (canCollide && hit.transform.tag == "Enemy") {
				canCollide = false;
				Debug.Log (string.Format("Enemy hit. Player.position = {0}, Enemy.position = {1}", player.transform.position, hit.transform.position));
				collideEnemy ();
			}
		}

		void collideEnemy() {
			knockBack ();

			// Damage player :'(
			hitpoints -= 10;
			UI.updateHealth (hitpoints);
			if (hitpoints <= 0) {
				gameOver ();
			}
			canCollide = true;
		}

		void knockBack() {
			// Knockback the player (to stop continuous collision)
			Vector3 knockbackPos = player.transform.position;
			knockbackPos.x -= 2;
			player.transform.position = knockbackPos;
		}

		// Disable player controller and show Game Over screen
		void gameOver() {
			controller.enabled = false;
			gameObject.GetComponent<BandaleroInputController>().enabled = false;

			UI.gameOver ();

		}
	}
}