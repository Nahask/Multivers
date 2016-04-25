using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public float maxHealth = 100;
	public int maxMana = 100;
	public float minHealth = 0;
	public int minMana = 0;
	public int World;
	public float currentHealth;
	public int currentMana;

	public bool isDamagable;
	public int x;
	public int y;


	private mouvement_character  player_mouv;
	private float tmpHealth;
	private Animator anim;

	void Start () {
		player_mouv = this.GetComponent<mouvement_character>();
		isDamagable = true;
		anim = GetComponent<Animator> ();
		currentHealth = maxHealth;
		tmpHealth = maxHealth;
		currentMana = maxMana;
		InvokeRepeating ("Regen", 1.00f, 1.00f);
	}
	
	void Update () {
		if (anim.GetBool ("IsAttacking") == false && anim.GetBool ("Spell") == false) {
			if (Input.GetButtonDown ("WorldP")) {
				World++;
				anim.SetInteger ("World", World);
				if (World > 3) {
					World = 0;
					anim.SetInteger ("World", World);
				}
			}
			if (Input.GetButtonDown ("WorldM")) {
				World--;
				anim.SetInteger ("World", World);
				{
					if (World < 0) {
						World = 3;
						anim.SetInteger ("World", World);
					}
				}
			}
		}
		takeDamage ();
	}

	void takeDamage()
	{	
		if (tmpHealth > currentHealth) {
			if (player_mouv.facingRight == false)
			rigidbody2D.AddForce(new Vector2(x, y));
			else
				rigidbody2D.AddForce(new Vector2(-x, y));
			tmpHealth = currentHealth;
		}
	}

	void Regen()
	{
		if (currentMana < maxMana)
			currentMana = currentMana + 2;
	}
}
