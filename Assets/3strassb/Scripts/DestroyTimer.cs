using UnityEngine;
using System.Collections;

public class DestroyTimer : MonoBehaviour {
	public float lifeTime = 1f;
	// Update is called once per frame
	void Update () {
		Destroy(gameObject,lifeTime);
	}
}
