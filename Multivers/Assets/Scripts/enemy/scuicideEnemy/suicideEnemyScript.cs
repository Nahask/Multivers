using UnityEngine;
using System.Collections;

public class suicideEnemyScript : MonoBehaviour {
	public float walkSpeed = 2.0f;
	public float engageSpeed = 3.0f;
	public float detectDistance = 8.0f;
	public float attackDistance;
	public float nbHP = 10;
	public float currentHP;


	private Transform player_trans;
	private Vector3 walkAmount;

	private GameObject player;
	private Player playerHealth;
	float [,] damage_elem = new float[,]{
		{1f, 2f, 1f, 0.5f},
		{0.5f, 1f, 2f, 1f},
		{1f, 0.5f, 1f, 2f},
		{2f, 1f, 0.5f, 1f}};
	
	private idiotEnnemyScript enemy;
	private enemy_manager enemy_type;

	
	public float lookDirection = -1.0f;
	
	void Start() {
		player = GameObject.FindGameObjectsWithTag ("Player")[0];
		playerHealth = player.GetComponent<Player> ();
	//	enemy = this.GetComponent<suicideEnemyScript> ();
		enemy_type = this.GetComponent<enemy_manager>();
		currentHP = nbHP;
		player_trans = GameObject.FindWithTag("Player").transform;
	}
	
	void Flip(){
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
	
	void Wait(){
		;
	}
	
	void Attack() {
		Debug.Log ("Attack !");
		Die ();
	}
	
	void Die() {
		var distance = Vector3.Distance(transform.position, player_trans.position);
		if (distance <= attackDistance) {
			Debug.Log ("Distance boom = " + distance);
			Debug.Log ("DEGATS !!");
			if (playerHealth.isDamagable == true)
				playerHealth.currentHealth = playerHealth.currentHealth - 40*damage_elem[enemy_type.type, playerHealth.World];
		}

		Debug.Log ("Dead !");
		nbHP = 0;
		Destroy (gameObject);
	}
	
	void Follow(float distance){
		float tmp_rotate = lookDirection;
		if (distance > attackDistance) {
			walkAmount.x = lookDirection * engageSpeed * Time.deltaTime;
			lookDirection = (transform.position.x > player_trans.position.x) ? -1.0f : 1.0f;
			if (tmp_rotate != lookDirection)
				Flip ();
			transform.Translate (walkAmount);
			Debug.Log ("TEST FOLLOW");
		}
		else {
			Attack();
		}
	}


	void Update () {
		var distance = Vector3.Distance(transform.position, player_trans.position);
		if (currentHP <= 0)
			Die ();
		if (distance > detectDistance)
			Wait ();
		else
			Follow (distance);
	}

}
