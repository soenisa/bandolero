using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Bandolero {
	public class UIManager : MonoBehaviour {

		public Text HP_text;
		public Text gameOver_text;
		public GameObject player;
		private PlayerStatus playerStat;
		public Canvas canvas;

		// Use this for initialization
		void Start () {
			playerStat = player.GetComponent<PlayerStatus>();
			HP_text.text = string.Format ("HP {0}", playerStat.hitpoints);
		}
		
		// Update is called once per frame
		void Update () {
		
		}

		// Update health display
		public void updateHealth(int hp) {
			HP_text.text = string.Format ("HP {0}", hp);
		}

		public void gameOver() {
			Vector3 pos = Vector3.zero;
			Text go = Instantiate (gameOver_text, canvas.transform) as Text;
			go.rectTransform.anchoredPosition = Vector2.zero;
		}
	}
}