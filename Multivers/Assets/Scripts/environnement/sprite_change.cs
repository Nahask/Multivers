using UnityEngine;
using System.Collections;

public class sprite_change : MonoBehaviour {
	public Player player;
	public Sprite[] sprites;
	private int i;
	private int currentWorld;


	void Start () {
		currentWorld = 0;
		GetComponent<SpriteRenderer> ().sprite = sprites [player.World];
	}

	void Update () {
		if (currentWorld != player.World) {
			Debug.Log("ça rentre");
			GetComponent<SpriteRenderer> ().sprite = sprites [player.World];
			currentWorld = player.World;
			//	player.world_change = false;
		}
		}
}

// FAUT CHANGER DES TRUCS ICI et FAUT QUE LE CHANGEMEMENT DE SPRITE SE FASSE DANS L'UPDATE
//ET PAS DANS L'UPDATE -----> voir dans Player pour l'appel (je crois ....)