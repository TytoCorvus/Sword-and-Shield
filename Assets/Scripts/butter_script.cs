using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class butter_script : MonoBehaviour {

	public GameObject butter_missile;

	public GameObject target;

	public Rigidbody2D body;
	public float move_speed;

	public float harmonic_rate;
	private float harmonic_offset;

	public float time_between_turns;
	private float time_since_last_turn;

	private float direction = 1f;

	public float time_between_missiles;
	private float time_since_last_missile;
	public float distance_to_fire;

	private float time_from_wait_to_shot;

	private bool moving = true;

	// Use this for initialization
	void Start () {
		harmonic_offset = Random.Range(0f, 180f);
		time_since_last_missile = 0f;
		time_from_wait_to_shot = 0.3f;
	}

	void setup(bool moving){
		this.moving = moving; 
	}
	
	// Update is called once per frame
	void Update () {
		incTimeVariables();

		//Turning logic
		if(time_since_last_turn >= time_between_turns){
			direction *= -1f;
			time_since_last_turn = 0f;
		}

		//Movement logic
		transform.position += new Vector3(direction * move_speed * Time.deltaTime, 0f, 0f);
		transform.position += new Vector3(0f, Mathf.Cos(harmonic_offset * harmonic_rate) * move_speed * Time.deltaTime, 0f);

		//Missile firing logic
		if(target.transform.position.x - transform.position.x < distance_to_fire && time_since_last_missile < time_between_missiles){
			dropButterBomb();
			time_since_last_missile = 0f;
		}
	}

	public void incTimeVariables(){
		float time_inc = Time.deltaTime;

		time_since_last_turn += time_inc;
		time_since_last_missile += time_inc;
		harmonic_offset += time_inc;
	}

	void dropButterBomb(){
		Debug.Log("Drop bomb");
	}

	IEnumerator readyWaitFire(float time){
		yield return new WaitForSeconds(time);
		fire();
	}

	private void fire(){


	}
		
	void OnTriggerEnter2D(Collider2D col){
		if (col.name == "attack_collider"){
			Destroy (gameObject);
		}
	}

	void OnDestroy() {
		player_controller.neededButter -= 1; 
		Debug.Log(player_controller.neededButter);
	}

}
