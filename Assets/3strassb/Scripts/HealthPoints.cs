using UnityEngine;
<<<<<<< HEAD
using UnityEngine.UI;
using System.Collections;

public class HealthPoints : MonoBehaviour {
	public float maxHealthpoints = 100;
	public GameObject healthBar;
	private Slider healthBarSlider = null;
	private float curHealthpoints;

	void Start()
	{
		if(healthBar != null)
			healthBarSlider = healthBar.GetComponent<Slider>();
		curHealthpoints = maxHealthpoints;
		UpdateHealthBar ();
	}

	private void UpdateHealthBar()
	{
		if (healthBarSlider != null) 
		{
			healthBarSlider.maxValue = maxHealthpoints;
			healthBarSlider.value = curHealthpoints;
		}
	}
	
	public void TakeDamage(int dmg)
	{
		curHealthpoints-= dmg;
		UpdateHealthBar ();
		for(int i =0; i < transform.childCount; i++)
		{
			SpriteRenderer render = transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>();
			if(render)
			{
				render.color = Color.red;
			}
		}

		BroadcastMessage ("ShakeCamera", SendMessageOptions.DontRequireReceiver);

		//Debug.Log (gameObject.name + " took " + dmg + " damage and now has " + curHealthpoints + " HP Left");

		if(curHealthpoints <= 0)
		{
			if(gameObject.tag == "Player")
			{
				curHealthpoints = maxHealthpoints;
				UpdateHealthBar();
				Transform respawnArea = GameObject.FindGameObjectWithTag("Respawn").transform;
				gameObject.transform.position = new Vector3(respawnArea.position.x,respawnArea.position.y,0);
				gameObject.rigidbody2D.velocity = Vector2.zero;
			}
			else
				Destroy(gameObject);
		}
	}

	void Update()
	{
		for(int i =0; i < transform.childCount; i++)
		{
			SpriteRenderer render = transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>();
			if(render)
			{
				render.color += (Color.white - render.color) * 0.05f;
			}
		}
	}

	void Heal(float points)
	{
		curHealthpoints += points;
		if (curHealthpoints > maxHealthpoints)
			curHealthpoints = maxHealthpoints;
=======
using System.Collections;

public class HealthPoints : MonoBehaviour {
	public double Healthpoints = 100;
	
	void TakeDamage(double dmg)
	{
		Healthpoints-= dmg;
	}

	void Heal(double points)
	{
		Healthpoints-= points;
	}

	void OnGUI()
	{
		GUI.Box(new Rect(170, 10, 160, 60), "Points");
>>>>>>> b0662d63e0329ff06f148943764d794f22d31b0d
	}
}
