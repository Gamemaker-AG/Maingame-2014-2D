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
		_pieces = new List<GameObject>();
	}

	void Start()
	{

		_start  = ((GameObject) Instantiate(start, trans.position, Quaternion.identity));
		_end 	= ((GameObject) Instantiate(end, trans.position, Quaternion.identity));
		_start.hideFlags = HideFlags.HideInHierarchy; 
		_end.hideFlags = HideFlags.HideInHierarchy; 
		_start.GetComponent<Transform>().parent = trans;
		_end.GetComponent<Transform>().parent = trans;
		_end.GetComponent<Transform>().Translate(new Vector3(1,0,0));
		_pieces.Add(_start);
	}

	void Update () 
	{
		print("Dinge");
		if(size != lastsize && size >= 0)
		{
			if(size > lastsize)
			{
				for(int i = 0; i < (size - lastsize); i++)
				{
					print(_pieces.Count-1);
					var curTrans = _pieces[_pieces.Count-1].GetComponent<Transform>();
					var curObj = (GameObject) Instantiate(middle, curTrans.position, Quaternion.identity);
					curObj.hideFlags = HideFlags.HideInHierarchy; 
					curObj.GetComponent<Transform>().parent = trans;
					curObj.GetComponent<Transform>().Translate(new Vector3(1,0,0));
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
	}
}
