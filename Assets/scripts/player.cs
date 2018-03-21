using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {

	public float speed = 5;
	public float jumpSpeed = 10;
	public bool hasDoubleJumped = false;
	public float health = 100;
	public float invulnerableDuration = 1;
	public float blinkDuration = 0.25f;
	private float invulnerableEndTime = 0;
	public float blinkEndTime = 0;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		Rigidbody2D ourRigidbody = GetComponent<Rigidbody2D> ();
		//ourRigidbody.velocity = Vector2.right*speed;

		float horizontal = Input.GetAxis ("Horizontal");

		//get current Velocity from physics system
		Vector2 velocity = ourRigidbody.velocity;

		//set velocity based on input and speed value
		velocity.x = horizontal * speed;

		//Determine if touching ground
		Collider2D ourCollider = GetComponent<Collider2D>();

		LayerMask groundLayer = LayerMask.GetMask ("Ground");

		//ask collider if touching layer
		bool isTouchingGround = ourCollider.IsTouchingLayers(groundLayer);

		if (isTouchingGround == true) {
			hasDoubleJumped = false;
		}
		bool allowedToJump = isTouchingGround;

		if (isTouchingGround == false && hasDoubleJumped == false) {
			allowedToJump = true;
		}
		//jump logic
		bool jumpPressed = Input.GetButtonDown("Jump");


		//
		if (jumpPressed == true && isTouchingGround == true) {
			velocity.y = jumpSpeed;

			if (isTouchingGround == false)
				hasDoubleJumped = true;
		}

		//putting this velocity back into physics system
		ourRigidbody.velocity = velocity;




		SpriteRenderer ourSprite = GetComponent<SpriteRenderer> ();

		//flip the sprite on x-axis only if velocity < 0 
		ourSprite.flipX = velocity.x < 0;

		if (Time.time >= invulnerableEndTime) {

			ourSprite.enabled = true;
		} else {

			if (Time.time >= blinkEndTime) {
				ourSprite.enabled = !ourSprite.enabled;

				blinkEndTime = Time.time + blinkDuration;
			}
		}
		//Mouse Test
		//check if mouse buton pressed
//		if (Input.GetMouseButtonDown(0) == true) {
//			Debug.Log ("Mouse left Button Just Pressed");
//		}
//
//		if (Input.GetMouseButton(0) == true) {
//			Debug.Log ("Mouse left Button Held");
//		}
//
//		if (Input.GetMouseButtonUp(0) == true) {
//			Debug.Log ("Mouse left Button Just Pressed");
//		}
//
//		if (Input.GetMouseButtonDown(1) == true) {
//			Debug.Log ("Mouse right Button Just Pressed");
//		}
//		Debug.Log ("Mouse Position = " + Input.mousePosition);
		//ourSprite.enabled = false
}

	public void Damage(float damageToDeal)
	{
		if (Time.time >= invulnerableEndTime) {
			health = health - damageToDeal;

			//TODO: Handle Death

			//Set us as invlnerable for a set duration
			invulnerableEndTime = Time.time + invulnerableDuration;



			Debug.Log ("Damage was dealt");
			Debug.Log ("damageToDeal = " + damageToDeal);
			Debug.Log ("health = " + health);
		}
	}//end Damage()
		


}
