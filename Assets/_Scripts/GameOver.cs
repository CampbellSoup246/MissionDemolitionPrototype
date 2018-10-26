using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour {

    Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (MissionDemolition.outOfShots == true && FollowCam.shotEnded == true)
        {
            anim.SetTrigger("GameOver");

        }
        if(RestartButton.clicked == true)
        {
            anim.SetTrigger("RestartTrig");
        }
    }
}
