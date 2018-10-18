using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour {

    //Page 549.
    static public FollowCam S;  //a FollowCam Singleton

    public GameObject poi; //point of interest. Fields set dynamically. Set in unity insp. pane
    public float camZ; //The desired Z pos of the camera. Fields set dynamically. set in unity insp. pane

    void Awake()
    {
        //Page 549
        S = this;
        camZ = this.transform.position.z;
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //Page 549
        if (poi == null) return;

        Vector3 destination = poi.transform.position; //Get position of poi
        destination.z = camZ; //retain a destination.z of camZ
        transform.position = destination;  //Set the camera to the destination.



	}
}
