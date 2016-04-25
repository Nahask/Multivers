using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	public float time;
	public Text timeDisplay;
	public int score;
	public Text scoreDisplay;
	public int mult;
	public Text multDisplay;
	
	public float timerScore;
	public int tmpScore;

	void Start () {
		timerScore = 0;
		time = 0;
		score = 0;
		mult = 0;
		tmpScore = 0;
	}
	
	void Update () {
		getAndDisplayTime ();
		getAndDisplayScore ();
		getAndDisplayMult ();
	}

	void getAndDisplayTime()
	{
		time +=  Time.deltaTime	;
		timeDisplay.text = time.ToString("0") + " s";
	}
	
	void getAndDisplayScore()
	{
		scoreDisplay.text =  score.ToString ();

	}

	void getAndDisplayMult ()
	{
		timerScore += Time.deltaTime;
		multDisplay.text = timerScore.ToString("0") + " s    " +  "X" + mult.ToString();
		if (timerScore >= 4.0f) {
			score = tmpScore * mult + score;
			tmpScore = 0;
			mult = 0;
			timerScore = 0.0f;
		}
	}
}
