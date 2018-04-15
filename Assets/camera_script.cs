using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_script : MonoBehaviour {

	public Transform player;
	public float lerp_amount;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 temp = Vector2.Lerp(transform.position, player.position, lerp_amount);
		transform.position = new Vector3(temp.x, temp.y, -10f);
	}
}
