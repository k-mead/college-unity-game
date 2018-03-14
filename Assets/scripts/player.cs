using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {

	public float speed = 5;
	public float health = 100;
	public float invulnerableDuration = 1;

	private float invulnerableEndTime = 0;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		Rigidbody2D ourRigidbody = GetComponent<Rigidbody2D> ();
		ourRigidbody.velocity = Vector2.right*speed;


		SpriteRenderer ourSprite = GetComponent<SpriteRenderer> ();
		ourSprite.enabled = false
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
