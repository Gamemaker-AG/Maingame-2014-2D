using UnityEngine;
using System.Collections;

public class FloatingIsland : MonoBehaviour {
	public Vector3 start, end;
	public float time;
	private Vector3 speed;
	private Transform trans;
	private Vector3 destination;

	void Awake ()
	{
		trans = GetComponent<Transform>();
		speed = new Vector3((end.x - start.x)/time,
							(end.y - start.y)/time, 
							(end.z - start.z)/time);
		destination = end;
	}

	void Start () {
		
		trans.position = start;
		
	}
	
	void FixedUpdate () {
		if(Vector3.Distance(trans.position,destination) > 0.1f)
		{
			trans.Translate(speed*Time.deltaTime);
		}
		else
		{
			speed = speed * -1;
			if(destination == start)
			{
				destination = end;
			}
			else
			{
				destination = start;
			}
		}
	}

	void OnDrawGizmosSelected()
    {
    	Gizmos.color = new Color(1,0,0,1f);
		Gizmos.DrawCube(start + new Vector3(0,0,-3), 	new Vector3(0.2f,0.2f,0.2f));
		Gizmos.DrawCube(end   + new Vector3(0,0,-3), 	new Vector3(0.2f,0.2f,0.2f));
		Gizmos.DrawLine(start,end);
	}
}
