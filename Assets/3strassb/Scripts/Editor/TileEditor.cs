using UnityEngine;
using UnityEditor;
using System.Collections;
using System;

[CustomEditor(typeof(Tile))]
public class TileEditor : Editor {	
	private Tile _target;

	public override void OnInspectorGUI () {
		DrawDefaultInspector();
		if(GUILayout.Button("Reset Tile"))
		{
			// Reseting the Tile
			_target.reset();
		}
		if(GUILayout.Button("Round Position"))
		{
			// Reseting the Tile
			_target.roundPosition();
		}
	}

	public void Awake()
	{
		_target = (Tile) target;
	}

	public void OnSceneGUI () 
	{
		if(_target.lastPosition != _target.transform.position)
		{
			var dif = _target.transform.position - _target.lastPosition;
			_target.lastPosition = _target.transform.position;
			_target.pos += dif;
		}
		Handles.color = Color.blue;
		if((_target.pos.x - _target._end.transform.position.x) > 1f)
		{
			_target.size++;
			_target.Update();
			_target.pos = _target._end.transform.position;
		}
		else if((_target.pos.x - _target._end.transform.position.x) < -1f)
		{
			_target.size--;
			_target.Update();
			_target.pos = _target._end.transform.position;
		}

		_target.pos.y = _target._end.transform.position.y;
		_target.pos = Handles.FreeMoveHandle(_target.pos,
			_target._end.transform.rotation,
			3f,
			Vector3.right,
			Handles.ArrowCap);
	}
}