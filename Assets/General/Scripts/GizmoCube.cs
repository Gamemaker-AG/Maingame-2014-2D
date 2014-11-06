using UnityEngine;
using System.Collections;

public class GizmoCube : MonoBehaviour
{
	void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1,0,0,0.2f);
        Gizmos.DrawCube(transform.position, transform.localScale);
	}
}
