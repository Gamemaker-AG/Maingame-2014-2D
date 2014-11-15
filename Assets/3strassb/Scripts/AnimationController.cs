using UnityEngine;
using System.Collections;

public class AnimationController : MonoBehaviour {
	private Animator _animation;
	private Transform _trans;
	private Vector3 _lastposition;
	
	public void Awake()
	{
		_trans = GetComponent<Transform>();
		_animation = GetComponent<Animator>();
		_lastposition = _trans.position;
	}

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(_lastposition == _trans.position)
		{
			_animation.Play("Standing");
		}
		else 
		{
			_animation.Play("Leg");
		}
		_lastposition = _trans.position;
	}
}
