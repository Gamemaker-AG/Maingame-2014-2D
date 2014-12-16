﻿using UnityEngine;
using System.Collections;

public class PlayerGun : MonoBehaviour 
{
	public GameObject projectile;
	public float crosshairScale = 1.0f;
	public float fireRate = 1f;
	public float bulletSpeed = 10f;
	public Material lineMaterial;
	private float cooldown = 0f;
	private LineRenderer lineRender;
	private Camera gameCamera;
	private GameObject pentagon;
	private Vector3[] PentagonVertices = 
	{
		new Vector3(-0.5f,1,0),
		new Vector3(0.5f,1,0),
		new Vector3(1.1f,0,0),
		new Vector3(0f,-1,0),
		new Vector3(-1.1f,0,0),
		new Vector3(-0.5f,1,0)
	};

	void Start () 
	{
		lineRender = (LineRenderer) gameObject.AddComponent("LineRenderer");
		lineRender.material = lineMaterial;
		lineRender.SetWidth(0.025f, 0.025f);
		lineRender.SetVertexCount(2);
		gameCamera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
		setupPentagon();
		Screen.showCursor = false;
	}

	private void setupPentagon()
	{
		pentagon = new GameObject();
		pentagon.AddComponent<LineRenderer>();

		LineRenderer  renderer = pentagon.GetComponent<LineRenderer>();

		renderer.SetVertexCount(6);
		renderer.material = new Material(Shader.Find("Particles/Additive"));
		renderer.SetWidth(0.025f, 0.025f);

		for(int i = 0; i < 6; i++)
		{
			PentagonVertices[i].x *= crosshairScale;
			PentagonVertices[i].y *= crosshairScale;
		}
	}

	private void updatePentagon(Vector3 pos)
	{
		LineRenderer  renderer = pentagon.GetComponent<LineRenderer>();
		for(int i = 0; i < 6; i++)
		{
			renderer.SetPosition(i, PentagonVertices[i]+pos);
		}
	}

	void FixedUpdate()
	{
		if(Input.GetMouseButton(0) && cooldown < 0)
		{
			cooldown = 1f/fireRate;
			Vector3 lookRatation = ( gameCamera.ScreenToWorldPoint(Input.mousePosition) - transform.position);
			GameObject obj = (GameObject) Instantiate(projectile,transform.position, Quaternion.LookRotation(Vector3.forward, lookRatation));
			obj.transform.Rotate(new Vector3(0,0,90));
			obj.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(bulletSpeed,0), ForceMode2D.Impulse);
		}
		cooldown -= Time.deltaTime;
	}
	
	void Update () 
	{
		Vector3 mousePos = gameCamera.ScreenToWorldPoint(Input.mousePosition);
		mousePos.z = 0;
		lineRender.SetPosition(0, transform.position);
		lineRender.SetPosition(1, mousePos);
		updatePentagon(mousePos);
	}
}