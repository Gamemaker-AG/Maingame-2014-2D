using UnityEngine;
using System.Collections;

public class PlayerGUI : MonoBehaviour 
{
	private int points = 0;

	void OnGUI()
	{
		GUI.Box(new Rect(10, 10, 160, 60), "Points");
		GUI.Label(new Rect(15, 30, 140, 30), points.ToString());
	}

	void AddPoints(int p)
	{
		points += p;
	}
}
