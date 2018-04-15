using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_script : MonoBehaviour {

	public Transform player;
	private float lerp_amount;
	public float default_lerp_amount = 0.1f;

	public float threshhold;

	// Use this for initialization
	void Start () {
		lerp_amount = default_lerp_amount;
	}
	
	// Update is called once per frame
	void Update () {

		float distance = (new Vector2(transform.position.x, transform.position.y) - new Vector2(player.position.y, player.position.y)).magnitude;

		if(distance > threshhold){
			lerp_amount = default_lerp_amount;
		}
		else{
			lerp_amount = default_lerp_amount / 3;
		}


		Vector2 temp = Vector2.Lerp(transform.position, player.position, lerp_amount);
		//transform.position = new Vector3(player.position.x, player.position.y, -10f);
		transform.position = new Vector3(temp.x, temp.y, -10f);
	}
}
