using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onion_script : MonoBehaviour {

	public float timeUntilTurning;
	private float timeRunning;

	private float timeTilNextJump;
	public float move_speed;

	public Rigidbody2D body;

	public int direction;

	public Vector2 random_range;

	// Use this for initialization
	void Start () {
		direction = 1;
		timeTilNextJump = Random.Range(random_range.x, random_range.y);
	}
	
	// Update is called once per frame
	void Update () {

		timeTilNextJump -= Time.deltaTime;
		if(timeTilNextJump <= 0f){
			body.velocity = new Vector2(body.velocity.x, move_speed * 2.5f);
			timeTilNextJump = Random.Range(random_range.x, random_range.y);
		}

		timeRunning += Time.deltaTime;
		if(timeRunning >= timeUntilTurning){
			timeRunning = 0f;
			direction = direction * -1;
		}

		transform.position += new Vector3((float)direction * move_speed * Time.deltaTime, 0f, 0f);
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.name == "attack_collider"){
			Destroy (gameObject);
		}
	}

	void OnDestroy() {
		player_controller.neededOnions -= 1; 
		Debug.Log(player_controller.neededOnions);
	}
}
