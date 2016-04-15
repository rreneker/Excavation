//This script holds data for the blocks of dirt as well as destruction events and GUI updates

using UnityEngine;
using System.Collections;

public class dirt : MonoBehaviour {

	public int depth;
	public int pos_from_left;
	public GameObject artifact;
	public GameObject controller;
	public int cost;
	public bool show_cost;
	Camera camera;

	

	private GUIStyle style1;

	// Use this for initialization
	void Start () {
		show_cost = false;
		style1 = new GUIStyle ();
		style1.normal.textColor = Color.red;
		style1.alignment = TextAnchor.UpperLeft;
		style1.wordWrap = true;
		camera = Camera.main;
		controller = GameObject.FindGameObjectWithTag ("cont");
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Destroy(){
        //destruction actions
		GameData data = controller.GetComponent ("GameData") as GameData;
		data.funds -= cost;
		if (artifact != null) {
			Instantiate(artifact, transform.position, Quaternion.identity);
		}
	}

	void OnGUI(){
        //displays the cost to excavate the block when show_cost is true
		string cost_string = "-$" + cost.ToString();
		Vector3 label_pos = camera.WorldToScreenPoint(transform.position);
		label_pos.y = camera.pixelHeight - label_pos.y;
		if (show_cost == true) {
			GUI.Label (new Rect (label_pos.x, label_pos.y, 50, 10), cost_string, style1);
		}
	}
}
