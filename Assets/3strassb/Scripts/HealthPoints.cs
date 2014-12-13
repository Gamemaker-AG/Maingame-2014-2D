using UnityEngine;
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
	}
}
