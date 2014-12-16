using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Collider2D))]
public class Bullet : MonoBehaviour {
	public LayerMask mask;
	public int damage = 5;
	public AudioClip onHit;
	private float ignoreCollision = 0.05f;

	void OnTriggerEnter2D(Collider2D collision) 
	{
		Hit (collision);
	}

	private void Hit(Collider2D collision)
	{
		if(ignoreCollision < 0)
		{
			collision.SendMessage ("TakeDamage", damage, SendMessageOptions.DontRequireReceiver);
			Destroy (gameObject);
			if(onHit)
			{
				AudioSource.PlayClipAtPoint(onHit, transform.position);
			}
		}
	}

	void FixedUpdate()
	{
		ignoreCollision -= Time.deltaTime;
		if(ignoreCollision < 0)
		{
			Vector2 pos = new Vector2 (transform.position.x, transform.position.y);
			Vector2 velo = new Vector2 (rigidbody2D.velocity.x * Time.deltaTime, rigidbody2D.velocity.y * Time.deltaTime);
			RaycastHit2D hit = Physics2D.Linecast (pos, pos + velo,mask);
			if (hit.collider != null) 
			{
				Hit (hit.collider);
			}
		}
	}
}
