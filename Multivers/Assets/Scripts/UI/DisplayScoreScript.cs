using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DisplayScoreScript : MonoBehaviour {

	private GameObject score_obj;
	private SaveScore saveScore;

	public Text lvl1score1;
	public Text lvl1score2;
	public Text lvl1score3;
	public Text lvl1score4;
	public Text lvl1score5;
	public Text lvl2score1;
	public Text lvl2score2;
	public Text lvl2score3;
	public Text lvl2score4;
	public Text lvl2score5;
	public Text lvl3score1;
	public Text lvl3score2;
	public Text lvl3score3;
	public Text lvl3score4;
	public Text lvl3score5;
	public Text lvl4score1;
	public Text lvl4score2;
	public Text lvl4score3;
	public Text lvl4score4;
	public Text lvl4score5;
	public Text lvl5score1;
	public Text lvl5score2;
	public Text lvl5score3;
	public Text lvl5score4;
	public Text lvl5score5;



	void Start () {
		score_obj = GameObject.FindGameObjectsWithTag ("Score")[0];
		saveScore = score_obj.GetComponent<SaveScore> ();
		lvl1score1.text = "1 : " + saveScore.lvl1_1;
		lvl1score2.text = "2 : " + saveScore.lvl1_2;
		lvl1score3.text = "3 : " + saveScore.lvl1_3;
		lvl1score4.text = "4 : " + saveScore.lvl1_4;
		lvl1score5.text = "5 : " + saveScore.lvl1_5;
		lvl2score1.text = "1 : " + saveScore.lvl2_1;
		lvl2score2.text = "2 : " + saveScore.lvl2_2;
		lvl2score3.text = "3 : " + saveScore.lvl2_3;
		lvl2score4.text = "4 : " + saveScore.lvl2_4;
		lvl2score5.text = "5 : " + saveScore.lvl2_5;
		lvl3score1.text = "1 : " + saveScore.lvl3_1;
		lvl3score2.text = "2 : " + saveScore.lvl3_2;
		lvl3score3.text = "3 : " + saveScore.lvl3_3;
		lvl3score4.text = "4 : " + saveScore.lvl3_4;
		lvl3score5.text = "5 : " + saveScore.lvl3_5;
		lvl4score1.text = "1 : " + saveScore.lvl4_1;
		lvl4score2.text = "2 : " + saveScore.lvl4_2;
		lvl4score3.text = "3 : " + saveScore.lvl4_3;
		lvl4score4.text = "4 : " + saveScore.lvl4_4;
		lvl4score5.text = "5 : " + saveScore.lvl4_5;
		lvl5score1.text = "1 : " + saveScore.lvl5_1;
		lvl5score2.text = "2 : " + saveScore.lvl5_2;
		lvl5score3.text = "3 : " + saveScore.lvl5_3;
		lvl5score4.text = "4 : " + saveScore.lvl5_4;
		lvl5score5.text = "5 : " + saveScore.lvl5_5;
	

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
