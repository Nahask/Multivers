using UnityEngine;
using System.Collections;

public class DeathTriggerManager : MonoBehaviour {
	public Player player;

	void Start () {
	
	}
	
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player")
			player.currentHealth = 0;
	}

}
