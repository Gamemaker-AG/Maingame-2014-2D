using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(IsleTile))]
public class IsleTileEditor : Editor {	
	private IsleTile _target;
	private Object lastone;

	public void Awake()
	{
		_target = (IsleTile) target;
	}

	public void Update()
	{
		if(lastone ==null)
			lastone = Selection.activeObject;
		if(lastone != Selection.activeObject)
		{
			lastone = Selection.activeObject;
			_target.pos = _target._end.transform.position;
		}
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
			2f,
			Vector3.right,
			Handles.ArrowCap);
	}
}