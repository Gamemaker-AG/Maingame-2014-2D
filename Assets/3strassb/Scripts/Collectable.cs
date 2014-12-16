using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Collider2D))]
public class Collectable : MonoBehaviour {
	public string collectMessage;
	public int collectAmmount;

	private bool collected = false;

	void OnTriggerEnter2D(Collider2D collision) 
	{
		if(!collected && collision.CompareTag("Player"))
		{
			collected = true;
			//Destroy(gameObject);
			collision.SendMessage(collectMessage,collectAmmount,SendMessageOptions.DontRequireReceiver);
			GetComponent<Animator>().Play("CoinDeath");
			GetComponent<AudioSource>().Play();
			GetComponent<ParticleSystem>().Play();
		}
    }

    void AnimationDone()
    {
    	Destroy(gameObject);
    }
}
