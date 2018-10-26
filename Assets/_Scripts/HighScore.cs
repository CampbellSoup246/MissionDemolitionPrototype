using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour {

  public static int score1 = 10;
	public static int score2 = 10;
	public static int score3 = 10;

	void Awake()
	{
		if(PlayerPrefs.HasKey("Castle1HighScore"))
		{
			score1 = PlayerPrefs.GetInt("Castle1HighScore");
		}
		if(PlayerPrefs.HasKey("Castle2HighScore"))
		{
			score2 = PlayerPrefs.GetInt("Castle2HighScore");
		}
		if(PlayerPrefs.HasKey("Castle3HighScore"))
		{
			score3 = PlayerPrefs.GetInt("Castle3HighScore");
		}
		PlayerPrefs.SetInt("Castle1HighScore", score1);
		PlayerPrefs.SetInt("Castle2HighScore", score2);
		PlayerPrefs.SetInt("Castle3HighScore", score3);

/*
		score1 = 10;
		score2 = 10;
		score3 = 10;
		PlayerPrefs.SetInt("Castle1HighScore", 10);
		PlayerPrefs.SetInt("Castle2HighScore", 10);
		PlayerPrefs.SetInt("Castle3HighScore", 10);
		*/
	}
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		Text scoreText = this.GetComponent<Text>();
		if(MissionDemolition.levelStat == 0)
		{
			scoreText.text = "High Score: " + score1;
			if(score1 < PlayerPrefs.GetInt("Castle1HighScore"))
			{
				PlayerPrefs.SetInt("Castle1HighScore", score1);
			}
		}
		if(MissionDemolition.levelStat == 1)
		{
			scoreText.text = "High Score: " + score2;
			if(score2 < PlayerPrefs.GetInt("Castle2HighScore"))
			{
				PlayerPrefs.SetInt("Castle2HighScore", score2);
			}
		}
		if(MissionDemolition.levelStat == 2)
		{
			scoreText.text = "High Score: " + score3;
			if(score3 < PlayerPrefs.GetInt("Castle3HighScore"))
			{
				PlayerPrefs.SetInt("Castle3HighScore", score3);
			}
		}



	}
}
