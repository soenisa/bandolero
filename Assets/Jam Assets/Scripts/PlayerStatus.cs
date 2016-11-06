﻿using UnityEngine;
using System.Collections;

namespace Bandolero.Player {
	public class PlayerStatus : MonoBehaviour {

		public int hitpoints;
		private CharacterController controller;
		public GameObject player;


		// Use this for initialization
		void Start () {

			controller = GetComponent<CharacterController>();

			if(!player){
				Debug.Log ("Please drag player point into player variable");
			}
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
			hitpoints -= 1;
			Debug.Log (string.Format("HP: {0}", hitpoints));
		}

		void knockBack() {
			// Knockback the player (to stop continuous collision)
			Vector3 knockbackPos = player.transform.position;
			knockbackPos.x -= 1;
			player.transform.position = knockbackPos;
		}
	}
}