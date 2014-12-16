using UnityEngine;
using System.Collections.Generic;

public class FloatingIsland : MonoBehaviour {
	public Vector3 start, end;
	public float time;
	public float waitTime;
	private float elapsedTime = 0;
	private Vector3 speed;
	private Transform trans;
	private Vector3 destination;
	private HashSet<GameObject> standingObjects;

	public void Awake ()
	{
		trans = GetComponent<Transform>();
		speed = new Vector3((end.x - start.x)/time,
							(end.y - start.y)/time, 
							(end.z - start.z)/time);
		destination = end;
		standingObjects = new HashSet<GameObject>();
	}

	public void Start () {
		trans.position = start;
	}

	private void linearMotion()
	{
		trans.Translate(speed*Time.deltaTime);		
	}

	private void moveStandingObjects()
	{
<<<<<<< HEAD
		Vector2 deltaMovement = new Vector2 ((speed * Time.deltaTime).x, (speed * Time.deltaTime).y);
		foreach (GameObject obj in standingObjects)
		{
			obj.transform.Translate(deltaMovement);
=======
		foreach (GameObject obj in standingObjects)
		{
			obj.transform.Translate(speed*Time.deltaTime);
			obj.transform.Translate(0 , (speed.y > 0 ? 0.001f : -0.001f), 0);
>>>>>>> b0662d63e0329ff06f148943764d794f22d31b0d
		}
	}

	public void OnTriggerEnter2D(Collider2D coll)
	{
		standingObjects.Add(coll.gameObject);
	}

	public void OnTriggerExit2D(Collider2D coll)
	{
		standingObjects.Remove(coll.gameObject);
	}
	
	public void FixedUpdate () {
		if(elapsedTime < waitTime)
		{
			elapsedTime += Time.deltaTime;
		}
		else if(Vector3.Distance(trans.position,destination) > 0.01f)
		{
			linearMotion();
			moveStandingObjects();
		}
		else
		{
			speed = speed * -1;
			if(destination == start)
			{
				elapsedTime = 0f;
				destination = end;
				trans.position = start;
			}
			else
			{
				elapsedTime = 0f;
				destination = start;
				trans.position = end;
			}
		}
	}

	void OnDrawGizmosSelected()
    {
    	Gizmos.color = new Color(1,0,0,1f);
		Gizmos.DrawLine(start,end);
	}
}
