using UnityEngine;
using System.Collections;

public class AnimationController : MonoBehaviour {
	private Animator animator;
	private Rigidbody2D body;

	void Start () 
	{
		body = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if(body.velocity.y < 0.5f && body.velocity.y > -0.5f && gameObject.GetComponent<PlayerMovement>().isGrounded)
		{
			if(body.velocity.x == 0)
			{
				animator.Play("Standing");
			}
			else 
			{
				animator.Play("Leg");
			}
		}
		else
		{
			animator.Play("Jump");
		}
	}
}
