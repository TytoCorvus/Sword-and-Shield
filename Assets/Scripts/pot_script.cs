using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pot_script : MonoBehaviour {

	public GameObject temp_object;
	public GameObject onion_actual;

	public Sprite onion_sprite;

	public Vector2 spawn_range;

	public float multiplier;

	private float time_of_next_spawn;
	// Use this for initialization
	void Start () {
		time_of_next_spawn = Time.time + Random.Range(spawn_range.x, spawn_range.y);
	}
	
	// Update is called once per frame
	void Update () {
		if(time_of_next_spawn <= Time.time){
			spawn();
			time_of_next_spawn = Random.Range(spawn_range.x, spawn_range.y) + Time.time;
		}
	}

	public void spawn(){
		GameObject temp = Instantiate(temp_object, transform.position + new Vector3(0f, 0.8f, 0f), Quaternion.identity);
		Rigidbody2D temp_rigidbody = temp.GetComponent<Rigidbody2D>();
		temp_spawn spawn = temp.GetComponent<temp_spawn>();
		spawn.setup(onion_actual, onion_sprite);
		temp_rigidbody.velocity = Random.insideUnitCircle * multiplier + new Vector2(0f, 1.5f);
	}
}
