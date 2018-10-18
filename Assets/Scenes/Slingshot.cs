using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot : MonoBehaviour {

    public GameObject launchPoint;

    //Pg 544 stuff.
    public GameObject prefabProjectile;
    public bool _____;      //This is just to appear as a divider between preset and dynamic public variables. I typed in differently from them tho.
    public Vector3 launchPos;
    public GameObject projectile;
    public bool aimingMode;

    public float velocityMult = 4f;

    void Awake()
    {
        Transform launchPointTrans = transform.Find("LaunchPoint");
        launchPoint = launchPointTrans.gameObject;
        launchPoint.SetActive(false);
        //Pg 544
        launchPos = launchPointTrans.position;
    }
	
    void Update()
    {
        //If Slingshot is not in aimingMode, dont run the code.
        if (!aimingMode) return;

        //////From page 546
        //Get current mouse pos in 2d screen coords.
        Vector3 mousePos2D = Input.mousePosition;
        //Convert the mouse position to 3D world coordinates.
        mousePos2D.z = -Camera.main.transform.position.z;
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);
        //Find the delta from the launchPos to the mousePos3D
        Vector3 mouseDelta = mousePos3D - launchPos;
        //Limit mouseDelta to the radius of the Slingshot SphereCollider
        float maxMagnitude = this.GetComponent<SphereCollider>().radius;
        if(mouseDelta.magnitude > maxMagnitude)
        {
            mouseDelta.Normalize();
            mouseDelta *= maxMagnitude;
        }
        //Move the projectile to this new position.
        Vector3 projPos = launchPos + mouseDelta;
        projectile.transform.position = projPos;

        if(Input.GetMouseButtonUp(0))
        {
            //The mouse has been released.
            aimingMode = false;
            projectile.GetComponent<Rigidbody>().isKinematic = false;
            projectile.GetComponent<Rigidbody>().velocity = -mouseDelta * velocityMult;
            FollowCam.S.poi = projectile;  //From Page 550*********.   //This line will use the singleton to set val of poi for the camera.
            projectile = null;
        }
        //Basically all the above summed up as AMBLAA. A Minus B Looks At A. ****** Which one the vector will point at.
        //PAGE 548!!!!!! More explanation of how it all works.****

    }

    void OnMouseEnter()
    {
        // print("Slingshot:OnMouseEnter()");
        launchPoint.SetActive(true);
    }

    void OnMouseExit()
    {
        //print("Slingshot:OnMouseExit()");
        launchPoint.SetActive(false);

    }

    void OnMouseDown()
    {
        aimingMode = true;
        projectile = Instantiate(prefabProjectile) as GameObject;      //Instantiate a projectile.
        projectile.transform.position = launchPos;    //Start it at the launchPoint.
        projectile.GetComponent<Rigidbody>().isKinematic = true;    //Set it to isKinematic for now.


    }

}
