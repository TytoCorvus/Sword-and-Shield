using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player_controller : MonoBehaviour {

	public Rigidbody2D rigidbody;
	public GameObject jul;
	public GameObject brs;

	public float move_speed;
	public float jump_speed;
	private float old_dir = 0f;

	public Transform groundCheck;

	public Transform Shield;

	IList<Collider2D> hitlist = new List<Collider2D>();

	public float timeLeft = 300f;
	public int minutesLeft;
	public int secondsLeft;
	public Text timerText;
	
	public static int neededTomato = 10;
	public static int neededOnions = 10;
	public static int neededButter = 5;

	public Animator jul_AC;
	public Animator brs_AC;

	public BoxCollider2D attackCollider;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float direction = 0f;


		timeLeft -= Time.deltaTime;
		minutesLeft = (int) (timeLeft / 60);
		secondsLeft = (int) (timeLeft % 60);

		//timerText.text = minutesLeft.ToString() + ":"+ secondsLeft.ToString();

		//Jumping and movement
		if(Input.GetKey(KeyCode.LeftArrow)){
			direction -= 1f;
			jul_AC.SetBool("isRunning", true);
			brs_AC.SetBool("isRunning", true);
		}

		if(Input.GetKey(KeyCode.RightArrow)){
			direction += 1f;
			jul_AC.SetBool("isRunning", true);
			brs_AC.SetBool("isRunning", true);
		}

		if (!Input.GetKey (KeyCode.RightArrow))
		if (!Input.GetKey (KeyCode.LeftArrow)) {
			jul_AC.SetBool ("isRunning", false);
			brs_AC.SetBool ("isRunning", false);
		}
			
		if(Input.GetKeyDown(KeyCode.Space) && checkIsGrounded()){
			rigidbody.velocity = new Vector2(rigidbody.velocity.x, jump_speed);
		}

		if(Input.GetKeyUp(KeyCode.Space)){
			rigidbody.velocity = new Vector2(rigidbody.velocity.x, Mathf.Min(rigidbody.velocity.y, jump_speed/10));
		}


		//Attack script
		if (Input.GetKey (KeyCode.X)) {
			attackCollider.enabled = true;
		} else {
			attackCollider.enabled = false;
		}

		//Gravity stuff
		if(rigidbody.velocity.y < -1f){
			rigidbody.gravityScale = 4.5f;
		}
		else{
			rigidbody.gravityScale = 2f;
		}

		rigidbody.velocity = new Vector2(direction * move_speed, rigidbody.velocity.y);

		Vector3 theScale = transform.localScale;

		if (Mathf.Sign (direction) != Mathf.Sign (old_dir) && direction != 0f) {
			theScale.x *= -1; 
			transform.localScale = theScale;
		}

		if (direction != 0f) {
			old_dir = direction;

			//store shield hitbox above head.
			Shield.transform.eulerAngles = new Vector3(0,0,90);
			Shield.transform.localPosition = new Vector3 (0.05f, 0.9f, 0.0f);

		} else {
			//Reset shield hitbox to front. 
			Shield.transform.eulerAngles = new Vector3(0,0,0);
			Shield.transform.localPosition = new Vector3 (0.5f, 0.21f, 0.0f);
		}

	}
		
	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.name == "enemy"){
			hitlist.Add(col.otherCollider);
			//Debug.Log (hitlist[0]);
		}
			
	}

	void LateUpdate(){
		foreach (var el in hitlist)
			Debug.Log(el);

		hitlist.Clear();
	}

	public bool checkIsGrounded(){
		RaycastHit2D grounded = Physics2D.Linecast(groundCheck.position , groundCheck.position - new Vector3(0f, .1f, 0f));
		if (grounded.transform != null) {
			return true;
		} 
		else {
			return false;
		}
	}
}