using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour {
    //This script from pg 566.

    static public bool goalMet = false; //Static field accessible by code anywhere.

    void OnTriggerEnter(Collider other)
    {
        //When trigger is hit by something, check to see if it's a Projectile.
        if(other.gameObject.tag == "Projectile")
        {
            Goal.goalMet = true;  //If yes, set goalmet true.
            //Color c = renderer.material.color;  //Also set alpha of color to higher opacity.
            //c.a = 1;
            //renderer.material.color = c;
        }
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
