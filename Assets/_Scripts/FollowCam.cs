using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{

    //Page 549.
    static public FollowCam S;  //a FollowCam Singleton

    public GameObject poi; //point of interest. Fields set dynamically. Set in unity insp. pane
    public float camZ; //The desired Z pos of the camera. Fields set dynamically. set in unity insp. pane

    // Pg 550
    public float easing = 0.05f;
    //Pg 552
    public Vector2 minXY;

    public static bool shotEnded = false;  //My own, to try and make GameOver anim. not play till ball is at rest.

    void Awake()
    {
        //Page 549
        S = this;
        camZ = this.transform.position.z;
    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        shotEnded = false; // My thing, resets shotEnded to false every time hopefully quick enough so that gameover will not occur mid-shot for player.

        //Page 549
        Vector3 destination;  //= poi.transform.position; //Get position of poi. //comment out is From pg 562
        if (poi == null)   //If no poi, return P:0,0,0. Pg 562
        {
            destination = Vector3.zero;

        }
        else
        {
            destination = poi.transform.position;   //Get position of the poi.
            if (poi.tag == "Projectile")  //If poi is a Projectile, check if at rest.
            {
                if (poi.GetComponent<Rigidbody>().IsSleeping())  //If is sleeping (i.e. not moving)
                {
                    poi = null;  //return to default view.
                    //MissionDemolition.ShotFired();      //Added in on my own to try and make shot count go up. //Somewhere else in script already does it.
                    //GameOver();             //Trying this so that once projectile stops moving, if shots are out, will bring gameover screen up.
                    shotEnded = true;
                    return;  //in the next update
                }
            }
        }
        //end modifications from pg 562.

        //Limit the X and Y to min values. Pg 552.
        destination.x = Mathf.Max(minXY.x, destination.x);
        destination.y = Mathf.Max(minXY.y, destination.y);

        destination = Vector3.Lerp(transform.position, destination, easing); //Inerpolate from current Camera position towards destination. //Pg550.

        destination.z = camZ; //retain a destination.z of camZ
        transform.position = destination;  //Set the camera to the destination.
        this.GetComponent<Camera>().orthographicSize = destination.y + 10;  //Set the orthSize of Camera to keep Ground in view.


    }
}
