using UnityEngine;
using System.Collections.Generic;

[ExecuteInEditMode]
public class IsleTile : MonoBehaviour 
{
	public GameObject start, middle, end;
	public int size = 0;
	private int lastsize = 0;
	private Transform trans;
	private List<GameObject> _pieces;
	private GameObject _start, _end;

	void Awake()
	{
		trans = GetComponent<Transform>();
		fixchildren();
	}

	private void fixchildren()
	{
		for(int i = 0; i < trans.childCount; i++)
		{
			DestroyImmediate(trans.GetChild(0).gameObject);
		}
		_pieces = new List<GameObject>();
	}

	private bool checkList()
	{
		if(_pieces == null)
		{
			_pieces = new List<GameObject>();
			return false;
		}
		return true;
	}

	private void setupStartEndPoints()
	{
		checkList();

		_start  = (GameObject) Instantiate(start, trans.position, trans.rotation);
		_start.hideFlags = HideFlags.HideInHierarchy;
		_start.GetComponent<Transform>().parent = trans; 
		_start.GetComponent<Transform>().Translate(new Vector3(0,0,0),Space.Self);

		_pieces.Add(_start);

		_end 	= (GameObject) Instantiate(end, trans.position, trans.rotation);
		_end.hideFlags = HideFlags.HideInHierarchy; 
		_end.GetComponent<Transform>().parent = trans;
		_end.GetComponent<Transform>().Translate(new Vector3(1,0,0),Space.Self);
	}

	private void resize()
	{
		if(size > lastsize)
		{
			for(int i = 0; i < (size - lastsize); i++)
			{
				var curTrans = _pieces[_pieces.Count-1].GetComponent<Transform>();
				var curObj = (GameObject) Instantiate(middle, curTrans.position, curTrans.rotation);
				curObj.hideFlags = HideFlags.HideInHierarchy; 
				curObj.GetComponent<Transform>().parent = trans;
				curObj.GetComponent<Transform>().Translate(new Vector3(1,0,0),Space.Self);
				_pieces.Add(curObj);
			}
		}
		else
		{
			for(int i = 0; i < (lastsize - size); i++)
			{
				DestroyImmediate(_pieces[_pieces.Count-1]);
				_pieces.RemoveAt(_pieces.Count-1);
			}
		}
		lastsize = size;
		var lastTrans = _pieces[_pieces.Count-1].GetComponent<Transform>();
		_end.GetComponent<Transform>().position = lastTrans.position;
		_end.GetComponent<Transform>().Translate(new Vector3(1,0,0));
	}

	void Start()
	{
		fixchildren();
		setupStartEndPoints();
	}

	void Update () 
	{
		checkList();

		if(size == -1)
		{
			fixchildren();
			setupStartEndPoints();
		}


		if(_start == null && _end == null &&
			start != null && end != null)
		{
			fixchildren();
			setupStartEndPoints();
		}

		if(size != lastsize && size >= 0)
		{
			resize();
		}
	}
}
