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
    public static int levelStat;    //This is my own, just to avoid making "level" a static var, made this one that just equals it everywhere.
    public int levelMax; //he number of levels
    public int shotsTaken;
    public GameObject castle; //Current castle
    public GameMode mode = GameMode.idle;
    public string showing = "Slingshot"; //FollowCam mode
    public static string showingStat = "Slingshot"; //Also my thing, same deal as levelStat. Tryin get that static var w/o messing up current one.
    //Extra gameover stuff.
    //Animator anim;
    //public static int shotsTaken2;
    public static bool outOfShots = false;  //****** PUT THIS ALSO IN WHEREVER START LEVEL STUFF IS to reset it
    //For GameOver pop up stuff.
    //void Awake()
    //{
        //anim = GetComponent<Animator>();
   // }


    // Use this for initialization
    void Start() {
        S = this; //define the Singelton
        level = 0;
        levelStat = level;
        levelMax = castles.Length;

        //Begin extra stuff for ShotLimit.
        /*
        Text gameOver = this.GetComponent<Text>();
        newHigh.enabled = false;
        newHigh.text = "New high score!";*/
        //End extra stuff.
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
        outOfShots = false; //Rest GameOver pop up thingy, done on my own.
        RestartButton.clicked = false;  //Reset GameOver popup Restart button trigger, done on my own.
        ButtonScript.clickedButt = false;
        ShowGT();

        mode = GameMode.playing;
    }

    void ShowGT()
    {           //Shows the data in the UI texts.
        gtLevel.text = "Level: " + (level + 1) +" of " + levelMax;
        gtScore.text = "Shots taken: " + shotsTaken;// + "/10";
    }
    // Update is called once per frame
    void Update() {

        ShowGT(); //added on my own to try make text update with each shot.

        if (mode == GameMode.playing && Goal.goalMet) //Check for level end
        {
            if(level == 0 && shotsTaken < HighScore.score1) //All if statements below to check if level HS is better.
            {
              HighScore.score1 = shotsTaken;
              Debug.Log("Score of 1 is " + HighScore.score1 + " while shots taken are " + shotsTaken);
            }
            if(level == 1 && shotsTaken < HighScore.score2)
            {
              HighScore.score2 = shotsTaken;
              Debug.Log("Score of 2 is " + HighScore.score2 + " while shots taken are " + shotsTaken);

            }
            if(level == 2 && shotsTaken < HighScore.score3)
            {
              HighScore.score3 = shotsTaken;
              Debug.Log("Score of 3 is " + HighScore.score3 + " while shots taken are " + shotsTaken);

            }
            mode = GameMode.levelEnd; //change mode to stop checking for level end.
            SwitchView("Both"); //zoomout
            Invoke("NextLevel", 2f); //start next level in 2 secs.
        }

        //begin extra stuff for ShotsLimit and gameOver anim stuff.
        else
        {
            if(shotsTaken >= 10)
            {
                //anim.SetTrigger("GameOver");
                //shotsTaken2 = shotsTaken;
                outOfShots = true;
            }
        }
/*
        if (RestartButton.clicked == true)
        {
            //level = 0;        //This would reset player back to level 0 .
            StartLevel();
        }*/

    }

    void NextLevel()
    {
        level++;
        levelStat = level;
        if (level == levelMax)
        {
            level = 0;      //If level is at the max # of levels there are, start from beginning again.
            levelStat = level;
        }
        StartLevel();
    }
/*
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
    }*/

    static public void SwitchView(string eView) //static method allows code anywhere to request a view change
    {
        S.showing = eView;
        showingStat = S.showing;
        switch (S.showing)
        {
            case "Slingshot":
                FollowCam.S.poi = null;
//Added this here to try and reduc lingering projectiles. Keeps newest two projectiles in case player hits Slingshot button while its flying still.
//Nevermind, this breaks stuff.
                /*GameObject[] gos = GameObject.FindGameObjectsWithTag("Projectile");
                //foreach (GameObject ptempt in gos)
                for(int i = 0; i < gos.Length-2; i++)
                {
                    Destroy(gos[i]);
                }*/

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
