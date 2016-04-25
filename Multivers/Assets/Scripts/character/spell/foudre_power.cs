using UnityEngine;
using System.Collections;

public class foudre_power: MonoBehaviour {

	public float lookDirection = -1.0f;

	private GameObject player_mouv_obj;
	private mouvement_character player_move;

	public void Flip(){
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
	void Start(){
		player_mouv_obj = GameObject.FindGameObjectsWithTag ("Player")[0];
		player_move = player_mouv_obj.GetComponent<mouvement_character> ();
		if (player_move.facingRight == true) {
		} else {
			Flip();
		}
		Destroy (gameObject, 1);
	}
	
	void Update(){

	}
	
	void FixedUpdate(){
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{

	}
}
