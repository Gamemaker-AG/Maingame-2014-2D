using UnityEngine;
using System.Collections;

public class SmothFollow : MonoBehaviour {
	public Transform target;

	private Vector3 lastposition;

	void Start () 
	{
		transform.position = target.position;
		lastposition = target.position;
	}

	void FixedUpdate () 
	{
		Vector3 diffrence = lastposition - target.position;
		transform.position -= diffrence;
		lastposition = target.position;
	}
}
