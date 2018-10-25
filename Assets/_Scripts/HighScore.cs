using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour {

	static public int score1 = 10;
	static public int score2 = 10;
	static public int score3 = 10;

	void Awake()
	{
		if(PlayerPrefs.HasKey("Castle1HighScore"))
		{
			score1 = PlayerPrefs.GetInt("Castle1Highscore");
		}
		if(PlayerPrefs.HasKey("Castle2HighScore"))
		{
			score2 = PlayerPrefs.GetInt("Castle2Highscore");
		}
		if(PlayerPrefs.HasKey("Castle3HighScore"))
		{
			score3 = PlayerPrefs.GetInt("Castle3Highscore");
		}
		PlayerPrefs.SetInt("Castle1HighScore", score1);
		PlayerPrefs.SetInt("Castle2HighScore", score2);
		PlayerPrefs.SetInt("Castle3HighScore", score3);
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
