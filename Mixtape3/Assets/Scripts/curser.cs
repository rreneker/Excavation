//This script handles the code for the curser

using UnityEngine;
using System.Collections;

public class curser : MonoBehaviour {

	public GameObject player;
	public GameObject game;
	public float dist;

	public float angle;

	public float x_val;
	public float y_val;

	public AudioSource mine;


	// Use this for initialization
	void Start () {
		player = this.transform.parent.gameObject;
		Renderer rend = GetComponent<Renderer> ();
		rend.material.SetColor ("_Color", Color.red);
		rend.material.renderQueue = 10000;


	}

	// Update is called once per frame
	void Update () {
        //This handles the current location of the curser object
		player = this.transform.parent.gameObject;
		Vector3 mouse_pos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		mouse_pos.z = 0;

		angle = Mathf.Atan2 (mouse_pos.y - player.transform.position.y, mouse_pos.x - player.transform.position.x);
		x_val = Mathf.Cos (angle) * dist;
		y_val = Mathf.Sin (angle) * dist;
		mouse_pos.x = player.transform.position.x + Mathf.Cos (angle) * dist;
		mouse_pos.y = player.transform.position.y + Mathf.Sin (angle) * dist;

		this.transform.position = mouse_pos;
	}

	void OnTriggerStay(Collider other){
        //This handles the showing of the cost to excavate a block of dirt as well as whether the block can be excavated
		GameData data = game.gameObject.GetComponent ("GameData") as GameData;
		if (other.gameObject.tag == "dirt" && Input.GetMouseButtonDown (0)) {
			dirt dir = other.gameObject.GetComponent("dirt") as dirt;
			if(dir.cost <= data.funds){
				mine.Play();
				dir.Destroy();
				Destroy (other.gameObject);
			}
		} else if (other.gameObject.tag == "dirt") {
			dirt dir = other.gameObject.GetComponent("dirt") as dirt;
			dir.show_cost = true;
		}

	}

	void OnTriggerExit(Collider other){
        //removes the cost from the screen when the curser is no longer on it
		if (other.gameObject.tag == "dirt") {
			dirt dir = other.gameObject.GetComponent("dirt") as dirt;
			dir.show_cost = false;
		}
	}
}
