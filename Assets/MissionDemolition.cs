using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


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
    public Text gtLevel; //The GT_level Text
    public Text gtScore; //The GT_Score Text
    public Vector3 castlePos; //Place to put castles

    //All below fields set dynamically.
    public int level; //he current level.
    public int levelMax; //he number of levels
    public int shotsTaken;
    public GameObject castle; //Current castle
    public GameMode mode = GameMode.idle;
    public string showing = "Slingshot"; //FollowCam mode


    // Use this for initialization
    void Start() {
        S = this; //define the Singelton
        level = 0;
        levelMax = castles.Length;
        StartLevel();
    }

    void StartLevel()
    {
        if (castle != null)
        {
            Destroy(castle); //Get rid of old castle if one exists.
        }
        GameObject[] gos = GameObject.FindGameObjectsWithTag("Projectile");     //Destroy old projectiles.
        foreach (GameObject ptempt in gos)
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
        gtLevel.text = "Level: " + (level + 1) +" of " + levelMax;
        gtScore.text = "Shots taken: " + shotsTaken;
    }
    // Update is called once per frame
    void Update() {
        if (mode == GameMode.playing && Goal.goalMet) //Check for level end
        {
            mode = GameMode.levelEnd; //change mode to stop checking for level end.
            SwitchView("Both"); //zoomout
            Invoke("NextLevel", 2f); //start next level in 2 secs.
        }
    }

    void NextLevel()
    {
        level++;
        if (level == levelMax)
        {
            level = 0;      //If level is at the max # of levels there are, start from beginning again.
        }
        StartLevel();
    }

    void OnGui()
    {
        Rect buttonRect = new Rect(0, 0, 50, 50);//(Screen.width / 2) - 50, 10, 100, 24); //Draw the GUI button for view switching at top of screen.
        switch (showing)
        {
            case "Slingshot":
                if (GUI.Button(buttonRect, "Show Castle"))
                {
                    SwitchView("Castle");
                }
                break;
            case "Castle":
                if (GUI.Button(buttonRect, "Show Both"))
                {
                    SwitchView("Both");
                }
                break;
            case "Both":
                if (GUI.Button(buttonRect, "Show Slingshot"))
                {
                    SwitchView("Slingshot");
                }
                break;
        }
    }

    static public void SwitchView(string eView) //static method allows code anywhere to request a view change
    {
        S.showing = eView;
        switch (S.showing)
        {
            case "Slingshot":
                FollowCam.S.poi = null;
                break;
            case "Castle":
                FollowCam.S.poi = S.castle;
                break;
            case "Both":
                FollowCam.S.poi = GameObject.Find("ViewBoth");
                break;
        }
    }

    public static void ShotFired()  //Static method, code anywhere can increment shotsTaken 
    {
        S.shotsTaken++;
    }
}
