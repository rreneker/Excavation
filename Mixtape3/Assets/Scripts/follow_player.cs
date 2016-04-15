//This script has the camera follow the player

using UnityEngine;
using System.Collections;

public class follow_player : MonoBehaviour {

	public GameObject player;

	void SetCursorState(){
		
		Cursor.visible = false;
	}
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		SetCursorState ();

	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = new Vector3 (player.transform.position.x,player.transform.position.y, transform.position.z);

	}
}
