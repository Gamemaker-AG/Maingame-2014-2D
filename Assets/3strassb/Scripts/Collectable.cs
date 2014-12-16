using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Collider2D))]
public class Collectable : MonoBehaviour {
<<<<<<< HEAD
	public string collectMessage;
	public int collectAmmount;

	private bool collected = false;

=======
	private bool collected = false;


>>>>>>> b0662d63e0329ff06f148943764d794f22d31b0d
	void OnTriggerEnter2D(Collider2D collision) 
	{
		if(!collected && collision.CompareTag("Player"))
		{
			collected = true;
			//Destroy(gameObject);
<<<<<<< HEAD
			collision.SendMessage(collectMessage,collectAmmount,SendMessageOptions.DontRequireReceiver);
=======
			collision.SendMessage("AddPoints",1,SendMessageOptions.DontRequireReceiver);
>>>>>>> b0662d63e0329ff06f148943764d794f22d31b0d
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
