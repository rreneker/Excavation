//handles the game over screen logic

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class play_again : MonoBehaviour {

	public GameObject pers;

	public Text reason;
	public Text summary;
	public Text rank;

	// Use this for initialization
	void Start () {
		pers = GameObject.FindGameObjectWithTag ("pers");
		persistant per = pers.gameObject.GetComponent ("persistant") as persistant;
		reason.text = per.reason;
		summary.text = "You found a total of " + per.art_found.ToString () + " artifacts, worth a total of $" + per.value_found.ToString ();

		if (per.value_found < 100) {
			rank.text = "Rank: Flunked Out";
		} else if (per.value_found >= 100 && per.value_found < 200) {
			rank.text = "Rank: Freshman Student";
		} else if (per.value_found >= 200 && per.value_found < 500) {
			rank.text = "Rank: Undergraduate";
		} else if (per.value_found >= 500 && per.value_found < 2000) {
			rank.text = "Rank: Graduate Student";
		} else if (per.value_found >= 2000 && per.value_found < 10000) {
			rank.text = "Rank: Masters in Archeology";
		} else if (per.value_found >= 10000) {
			rank.text = "Rank: PHD in Archeology";
		}
	}
	
	// Update is called once per frame
	void Update () {


		if (Input.GetKey (KeyCode.Space)) {
			Destroy(pers.gameObject);
			Application.LoadLevel("_MainLevel");
		}
	}
}
