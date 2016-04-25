using UnityEngine;
using System.Collections;

public class TrigerZone : MonoBehaviour {
	public float spawnTime = 3f;   
	public GameObject enemy; 
	public Transform[] spawnPoints;   
	public int nb_enemy = 3;
	private int i = 0;

	public void Start()
	{
		Debug.Log("Trigger: " + collider2D.isTrigger);
	}


	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player")
			InvokeRepeating("spawn", spawnTime, spawnTime);

	}
	void OnTriggerStay2D(Collider2D other)
	{
		Debug.Log ("ça reste lol");
	}
	void OnTriggerExit2D(Collider2D other)
	{
		Debug.Log ("ça sort lol");
	}

	void spawn ()
	{
		/*if(playerHealth.currentHealth <= 0f)
			{
				return;
			}*/
		
		
		if (i < nb_enemy) {
			
			// a  modifier
			int spawnPointIndex = Random.Range (0, spawnPoints.Length);
			
			// Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
			Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
			//Instantiate (enemy, spawnPoints [spawnPointIndex].position, spawnPoints [spawnPointIndex].rotation);
			i++;
		} else
			return;
	}
}
