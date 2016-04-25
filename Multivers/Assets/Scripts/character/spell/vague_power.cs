using UnityEngine;
using System.Collections;

public class vague_power : MonoBehaviour {

	public Vector2 speed = new Vector2(10, 10);
	public float lookDirection = 1.0f;
	private Vector2 direction ;
	private Vector2 movement;
	
	
	/*private GameObject player;
	private Player playerHealth;*/
	
	private GameObject player_mouv_obj;
	private mouvement_character player_move;
	
	public void Flip(){
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
	void Start(){
		
		/*		player = GameObject.FindGameObjectsWithTag ("Player")[0];
		playerHealth = player.GetComponent<Player> ();
*/
		
		player_mouv_obj = GameObject.FindGameObjectsWithTag ("Player")[0];
		player_move = player_mouv_obj.GetComponent<mouvement_character> ();
		if (player_move.facingRight == true) {
			Flip();
			direction = new Vector2 (lookDirection, 0);
			movement = new Vector2 (speed.x * direction.x, speed.y * direction.y);
		} else {
			direction = new Vector2 (-lookDirection, 0);
			movement = new Vector2 (speed.x * direction.x, speed.y * direction.y);
		}
		Destroy (gameObject, 5);
	}
	
	void Update(){
		
	}
	
	void FixedUpdate(){
		rigidbody2D.velocity = movement;
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{

	}
}
