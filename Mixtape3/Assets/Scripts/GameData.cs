//This script handles game meta data and initializes the level

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameData : MonoBehaviour {

	public int funds;
	public int obj_found;
	public int total_val;
	public int remaining_dirt = 0;
	public int lowest_cost_left=10;
	public string item_name;
	public string item_desc;
	public string tomb_text;
	public int val;
	public Text cash;
	public Text art;
	public Text art_name;
	public Text art_desc;
	public Text art_val;
	public Text tot_val;
	public Text tomb_message;

	public GameObject dirty;
	public GameObject tomb;
	public GameObject sealed_tomb;
	public GameObject pers;

	public GameObject[] lv1_art;
	public GameObject[] lv2_art;
	public GameObject[] lv3_art;
	

	void Awake(){
        //procedurely creates the level

		for (int i=0; i <= 40; i++) {
			for(int j=0; j <= 20;j++){
				Vector3 pos = new Vector3(0,0,0);
				int art_chance = Random.Range (0,100);
				int art_index = Random.Range (0,4);
				pos.x = -60 + i * 3;
				pos.y = 30 - j * 3;
				GameObject curr_dirt = (GameObject) Instantiate(dirty,pos,Quaternion.identity);
				remaining_dirt++;
				dirt dir = curr_dirt.gameObject.GetComponent("dirt") as dirt;
				dir.cost = 10 + 20*(j/4);

				if( j >= 0 && j < 4){


					if(art_chance > 75 && art_chance < 95){
						dir.artifact = lv1_art[art_index];
					}else if(art_chance >= 95 && art_chance < 100){
						dir.artifact = lv2_art[art_index];
					}else if(art_chance >= 100){
						dir.artifact = lv3_art[art_index];
					}

				}else if( j >= 4 && j < 8){
					if(art_chance > 75 && art_chance < 90){
						dir.artifact = lv1_art[art_index];
					}else if(art_chance >= 90 && art_chance < 98){
						dir.artifact = lv2_art[art_index];
					}else if(art_chance >= 98){
						dir.artifact = lv3_art[art_index];
					}
				}else if( j >= 8 && j < 12){
					if(art_chance > 75 && art_chance < 85){
						dir.artifact = lv1_art[art_index];
					}else if(art_chance >= 85 && art_chance < 97){
						dir.artifact = lv2_art[art_index];
					}else if(art_chance >= 97){
						dir.artifact = lv3_art[art_index];
					}
				}else if( j >= 12 && j < 16){
					if(art_chance > 75 && art_chance < 80){
						dir.artifact = lv1_art[art_index];
					}else if(art_chance >= 80 && art_chance < 95){
						dir.artifact = lv2_art[art_index];
					}else if(art_chance >= 95){
						dir.artifact = lv3_art[art_index];
					}
				}else if( j >= 16 && j <21){
					if(art_chance > 75 && art_chance < 78){
						dir.artifact = lv1_art[art_index];
					}else if(art_chance >= 78 && art_chance < 93){
						dir.artifact = lv2_art[art_index];
					}else if(art_chance >= 93 && art_chance < 99){
						dir.artifact = lv3_art[art_index];
					}else if(art_chance == 99){

					}
				}
			}
		}

	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		GameObject[] dirt_o = GameObject.FindGameObjectsWithTag ("dirt");
		remaining_dirt = dirt_o.Length;
		bool same_lowest = false;
		int lowest = 10000;//arbitrarily high

		for (int i=0; i < dirt_o.Length; i++) {//finds lowest cost remaining
			dirt dir = dirt_o[i].GetComponent("dirt") as dirt;
			if(dir.cost == lowest_cost_left){
				same_lowest = true;
				break;
			}else if(dir.cost < lowest){
				lowest = dir.cost;
			}
		}

		if (same_lowest == false) {
			lowest_cost_left = lowest;
		}

		GameObject[] art_o = GameObject.FindGameObjectsWithTag ("artifact");

		if (art_o.Length == 0 &&(funds == 0 || funds < lowest_cost_left || remaining_dirt == 0)) {
			//GAME OVER
			persistant per = pers.gameObject.GetComponent("persistant") as persistant;
			per.art_found = obj_found;
			per.value_found = total_val;
			if(remaining_dirt == 0){
				per.reason = "Congratulations, You've excavated the entire site. YOU WIN!";
			}else{
				per.reason = "Unfortunately, you ran out of funds.";
			}
			Application.LoadLevel("_GameOver");
		}

		cash.text = "$" + funds.ToString ();
		art.text = obj_found.ToString ();
		tot_val.text = "$" + total_val.ToString ();
		art_name.text = item_name;
		art_desc.text = item_desc;
		tomb_message.text = tomb_text;
		if (val == 0) {

		} else {
			art_val.text = "$"+val.ToString ();
		}


	
	}
}
