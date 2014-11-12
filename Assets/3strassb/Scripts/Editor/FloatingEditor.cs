using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(FloatingIsland))]
public class FloatingEditor : Editor {
	private FloatingIsland _target;

	public void Awake()
	{
		_target = (FloatingIsland) target;
	}
	public void OnSceneGUI()
	{
		_target.start = Handles.FreeMoveHandle(_target.start,
			_target.transform.rotation,
			3f,
			Vector3.right,
			Handles.ArrowCap);
		_target.end = Handles.FreeMoveHandle(_target.end,
			_target.transform.rotation,
			3f,
			Vector3.right,
			Handles.ArrowCap);
		_target.transform.position = _target.start;
	}
}
