using UnityEngine;
using System.Collections;

public class AutoShoot : MonoBehaviour {
	public LayerMask targetLayer;
	public float fireRate = 2f;
	public float fireRadius = 2f;
	public float bulletSpeed = 10f;
	public GameObject projectile;
	private float cooldown = 0f;
	private int layer;
	// Use this for initialization
	void Start () 
	{
		//Debug.Log(gameObject.name + " is looking for Target in Layer " + targetLayer + " : " + targetLayer.value );
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if(cooldown <= 0)
		{
			Collider2D[] potentialTargets = Physics2D.OverlapCircleAll(transform.position,fireRadius,targetLayer.value);

			if(potentialTargets.Length > 0)
			{
				Vector3 lookRatation = potentialTargets[0].transform.position - transform.position;
				GameObject obj = (GameObject) Instantiate(projectile,transform.position, Quaternion.LookRotation(Vector3.forward, lookRatation));
				obj.transform.Rotate(new Vector3(0,0,90));
				obj.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(bulletSpeed,0), ForceMode2D.Impulse);
				cooldown = 1/fireRate;
			}
		}
		else
		{
			cooldown -= Time.deltaTime;
		}
	}
}
