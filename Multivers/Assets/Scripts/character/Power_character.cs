using UnityEngine;
using System.Collections;

public class Power_character : MonoBehaviour {
	
	private GameObject player_obj;
	private Player player;

	private Animator anim;
	private float timer;

	public GameObject[] spells;
	public Transform start_fire;
	public Transform start_foudre;
	public Transform start_vague;
	public Transform start_superFire;
	public Transform start_greenPower;
	public Transform start_grosseFoudre;

	private fire_power fire;

	void Start () {
		player_obj = GameObject.FindGameObjectsWithTag ("Player")[0];
		player = player_obj.GetComponent<Player> ();
		anim = GetComponent<Animator>();
		timer = 0;
	}
	
	void Update () {
		if (anim.GetBool ("IsAttacking") != true) {
			castSpell();
			castSuperSpell();
		}
		check_spell ();
	}

	void castSuperSpell()
	{
		if (Input.GetButtonDown("SuperSpell") == true)
			{
				if (player.World == 0)
					{
						if (player.currentMana - 99 >= 0)
						{
							Instantiate(spells[2], start_vague.position, start_vague.rotation);
							anim.SetBool("Spell", true);
							player.currentMana = player .currentMana - 99;
						}
					}
				else if (player.World == 1)
					{
						if (player.currentMana - 99 >= 0)
						{
							Instantiate(spells[3], start_superFire.position, start_superFire.rotation);
							anim.SetBool("Spell", true);
							player.currentMana = player .currentMana - 99;
						}
					}
				else if (player.World == 2)
					{
						if (player.currentMana - 99 >= 0)
						{
						Instantiate(spells[4], start_greenPower.position, start_greenPower.rotation);
						anim.SetBool("Spell", true);
						player.currentMana = player .currentMana - 99;
						}
					}
				else if (player.World == 3)
					{
						if (player.currentMana - 99 >= 0)
						{
						Instantiate(spells[5], start_grosseFoudre.position, start_grosseFoudre.rotation);
						anim.SetBool("Spell", true);
						player.currentMana = player .currentMana - 99;
						}
					}
		}			
	}

	void castSpell()
	{
		if (Input.GetButtonDown("Power") == true)
		{
			if (player.World == 0)
			{
				if (player.currentMana - 40 >= 0)
				{
					if (player.currentHealth + 20 >= 100)
						player.currentHealth = 100;
					else
						player.currentHealth = player.currentHealth + 20;
					anim.SetBool("Spell", true);
					player.currentMana = player.currentMana - 40;
				}
			}
			else if (player.World == 1)
			{
				if (player.currentMana - 10 >= 0)
				{
					Instantiate(spells[0], start_fire.position, start_fire.rotation);
					anim.SetBool("Spell", true);
					player.currentMana = player .currentMana - 15;
				}
			}
			else if (player.World == 2)
			{
				if (player.currentMana - 20 >= 0)
				{
					anim.SetBool("Spell", true);
					player.isDamagable = false;
					player.currentMana = player.currentMana - 20;
				}
			}
			else if (player.World == 3)
			{
				if (player.currentMana - 30 >= 0)
				{
					Instantiate(spells[1], start_foudre.position, start_foudre.rotation);
					anim.SetBool("Spell", true);
					player.currentMana = player.currentMana - 30;
				}
			}
		}
	}

	void check_spell()
	{
		if (anim.GetBool ("Spell") == true)
			timer += Time.deltaTime;
		if (timer >= 0.30) {
			timer = 0;
			anim.SetBool("Spell", false);
			player.isDamagable = true;
		}
	}
}
