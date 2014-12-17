using UnityEngine;
using System.Collections;

public class RidgidbodyDebug : MonoBehaviour {
	public Vector2 Velocity;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Velocity = rigidbody2D.velocity;
	}
}
