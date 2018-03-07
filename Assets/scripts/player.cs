using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {

	public string toPrintclass = "Damn World";
	public float speed = 5;

	// Use this for initialization
	void Start () {
		string toPrint = "Bye Bye variable";
		Debug.Log (toPrintclass);
		string return1 = TestFunction ("Test mesage variable", 1);
		string return2 = TestFunction ("Test mesage variable", 2);
		Debug.Log ("returned1 = " + return1);
		Debug.Log ("returned2 = " + return2);
	}
	
	// Update is called once per frame
	void Update () {
		Rigidbody2D ourRigidbody = GetComponent<Rigidbody2D> ();
		ourRigidbody.velocity = Vector2.right*speed;
	}
		
	string TestFunction(string message, int count) {
		Debug.Log (message + " " + count);

		return "returned string";
	}
}
