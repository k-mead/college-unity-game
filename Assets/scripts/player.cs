using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {

	public float speed = 5;
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

		//putting this velocity back into physics system
		ourRigidbody.velocity = velocity;




		SpriteRenderer ourSprite = GetComponent<SpriteRenderer> ();

		if (Time.time >= invulnerableEndTime) {

			ourSprite.enabled = true;
		} else {

			if (Time.time >= blinkEndTime) {
				ourSprite.enabled = !ourSprite.enabled;

				blinkEndTime = Time.time + blinkDuration;
			}
		}
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
