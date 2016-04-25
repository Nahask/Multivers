using UnityEngine;
using System.Collections;

public class takeDamageDragon : MonoBehaviour {

	private GameObject player_obj;
	private Player player;
	private Score score;

	public int x;
	public int y;

	float [,] damage_elem = new float[,]{
		{1f, 2f, 1f, 0.5f},
		{0.5f, 1f, 2f, 1f},
		{1f, 0.5f, 1f, 2f},
		{2f, 1f, 0.5f, 1f}};
	private DragonEnemyScript enemy;
	private enemy_manager enemy_type;


	void Start () {
		player_obj = GameObject.FindGameObjectsWithTag ("Player")[0];
		player = player_obj.GetComponent<Player> ();
		score = player_obj.GetComponent<Score> ();
		enemy = this.GetComponent<DragonEnemyScript> ();
		enemy_type = this.GetComponent<enemy_manager>();
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Sword") {
			score.timerScore = 0;
			score.tmpScore = score.tmpScore + 3;
			rigidbody2D.AddForce(new Vector2(0, y));
			rigidbody2D.AddForce(new Vector2(-enemy.lookDirection*x, 0));
			add_mult();
			DamageSword();
			}
		if (other.tag == "Sword2") {
			score.timerScore = 0;
			score.tmpScore = score.tmpScore + 3;
			rigidbody2D.AddForce(new Vector2(0, y));
			rigidbody2D.AddForce(new Vector2(-enemy.lookDirection*x, 0));
			add_mult();
			DamageSword2();
		}
		if (other.tag == "Spell") {
			score.timerScore = 0;
			add_mult();
			score.tmpScore = score.tmpScore + 5;
			rigidbody2D.AddForce(new Vector2(0, y));
			rigidbody2D.AddForce(new Vector2(-enemy.lookDirection*x, 0));
			DamageSpell();
		}
		if (other.tag == "SuperSpell") {
			score.timerScore = 0;
			add_mult();
			score.tmpScore = score.tmpScore + 4;
			Destroy(gameObject);
		}
		
	}

	public void add_mult()
	{
		if (damage_elem [player.World, enemy_type.type] == 0.5f)
			score.mult = score.mult + 1;
		else if (damage_elem[player.World, enemy_type.type] == 1.0f)
			score.mult = score.mult + 2;
		else 
			score.mult = score.mult + 3;
	}

	void Update () {
	
	}

	public void DamageSword()
	{
		enemy.currentHP = enemy.currentHP - 20*damage_elem[player.World, enemy_type.type];
	}

	public void DamageSword2()
	{
		enemy.currentHP = enemy.currentHP - 25*damage_elem[player.World, enemy_type.type];
	}

	public void DamageSpell()
	{
		enemy.currentHP = enemy.currentHP - 10 * damage_elem [player.World, enemy_type.type];
	}
}
