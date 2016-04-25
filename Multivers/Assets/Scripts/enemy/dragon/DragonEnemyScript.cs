using UnityEngine;
using System.Collections;

public class DragonEnemyScript : MonoBehaviour {
	public float walkSpeed = 2.0f;
	public float engageSpeed = 2.0f;
	public float detectDistance = 7f;
	public float attackDistance = 5f;
	public float shotRate = 0.5f;
	public float nbHP;
	public float currentHP;	
	public GameObject[] bullet;


	private projectileScript projectile;
	private Transform player_trans;
	private Vector3 walkAmount;
	private float shotTime;
	private enemy_manager enemy_type;

	
	public float lookDirection = -1.0f;
	
	void Start() {
		enemy_type = this.GetComponent<enemy_manager>();
		currentHP = nbHP;
		shotTime = 0f;
		player_trans = GameObject.FindWithTag("Player").transform;
	}
	
	void Update () {
		var distance = Vector3.Distance(transform.position, player_trans.position);
		if (currentHP <= 0)
			Die ();
		if (shotTime > 0f)
			shotTime -= Time.deltaTime;
		
		if (distance > detectDistance)
			Wait ();
		else
			Attack (distance);
	}
	
	void Flip(){
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
	
	void Wait(){
		;
	}
	
	void Shot() {
		Debug.Log ("Attack !");
		if (shotTime <= 0f) {
			shotTime = shotRate;
			Instantiate (bullet[enemy_type.type], transform.position, Quaternion.identity);
			projectile = bullet[enemy_type.type].gameObject.GetComponent<projectileScript> ();
			if (projectile != null) {
				if (lookDirection != projectile.lookDirection)
					projectile.Flip ();
				projectile.lookDirection = lookDirection;
			}
		}
	}
	
	void Die() {
		Destroy (gameObject);
	}
	
	void Look(){
		float tmp_rotate = lookDirection;
		lookDirection = (transform.position.x > player_trans.position.x) ? -1.0f : 1.0f;
		if (tmp_rotate != lookDirection)
			Flip ();
	}
	
	void Attack(float distance){
		
		Look ();
		if (distance > attackDistance) {
			walkAmount.x = lookDirection * engageSpeed * Time.deltaTime;
			transform.Translate (walkAmount);
		}
		else {
			Shot();
		}
	}
}
