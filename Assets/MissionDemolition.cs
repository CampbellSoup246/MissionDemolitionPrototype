using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameMode
{
    idle,
    playing,
    levelEnd
}
public class MissionDemolition : MonoBehaviour {
    //All this code from page 569 as of now. ***************

    static public MissionDemolition S; //Singleton again.

    //All below set in Inspector pane
    public GameObject[] castles; //Array of castles
    public GUIText gtLevel; //The GT_level Text
    public GUIText gtScore; //The GT_Score Text
    public Vector3 castlePos; //Place to put castles

    //All below fields set dynamically.
    public int level; //he current level.
    public int levelMax; //he number of levels
    public int shotsTaken;
    public GameObject castle; //Current castle
    public GameMode mode = GameMode.idle;
    public string showing = "Slingshot"; //FollowCam mode

  
    // Use this for initialization
    void Start () {
        S = this; //define the Singelton
        level = 0;
        levelMax = castles.Length;
        StartLevel();
	}
	
    void StartLevel()
    {
        if(castle != null)
        {
            Destroy(castle); //Get rid of old castle if one exists.
        }
        GameObject[] gos = GameObject.FindGameObjectsWithTag("Projectile");     //Destroy old projectiles.
        foreach(GameObject ptempt in gos)
        {
            Destroy(ptempt);
        }

        castle = Instantiate(castles[level]) as GameObject;     //Instantiate new castle.
        castle.transform.position = castlePos;
        shotsTaken = 0;

        SwitchView("Both");//reset camera 
        ProjectileLine.S.Clear();

        Goal.goalMet = false; //Reset goal

        ShowGT();

        mode = GameMode.playing;
    }

    void ShowGT()
    {           //Shows the data in the UI texts.
        gtLevel.text = "Level: " + (level + 1) + +" of " + levelMax;
        gtScore.text = "Shots taken: " + shotsTaken;
    }
	// Update is called once per frame
	void Update () {
		
	}
}
