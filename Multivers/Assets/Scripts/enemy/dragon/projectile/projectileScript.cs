using UnityEngine;
using System.Collections;

public class projectileScript : MonoBehaviour {


	public Vector2 speed = new Vector2(10, 10);
	public float lookDirection = -1.0f;
	private Vector2 direction ;
	private Vector2 movement;
	public int type;


	private GameObject player;
	private Player playerHealth;
	float [,] damage_elem = new float[,]{
		{1f, 2f, 1f, 0.5f},
		{0.5f, 1f, 2f, 1f},
		{1f, 0.5f, 1f, 2f},
		{2f, 1f, 0.5f, 1f}};
	
	private DragonEnemyScript enemy;
	private enemy_manager enemy_type;
		

	void Start(){
		player = GameObject.FindGameObjectsWithTag ("Player")[0];
		playerHealth = player.GetComponent<Player> ();
		Destroy (gameObject, 5);
	}

	void Update(){
		direction = new Vector2 (lookDirection, 0);
		movement = new Vector2(
		speed.x * direction.x,
		speed.y * direction.y);
	}
		
	void FixedUpdate(){
		rigidbody2D.velocity = movement;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") 
			if (playerHealth.isDamagable == true)
		{
			playerHealth.currentHealth = playerHealth.currentHealth - 5*damage_elem[type, playerHealth.World];
			Destroy (gameObject);
		}
		}

	public void Flip(){
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
