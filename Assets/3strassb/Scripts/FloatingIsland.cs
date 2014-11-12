using UnityEngine;
using System.Collections;

public class FloatingIsland : MonoBehaviour {
	public Vector3 start, end;
	public float time;
	public float waitTime;
	private float elapsedTime = 0;
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
		if(elapsedTime < waitTime)
		{
			elapsedTime += Time.deltaTime;
		}
		else if(Vector3.Distance(trans.position,destination) > 0.1f)
		{
			trans.Translate(speed*Time.deltaTime);
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
