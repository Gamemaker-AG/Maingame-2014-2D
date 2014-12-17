using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Scoreboard : MonoBehaviour {
	public GameObject pointDisplay;
	private Text myText;
	private int curPoints;

	public void Start () 
	{
		myText = pointDisplay.GetComponent<Text> ();
	}

	public void AddPoints(int points)
	{
		curPoints += points;
	}

	public void Update () 
	{
		myText.text = curPoints.ToString ();
	}
}
