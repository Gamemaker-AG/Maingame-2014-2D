using UnityEngine;
using System.Collections;

public class FallDamage : MonoBehaviour {
	public float velocity = 0;
	public float damage = 0;
	private Rigidbody2D myBody;
	// Use this for initialization
	void Start () 
	{
		myBody = GetComponent<Rigidbody2D> ();
	}
	
	void FixedUpdate()
	{
		velocity = myBody.velocity.y;
		damage = -velocity * 0.1f;
		if(velocity < -25)
		{
			BroadcastMessage("TakeDamage",(int) damage,SendMessageOptions.DontRequireReceiver);
		}
	}
}
