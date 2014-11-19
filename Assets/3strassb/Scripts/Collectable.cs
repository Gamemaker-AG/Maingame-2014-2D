using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Collider2D))]
public class Collectable : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D collision) 
	{
		Destroy(transform.gameObject);
    }
}
