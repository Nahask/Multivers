using UnityEngine;
using System.Collections;

public class idiotEnnemyScript : MonoBehaviour {
	public float walkSpeed = 2.0f;
	public float engageSpeed = 2.0f;
	public float detectDistance = 3.5f;
	public float attackDistance = 1.5f;
	public float nbHP ;
	public float currentHP;


	public bool can_attack = true;
	private Transform player_trans;
	private Vector3 walkAmount;

	private Attack test = null;

	public float lookDirection = -1.0f;

	void Start() {
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

	/*
	void Attack() {
		Debug.Log ("Attack !");
	}*/

	void Die() {
		Destroy (gameObject);
		Debug.Log ("Dead !");
	}

	void Follow(float distance){
		float tmp_rotate = lookDirection;
		if (distance > attackDistance) {
			can_attack = true;
			walkAmount.x = lookDirection * engageSpeed * Time.deltaTime;
			lookDirection = (transform.position.x > player_trans.position.x) ? -1.0f : 1.0f;
			if (tmp_rotate != lookDirection)
				Flip ();
			transform.Translate (walkAmount);
			if(test != null)
				Destroy(test);
		}
		else
		{
			if (can_attack == true)
			{
			test = gameObject.AddComponent<Attack>();
				can_attack = false;
		
			}


//			Attack();
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
