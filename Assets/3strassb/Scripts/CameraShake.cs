using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour {
	public GameObject target;
	public float shakeIntensity = 2f;
	public float translationMultiplier = 0.1f;

	public Vector3 lastTargetPosition;
	public Vector3 cameraPosition;

	public void Start()
	{
		lastTargetPosition = target.transform.position;
		lastTargetPosition.z = transform.position.z;
		cameraPosition = lastTargetPosition;
		transform.position = cameraPosition;
	}

	public void ShakeCamera()
	{
		Vector3 shakePosition = new Vector3 (Random.Range (-shakeIntensity, shakeIntensity), Random.Range (-shakeIntensity, shakeIntensity), 0);
		transform.Translate (shakePosition);
	}
	
	// Update is called once per frame
	void Update () 
	{
		lastTargetPosition = target.transform.position;
		lastTargetPosition.z = camera.transform.position.z;
		Vector3 transVec = lastTargetPosition - transform.position;
		transVec.x *= translationMultiplier;
		transVec.y *= translationMultiplier;
		cameraPosition += transVec;
		transform.position = cameraPosition;
	}
}
