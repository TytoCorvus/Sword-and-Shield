using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pot_script : MonoBehaviour {

	public GameObject temp_object;
	public GameObject onion_actual;

	public Vector2 spawn_range;

	private float time_of_next_spawn;
	// Use this for initialization
	void Start () {
		time_of_next_spawn = Time.time + Random.Range(spawn_range.x, spawn_range.y);
	}
	
	// Update is called once per frame
	void Update () {
		if(time_of_next_spawn <= Time.time){
			spawn();
		}
	}

	public void spawn(){

	}
}
