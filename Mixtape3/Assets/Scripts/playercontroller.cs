//controls the player

using UnityEngine;
using System.Collections;

public class playercontroller : MonoBehaviour {

	public Rigidbody rb;
	public bool can_jump = false;
	public float acc;
	public GameObject gamedata;
	public bool show_mess = false;
	public bool facing_dir = true; // true for right, false for left
	public string last_art_name;
	public string last_art_desc;
	//int window_index = 0;
	public Rect show;

	public AudioSource pickup;

	private GUIStyle style;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		style = new GUIStyle ();
		style.normal.textColor = Color.red;
		style.alignment = TextAnchor.UpperCenter;
		style.wordWrap = true;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetKeyDown ("w") && can_jump == true) {
			rb.velocity = new Vector3(rb.velocity.x,10,0);
			can_jump = false;
		}

		if (Input.GetKey ("a") ) {
			if(facing_dir == true){
				facing_dir = false;
				Vector3 direction = transform.localScale;
				direction.x = -1*direction.x;
				transform.localScale = direction;
			}
			if(rb.velocity.x > -10){
				rb.velocity -= new Vector3(acc,0,0);
			}
		} else if (Input.GetKey ("d")) {
			if(facing_dir == false){
				facing_dir = true;
				Vector3 direction = transform.localScale;
				direction.x = -1*direction.x;
				transform.localScale = direction;
			}

			if(rb.velocity.x < 10){
				rb.velocity += new Vector3(acc,0,0);
			}
		} 



	}

	void OnCollisionEnter(Collision other){
		if (other.gameObject.tag == "floor" || other.gameObject.tag == "dirt") {
			can_jump = true;
		}

		if (other.gameObject.tag == "artifact") {
			GameData game = gamedata.GetComponent("GameData") as GameData;
			artifact art = other.gameObject.GetComponent("artifact") as artifact;
			pickup.Play();
			game.item_name = art.item;
			game.item_desc = art.desc;
			game.val = art.value;
			game.funds += art.value;
			game.obj_found++;
			game.total_val += art.value;
			Destroy(other.gameObject);

		}
	}


    /* This area represents a feature that was initially planned but never implemented due to game design reasons
	void OnTriggerStay(Collider other){
		if (other.gameObject.tag == "tomb") {
			GameData game = gamedata.GetComponent("GameData") as GameData;
			game.tomb_text = "Press 'E' to Enter Tomb";
		}
		if (other.gameObject.tag == "tomb" && Input.GetKey ("e")) {

		}
	}

	void OnTriggerExit(Collider other){
		if (other.gameObject.tag == "tomb") {
			GameData game = gamedata.GetComponent("GameData") as GameData;
			game.tomb_text = "";
		}
	}

    */


}
