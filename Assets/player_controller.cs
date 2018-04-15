using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_controller : MonoBehaviour {

	public Rigidbody2D rigidbody;
	public BoxCollider2D collider;


	private float grounded_distance = 0.01f;
	public float move_speed;
	public float jump_speed;


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

		if(Input.GetKeyDown(KeyCode.Space)){
			rigidbody.velocity = new Vector2(rigidbody.velocity.x, jump_speed);
		}

		if(Input.GetKeyUp(KeyCode.Space)){
			rigidbody.velocity = new Vector2(rigidbody.velocity.x, Mathf.Min(rigidbody.velocity.y, jump_speed/10));
		}

		if(rigidbody.velocity.y < -1f){
			rigidbody.gravityScale = 4.5f;
		}
		else{
			rigidbody.gravityScale = 2f;
		}

		rigidbody.velocity = new Vector2(direction * move_speed, rigidbody.velocity.y);
	}

	public void checkIsGrounded(){
		
		//RaycastHit2D[] below = Physics2D.BoxCastAll(transform.position, );
	}
}