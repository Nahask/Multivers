using UnityEngine;
using System.Collections;

public class MenuManagerScript : MonoBehaviour {

	public GameObject menuMain;
	public GameObject jouer;
	public GameObject score;
	public GameObject settings;

	void Start () {
		jouer.SetActive (false);
		settings.SetActive (false);
		score.SetActive (false);
		settings.SetActive (false);
	}
	
	void Update () {
	
	}

	public void Jouer()
	{
		menuMain.SetActive (false);
		jouer.SetActive (true);
	}

	public void Score()
	{
		menuMain.SetActive (false);
		score.SetActive (true);
	}

	public void Options()
	{
		menuMain.SetActive (false);
		settings.SetActive (true);
	}

	public void Retour()
	{
		jouer.SetActive (false);
		settings.SetActive (false);
		score.SetActive (false);
		settings.SetActive (false);
		menuMain.SetActive (true);
	}

	public void Quitter()
	{
		Application.Quit ();	
	}



}
