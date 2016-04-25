using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {

	private GameObject score_obj;
	private SaveScore saveScore;

	public int level;

	public GameObject pauseMenu;
	public GameObject gameOverMenu;
	public GameObject finNiveauMenu;
	public GameObject optionMenu;
	public int scene;

	public Text scoreDisplay;
	public Text timerDisplay;
	public Text scoreEnd;

	public bool endLevel;

	private Player player;
	private Score score;
	
	void Start () {
		score_obj = GameObject.FindGameObjectsWithTag ("Score")[0];
		saveScore = score_obj.GetComponent<SaveScore> ();
		endLevel = false;
		player = this.GetComponent<Player> ();
		score = this.GetComponent<Score> ();
		Time.timeScale = 1;
		gameOverMenu.SetActive (false);
		finNiveauMenu.SetActive (false);
		optionMenu.SetActive (false);
		Screen.lockCursor = false;
		Screen.showCursor = false;
		pauseMenu.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	if (Input.GetButtonDown ("PauseMenu") == true && Time.timeScale != 0 && player.currentHealth > 0 && endLevel != true) {
			menuPause();
		} else if (Input.GetButtonDown ("PauseMenu") == true && Time.timeScale != 1 && player.currentHealth > 0 && endLevel != true)
			resumeGame ();
		else if (player.currentHealth <= 0) {
			gameOver ();
		} else if (endLevel == true) {
			endMenu();
		}
	}

	public void optionMenuDisplay()
	{
		Debug.Log ("coucou c'est les options");
		pauseMenu.SetActive (false);
		optionMenu.SetActive (true);
	}

	public void menuPause()
	{
		optionMenu.SetActive (false);
		pauseMenu.SetActive (true);
		Time.timeScale = 0; 
		Screen.lockCursor = false;
		Screen.showCursor = true;
	}

	public void endMenu()
	{
		Time.timeScale = 0;
		finNiveauMenu.SetActive (true);
		scoreEnd.text = "Score : " + score.score.ToString ();
		timerDisplay.text = "Temps : " + score.time.ToString ("0");
		Screen.lockCursor = false;
		Screen.showCursor = true;
		setSaveScore ();
	}

	public void setSaveScore()
	{	
		if (level == 0) {
			if (score.score > saveScore.lvl1_1) {
				saveScore.lvl1_5 = saveScore.lvl1_4;
				saveScore.lvl1_4 = saveScore.lvl1_3;
				saveScore.lvl1_3 = saveScore.lvl1_2;
				saveScore.lvl1_2 = saveScore.lvl1_1;
				saveScore.lvl1_1 = score.score;
				saveScore.changeData ("lvl1_1", score.score);
				saveScore.changeData ("lvl1_2", saveScore.lvl1_2);
				saveScore.changeData ("lvl1_3", saveScore.lvl1_3);
				saveScore.changeData ("lvl1_4", saveScore.lvl1_4);
				saveScore.changeData ("lvl1_5", saveScore.lvl1_5);
			} else if (score.score > saveScore.lvl1_2 && score.score < saveScore.lvl1_1) {
				saveScore.lvl1_5 = saveScore.lvl1_4;
				saveScore.lvl1_4 = saveScore.lvl1_3;
				saveScore.lvl1_3 = saveScore.lvl1_2;
				saveScore.lvl1_2 = score.score;
				saveScore.changeData ("lvl1_2", score.score);
				saveScore.changeData ("lvl1_3", saveScore.lvl1_3);
				saveScore.changeData ("lvl1_4", saveScore.lvl1_4);
				saveScore.changeData ("lvl1_5", saveScore.lvl1_5);
			} else if (score.score > saveScore.lvl1_3 && score.score < saveScore.lvl1_2) {
				saveScore.lvl1_5 = saveScore.lvl1_4;
				saveScore.lvl1_4 = saveScore.lvl1_3;
				saveScore.lvl1_3 = score.score;
				saveScore.changeData ("lvl1_3", score.score);
				saveScore.changeData ("lvl1_4", saveScore.lvl1_4);
				saveScore.changeData ("lvl1_5", saveScore.lvl1_5);
			} else if (score.score > saveScore.lvl1_4 && score.score < saveScore.lvl1_3) {
				saveScore.lvl1_5 = saveScore.lvl1_4;
				saveScore.lvl1_4 = score.score;
				saveScore.changeData ("lvl1_4", score.score);
				saveScore.changeData ("lvl1_5", saveScore.lvl1_5);
			} else if (score.score > saveScore.lvl1_5 && score.score < saveScore.lvl1_4) {
				saveScore.lvl1_5 = score.score;
				saveScore.changeData ("lvl1_5", score.score);
			}
		}else if (level == 1){
		if (score.score > saveScore.lvl2_1) {
			saveScore.lvl2_5 = saveScore.lvl2_4;
			saveScore.lvl2_4 = saveScore.lvl2_3;
			saveScore.lvl2_3 = saveScore.lvl2_2;
			saveScore.lvl2_2 = saveScore.lvl2_1;
			saveScore.lvl2_1 = score.score;
			saveScore.changeData ("lvl2_1", score.score);
			saveScore.changeData ("lvl2_2", saveScore.lvl2_2);
			saveScore.changeData ("lvl2_3", saveScore.lvl2_3);
			saveScore.changeData ("lvl2_4", saveScore.lvl2_4);
			saveScore.changeData ("lvl2_5", saveScore.lvl2_5);
		} else if (score.score > saveScore.lvl2_2 && score.score < saveScore.lvl2_1) {
			saveScore.lvl2_5 = saveScore.lvl2_4;
			saveScore.lvl2_4 = saveScore.lvl2_3;
			saveScore.lvl2_3 = saveScore.lvl2_2;
			saveScore.lvl2_2 = score.score;
			saveScore.changeData ("lvl2_2", score.score);
			saveScore.changeData ("lvl2_3", saveScore.lvl2_3);
			saveScore.changeData ("lvl2_4", saveScore.lvl2_4);
			saveScore.changeData ("lvl2_5", saveScore.lvl2_5);
		} else if (score.score > saveScore.lvl2_3 && score.score < saveScore.lvl2_2) {
			saveScore.lvl2_5 = saveScore.lvl2_4;
			saveScore.lvl2_4 = saveScore.lvl2_3;
			saveScore.lvl2_3 = score.score;
			saveScore.changeData ("lvl2_3", score.score);
			saveScore.changeData ("lvl2_4", saveScore.lvl2_4);
			saveScore.changeData ("lvl2_5", saveScore.lvl2_5);
		} else if (score.score > saveScore.lvl2_4 && score.score < saveScore.lvl2_3) {
			saveScore.lvl2_5 = saveScore.lvl2_4;
			saveScore.lvl2_4 = score.score;
			saveScore.changeData ("lvl2_4", score.score);
			saveScore.changeData ("lvl2_5", saveScore.lvl2_5);
		} else if (score.score > saveScore.lvl2_5 && score.score < saveScore.lvl2_4) {
			saveScore.lvl2_5 = score.score;
			saveScore.changeData ("lvl2_5", score.score);
		}
	}else if (level == 2)
		{
			if (score.score > saveScore.lvl3_1) {
			saveScore.lvl3_5 = saveScore.lvl3_4;
			saveScore.lvl3_4 = saveScore.lvl3_3;
			saveScore.lvl3_3 = saveScore.lvl3_2;
			saveScore.lvl3_2 = saveScore.lvl3_1;
			saveScore.lvl3_1 = score.score;
			saveScore.changeData ("lvl3_1", score.score);
			saveScore.changeData ("lvl3_2", saveScore.lvl3_2);
			saveScore.changeData ("lvl3_3", saveScore.lvl3_3);
			saveScore.changeData ("lvl3_4", saveScore.lvl3_4);
			saveScore.changeData ("lvl3_5", saveScore.lvl3_5);
		} else if (score.score > saveScore.lvl3_2 && score.score < saveScore.lvl3_1) {
			saveScore.lvl3_5 = saveScore.lvl3_4;
			saveScore.lvl3_4 = saveScore.lvl3_3;
			saveScore.lvl3_3 = saveScore.lvl3_2;
			saveScore.lvl3_2 = score.score;
			saveScore.changeData ("lvl3_2", score.score);
			saveScore.changeData ("lvl3_3", saveScore.lvl3_3);
			saveScore.changeData ("lvl3_4", saveScore.lvl3_4);
			saveScore.changeData ("lvl3_5", saveScore.lvl3_5);
		} else if (score.score > saveScore.lvl3_3 && score.score < saveScore.lvl3_2) {
			saveScore.lvl3_5 = saveScore.lvl3_4;
			saveScore.lvl3_4 = saveScore.lvl3_3;
			saveScore.lvl3_3 = score.score;
			saveScore.changeData ("lvl3_3", score.score);
			saveScore.changeData ("lvl3_4", saveScore.lvl3_4);
			saveScore.changeData ("lvl3_5", saveScore.lvl3_5);
		} else if (score.score > saveScore.lvl3_4 && score.score < saveScore.lvl3_3) {
			saveScore.lvl3_5 = saveScore.lvl3_4;
			saveScore.lvl3_4 = score.score;
			saveScore.changeData ("lvl3_4", score.score);
			saveScore.changeData ("lvl3_5", saveScore.lvl3_5);
		} else if (score.score > saveScore.lvl3_5 && score.score < saveScore.lvl3_4) {
			saveScore.lvl3_5 = score.score;
			saveScore.changeData ("lvl1_3", score.score);
		}
	}else if (level == 3)
		{if (score.score > saveScore.lvl4_1) {
				saveScore.lvl4_5 = saveScore.lvl4_4;
				saveScore.lvl4_4 = saveScore.lvl4_3;
				saveScore.lvl4_3 = saveScore.lvl4_2;
				saveScore.lvl4_2 = saveScore.lvl4_1;
				saveScore.lvl4_1 = score.score;
				saveScore.changeData ("lvl4_1", score.score);
				saveScore.changeData ("lvl4_2", saveScore.lvl4_2);
				saveScore.changeData ("lvl4_3", saveScore.lvl4_3);
				saveScore.changeData ("lvl4_4", saveScore.lvl4_4);
				saveScore.changeData ("lvl4_5", saveScore.lvl4_5);
			} else if (score.score > saveScore.lvl4_2 && score.score < saveScore.lvl4_1) {
				saveScore.lvl4_5 = saveScore.lvl4_4;
				saveScore.lvl4_4 = saveScore.lvl4_3;
				saveScore.lvl4_3 = saveScore.lvl4_2;
				saveScore.lvl4_2 = score.score;
				saveScore.changeData ("lvl4_2", score.score);
				saveScore.changeData ("lvl4_3", saveScore.lvl4_3);
				saveScore.changeData ("lvl4_4", saveScore.lvl4_4);
				saveScore.changeData ("lvl4_5", saveScore.lvl4_5);
			} else if (score.score > saveScore.lvl4_3 && score.score < saveScore.lvl4_2) {
				saveScore.lvl4_5 = saveScore.lvl4_4;
				saveScore.lvl4_4 = saveScore.lvl4_3;
				saveScore.lvl4_3 = score.score;
				saveScore.changeData ("lvl4_3", score.score);
				saveScore.changeData ("lvl4_4", saveScore.lvl4_4);
				saveScore.changeData ("lvl4_5", saveScore.lvl4_5);
			} else if (score.score > saveScore.lvl4_4 && score.score < saveScore.lvl4_3) {
				saveScore.lvl4_5 = saveScore.lvl4_4;
				saveScore.lvl4_4 = score.score;
				saveScore.changeData ("lvl4_4", score.score);
				saveScore.changeData ("lvl4_5", saveScore.lvl4_5);
			} else if (score.score > saveScore.lvl4_5 && score.score < saveScore.lvl4_4) {
				saveScore.lvl4_5 = score.score;
				saveScore.changeData ("lvl4_5", score.score);
			}
		}else if (level == 4){	
			if (score.score > saveScore.lvl5_1) {
				saveScore.lvl5_5 = saveScore.lvl5_4;
				saveScore.lvl5_4 = saveScore.lvl5_3;
				saveScore.lvl5_3 = saveScore.lvl5_2;
				saveScore.lvl5_2 = saveScore.lvl5_1;
				saveScore.lvl5_1 = score.score;
				saveScore.changeData ("lvl5_1", score.score);
				saveScore.changeData ("lvl5_2", saveScore.lvl5_2);
				saveScore.changeData ("lvl5_3", saveScore.lvl5_3);
				saveScore.changeData ("lvl5_4", saveScore.lvl5_4);
				saveScore.changeData ("lvl5_5", saveScore.lvl5_5);
			} else if (score.score > saveScore.lvl5_2 && score.score < saveScore.lvl5_1) {
				saveScore.lvl5_5 = saveScore.lvl5_4;
				saveScore.lvl5_4 = saveScore.lvl5_3;
				saveScore.lvl5_3 = saveScore.lvl5_2;
				saveScore.lvl5_2 = score.score;
				saveScore.changeData ("lvl5_2", score.score);
				saveScore.changeData ("lvl5_3", saveScore.lvl5_3);
				saveScore.changeData ("lvl5_4", saveScore.lvl5_4);
				saveScore.changeData ("lvl5_5", saveScore.lvl5_5);
			} else if (score.score > saveScore.lvl5_3 && score.score < saveScore.lvl5_2) {
				saveScore.lvl5_5 = saveScore.lvl5_4;
				saveScore.lvl5_4 = saveScore.lvl5_3;
				saveScore.lvl5_3 = score.score;
				saveScore.changeData ("lvl5_3", score.score);
				saveScore.changeData ("lvl5_4", saveScore.lvl5_4);
				saveScore.changeData ("lvl5_5", saveScore.lvl5_5);
			} else if (score.score > saveScore.lvl5_4 && score.score < saveScore.lvl5_3) {
				saveScore.lvl5_5 = saveScore.lvl5_4;
				saveScore.lvl5_4 = score.score;
				saveScore.changeData ("lvl5_4", score.score);
				saveScore.changeData ("lvl5_5", saveScore.lvl5_5);
			} else if (score.score > saveScore.lvl5_5 && score.score < saveScore.lvl5_4) {
				saveScore.lvl5_5 = score.score;
				saveScore.changeData ("lvl5_5", score.score);
			}
		}

	}

	public void gameOver ()
	{
		Time.timeScale = 0;
		gameOverMenu.SetActive(true);
		scoreDisplay.text = "Score : " + score.score.ToString ();
		Screen.lockCursor = false;
		Screen.showCursor = true;
	}

	public void resumeGame()
	{
		pauseMenu.SetActive (false);
		Time.timeScale = 1; 
		Screen.lockCursor = true;
		Screen.showCursor = false;
	}

	public void menuPrincipal()
	{
		Time.timeScale = 1; 
		Application.LoadLevel (0);
	}

	public void quitter()
	{
		Application.Quit ();
	}

	public void restart()
	{
		Time.timeScale = 1;
		Screen.lockCursor = true;
		Screen.showCursor = false;
		gameOverMenu.SetActive (false);
		Application.LoadLevel(scene);
	}
}
