using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour {
	public float delayAttack = 1;
	public idiotEnnemyScript IaEnemy;

	private GameObject player;
	private Player playerHealth;

	float [,] damage_elem = new float[,]{
		{1f, 2f, 1f, 0.5f},
		{0.5f, 1f, 2f, 1f},
		{1f, 0.5f, 1f, 2f},
		{2f, 1f, 0.5f, 1f}};
	
	private enemy_manager enemy_type;


	void Start () {
		player = GameObject.FindGameObjectsWithTag ("Player")[0];
		playerHealth = player.GetComponent<Player> ();
		enemy_type = this.GetComponent<enemy_manager>();
		InvokeRepeating ("attack", delayAttack, delayAttack);
	}

	public void attack()
	{
		if (playerHealth.isDamagable == true)
			playerHealth.currentHealth = playerHealth.currentHealth - 5*damage_elem[enemy_type.type, playerHealth.World];
	}


	void Update()
	{

	}
}
