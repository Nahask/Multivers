using UnityEngine;
using System.Collections;

public class enemy_manager : MonoBehaviour {

	public int type;
	public Sprite[] sprites;

	void Start () {
		GetComponent<SpriteRenderer> ().sprite = sprites [type];
	}
	
	void Update () {
	
	}
}
