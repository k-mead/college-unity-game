using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goomba : MonoBehaviour {

	//public variables
	public float damage = 5;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//called when trigger collides with another collider
	void OnTriggerStay2D(Collider2D other)
	{
		//Attempting to get player script from the thing we collided with
		player playerScript = other.GetComponent<player> ();

		//if the player scrpt exists on thing collided with
		if (playerScript != null) {
			//call the damage function
			playerScript.Damage (damage);

			Debug.Log ("Goomba Dealt damage to player = " + damage);
		}// end of if 
	}//end ontriggerenter2d()

}
