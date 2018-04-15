using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_controller : MonoBehaviour {

	public Rigidbody2D rigidbody;
	public float move_speed;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		float direction = 0f;

		if(Input.GetKey(KeyCode.LeftArrow)){
			direction -= 1f;
		}

		if(Input.GetKey(KeyCode.RightArrow)){
			direction += 1f;
		}

		if(Input.GetKey(KeyCode.Space)){
			//Add jump functionality here
		}


		rigidbody.velocity = new Vector2(direction * move_speed, rigidbody.velocity.y);
	}
}
