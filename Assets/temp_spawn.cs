using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class temp_spawn : MonoBehaviour {

	private GameObject obj;
	public SpriteRenderer sprite_renderer;

	// Use this for initialization
	void Start () {
		
	}
	
	public void setup(GameObject obj, Sprite image){
		this.obj = obj;
		sprite_renderer.sprite = image;
	}

	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other){
		Debug.Log("Detected");
		if(other.gameObject.tag != "Enemy" && other.gameObject.tag != "EnemyMissile") {
			Instantiate(obj, transform.position, Quaternion.identity);
			Destroy(gameObject, 0f);
		}
	}
}
