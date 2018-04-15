using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class butter_missile_script : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D collision){
		if(collision.gameObject.tag == "Player"){
			//Do character stuff
			Destroy(gameObject, 0f);
		}
		else if(collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "EnemyMissile"){
			//Do nothing if it hits an enemy
			return;
		}
		else{
			Destroy(gameObject, 0f);
		}
	}
}
