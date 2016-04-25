using UnityEngine;
using System.Collections;

public class SaveScore : MonoBehaviour {
	private static SaveScore instance = null;
	public static SaveScore Instance {
		get { return instance; }
	}


	public int lvl1_1;
	public int lvl1_2;
	public int lvl1_3;
	public int lvl1_4;
	public int lvl1_5;
	public int lvl2_1;
	public int lvl2_2;
	public int lvl2_3;
	public int lvl2_4;
	public int lvl2_5;
	public int lvl3_1;
	public int lvl3_2;
	public int lvl3_3;
	public int lvl3_4;
	public int lvl3_5;
	public int lvl4_1;
	public int lvl4_2;
	public int lvl4_3;
	public int lvl4_4;
	public int lvl4_5;
	public int lvl5_1;
	public int lvl5_2;
	public int lvl5_3;
	public int lvl5_4;
	public int lvl5_5;

	void Awake()
	{
		if (instance != null && instance != this) {
			Destroy (this.gameObject);
			return;
		} else {
			instance = this;
		}
		DontDestroyOnLoad (transform.gameObject);	}

	void Start () {
		setScore ();
	}
	
	void Update () {
	}

	void setScore()
	{
		lvl1_1 = PlayerPrefs.GetInt ("lvl1_1");
		lvl1_2 = PlayerPrefs.GetInt ("lvl1_2");
		lvl1_3 = PlayerPrefs.GetInt ("lvl1_3");
		lvl1_4 = PlayerPrefs.GetInt ("lvl1_4");
		lvl1_5 = PlayerPrefs.GetInt ("lvl1_5");
		lvl2_1 = PlayerPrefs.GetInt ("lvl2_1");
		lvl2_2 = PlayerPrefs.GetInt ("lvl2_2");
		lvl2_3 = PlayerPrefs.GetInt ("lvl2_3");
		lvl2_4 = PlayerPrefs.GetInt ("lvl2_4");
		lvl2_5 = PlayerPrefs.GetInt ("lvl2_5");
		lvl3_1 = PlayerPrefs.GetInt ("lvl3_1");
		lvl3_2 = PlayerPrefs.GetInt ("lvl3_2");
		lvl3_3 = PlayerPrefs.GetInt ("lvl3_3");
		lvl3_4 = PlayerPrefs.GetInt ("lvl3_4");
		lvl3_5 = PlayerPrefs.GetInt ("lvl3_5");
		lvl4_1 = PlayerPrefs.GetInt ("lvl4_1");
		lvl4_2 = PlayerPrefs.GetInt ("lvl4_2");
		lvl4_3 = PlayerPrefs.GetInt ("lvl4_3");
		lvl4_4 = PlayerPrefs.GetInt ("lvl5_4");
		lvl4_5 = PlayerPrefs.GetInt ("lvl4_5");
		lvl5_1 = PlayerPrefs.GetInt ("lvl5_1");
		lvl5_2 = PlayerPrefs.GetInt ("lvl5_2");
		lvl5_3 = PlayerPrefs.GetInt ("lvl5_3");
		lvl5_4 = PlayerPrefs.GetInt ("lvl5_4");
		lvl5_5 = PlayerPrefs.GetInt ("lvl5_5");

	}

	public void changeData(string lvl, int score)
	{
		PlayerPrefs.SetInt (lvl, score);
	}
}
