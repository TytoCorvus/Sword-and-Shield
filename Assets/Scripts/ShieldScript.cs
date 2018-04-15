using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
		
	void OnCollisionEnter2D(Collision2D col){
		Debug.Log ("Hey, Listen!");
		if(col.gameObject.name == "enemy"){
				Destroy(col.gameObject);
		}
	}
}
