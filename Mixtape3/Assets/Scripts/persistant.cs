//used to transfer data from the level scene to the game over scene

using UnityEngine;
using System.Collections;

public class persistant : MonoBehaviour {

	public int art_found;
	public int value_found;
	public string reason;

	void Awake(){
		DontDestroyOnLoad (transform.gameObject);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
