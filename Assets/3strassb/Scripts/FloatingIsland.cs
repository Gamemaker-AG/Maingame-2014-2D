using UnityEngine;
using System.Collections;

public class FloatingIsland : MonoBehaviour {
	public Vector3 start, end;
	public float time;
	public float waitTime;
	private bool cubicTransform;
	private float elapsedTime = 0;
	private Vector3 speed;
	private Transform trans;
	private Vector3 destination;

	public void Awake ()
	{
		trans = GetComponent<Transform>();
		speed = new Vector3((end.x - start.x)/time,
							(end.y - start.y)/time, 
							(end.z - start.z)/time);
		destination = end;
	}

	public void Start () {
		
		trans.position = start;
		
	}

	private void linearMotion()
	{
		trans.Translate(speed*Time.deltaTime);		
	}

	private void cubicMotion()
	{
		var distance = destination - trans.position;

		trans.Translate(distance*Time.deltaTime);
	}
	
	public void FixedUpdate () {
		if(elapsedTime < waitTime)
		{
			elapsedTime += Time.deltaTime;
		}
		else if(Vector3.Distance(trans.position,destination) > 0.01f)
		{
			if(cubicTransform)
			{
				cubicMotion();
			}
			else
			{
				linearMotion();
			}
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
