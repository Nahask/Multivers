using UnityEngine;
using System.Collections;

public class EndOfLevelScript : MonoBehaviour {

	public PauseMenu pauseMenu;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player")
			pauseMenu.endLevel = true;
			Debug.Log ("cestlafinavecmichelcera");		
	}
}
