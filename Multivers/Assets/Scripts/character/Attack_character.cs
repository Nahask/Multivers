using UnityEngine;
using System.Collections;

public class Attack_character : MonoBehaviour {

	Animator anim;

	public float time_attack;

	public GameObject Sword;
	public GameObject Sword2;

	AnimatorStateInfo currentState;
	float timer;

	void Start () {
		timer = 0;
		anim = GetComponent<Animator> ();
	}

	void Update () {
		if (anim.GetBool("Spell") != true)
		{
			if (Input.GetButtonDown ("Attack1") && anim.GetBool ("IsAttacking") == false) {
				anim.SetBool ("IsAttacking", true);
				Sword.SetActive(true);
			}
			if (Input.GetButtonDown ("Attack2") && anim.GetBool ("IsAttacking2") == false) {
				anim.SetBool ("IsAttacking2", true);
				Sword2.SetActive(true);
			}
			check_att ();
		}
		}

	public void check_att()
	{
		if (anim.GetBool("IsAttacking") == true)
		    timer += Time.deltaTime;
		if (anim.GetBool("IsAttacking2") == true)
			timer += Time.deltaTime;
		if (timer >= time_attack) {
			anim.SetBool("IsAttacking", false);
			anim.SetBool("IsAttacking2", false);
			timer = 0;
			Sword.SetActive(false);
			Sword2.SetActive(false);
		}
	}
}
