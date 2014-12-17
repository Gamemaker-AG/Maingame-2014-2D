using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour {
	public GameObject target;
	public float shakeIntensity = 2f;
	public float translationMultiplier = 0.1f;
	public int shakesPerHit = 10;

	private Vector3 lastTargetPosition;
	private Vector3 cameraPosition;

	private int shakesRemaining = 0;

	public void Start()
	{
		lastTargetPosition = target.transform.position;
		lastTargetPosition.z = transform.position.z;
		cameraPosition = lastTargetPosition;
		transform.position = cameraPosition;
	}

	public void ShakeCamera()
	{
		shakesRemaining = shakesPerHit;
	}

	public void ShakeOneTime()
	{
		Vector3 shakePosition = new Vector3 (Random.Range (-shakeIntensity, shakeIntensity), Random.Range (-shakeIntensity, shakeIntensity), 0);
		transform.Translate (shakePosition);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (shakesRemaining-- > 0)
			ShakeOneTime ();

		lastTargetPosition = target.transform.position;
		lastTargetPosition.z = camera.transform.position.z;
		Vector3 transVec = lastTargetPosition - transform.position;
		transVec.x *= translationMultiplier;
		transVec.y *= translationMultiplier;
		cameraPosition += transVec;
		transform.position = cameraPosition;
	}
}
