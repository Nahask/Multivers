using UnityEngine;
using System.Collections;

public class rusherEnemyScript : MonoBehaviour {
	public float walkSpeed = 2.0f;
	public float engageSpeed = 7.0f;
	public float detectDistance = 7.0f;
	public float attackDistance = 2.3f;
	public float nbHP;
	public float currentHP;

	private bool running = false;	
	private Transform player_trans;
	private Vector3 walkAmount;
	private float x_player = 0.000000f;
	
	public float lookDirection = -1.0f;

	private GameObject player;
	private Player playerHealth;
	private enemy_manager enemy_type;
	float [,] damage_elem = new float[,]{
		{1f, 2f, 1f, 0.5f},
		{0.5f, 1f, 2f, 1f},
		{1f, 0.5f, 1f, 2f},
		{2f, 1f, 0.5f, 1f}};
	
	void Start() {
		player = GameObject.FindGameObjectsWithTag ("Player")[0];
		playerHealth = player.GetComponent<Player> ();
		enemy_type = this.GetComponent<enemy_manager>();
		currentHP = nbHP;
		player_trans = GameObject.FindWithTag("Player").transform;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") 
			if (playerHealth.isDamagable == true)
		{
			playerHealth.currentHealth = playerHealth.currentHealth - 10*damage_elem[enemy_type.type, playerHealth.World];
		}
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
	}
	
	void Die() {
		Debug.Log ("Dead !");
		nbHP = 0;
		Destroy (gameObject);
	}

	bool stopEngage (float x_player){
		if (lookDirection > 0 && transform.position.x >= detectDistance + x_player) {
			x_player = 0.000000f;
			return (false);
		} else if (lookDirection < 0 && transform.position.x <= x_player - detectDistance) {
			x_player = 0.000000f;
			return (false);
		} else
			return (true);
	}

	void Engage(float distance){
		if (x_player == 0.000000f)
			x_player = player_trans.position.x;
		if (running == false) {
			var tmp_rotate = lookDirection;
			lookDirection = (transform.position.x > x_player) ? -1.0f : 1.0f;
			if (tmp_rotate != lookDirection)
				Flip ();		}
		running = true;
		running = stopEngage(x_player);
		walkAmount.x = lookDirection * engageSpeed * Time.deltaTime;
		transform.Translate (walkAmount);
	}
	
	void Update () {
		var distance = Vector3.Distance(transform.position, player_trans.position);

		if (distance > detectDistance && running == false)
			Wait ();
		else
			Engage (distance);
	}
}