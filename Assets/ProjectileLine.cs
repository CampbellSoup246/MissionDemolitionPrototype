using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLine : MonoBehaviour {
    //From page 563.
    static public ProjectileLine S; //another Singleton

    public float minDist = 0.1f;    //Set in Unity Inspector pane

    public LineRenderer line;       //Set dynamically \/
    private GameObject _poi;
    public List<Vector3> points;

    void Awake()
    {
        S = this; //Set the singleton
        line = GetComponent<LineRenderer>();  //Get a reference to the LineRenderer
        line.enabled = false; //Disable it till needed.
        points = new List<Vector3>(); //initialize the points list.
    }

    public GameObject poi       //This is a property. So it.s a method masquerading as a field.
    {
        get
        {
            return (_poi);
        }
        set
        {
            _poi = value;
            if(_poi != null)
            {
                line.enabled = false;  //When _poi is set to something new, it resets everything.
                points = new List<Vector3>();
                AddPoint();
            }
        }
    }

    public void Clear() //This can be used to clear the line directly.
    {
        _poi = null;
        line.enabled = false;
        points = new List<Vector3>();
    }

    public void AddPoint()
    {
        Vector3 pt = _poi.transform.position;  //This is called to add a point to the line.
        if(points.Count > 0 && (pt-lastPoint).magnitude < minDist) //If point isnt far enuf from last point, returns.
        {
            return;
        }
        if(points.Count == 0)   //If this is the launch point...
        {
            Vector3 launchPos = Slingshot.S.launchPoint.transform.position;
            Vector3 launchPosDiff = pt - launchPos;  //...it adds an extra bit of line to aid aiming later
            points.Add(pt + launchPosDiff);
            points.Add(pt);
            line.SetVertexCount(2);
            //Sets the first two points
            line.SetPosition(0, points[0]);
            line.SetPosition(1, points[1]);
            //Enables linerenderer.
            line.enabled = true;        
        }
        else
        {
            points.Add(pt);  //Normal behavior of adding a point.
            line.SetVertexCount(points.Count);
            line.SetPosition(points.Count - 1, lastPoint);
            line.enabled = true;
        }
                
    }

    public Vector3 lastPoint        //Returns location of most recently added point.
    {
        get
        {
            if(points == null)
            {
                return (Vector3.zero);  //if there are no points, returns vector3.zero
            }
            return (points[points.Count - 1]);
        }
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(poi == null)
        {
            if(FollowCam.S.poi != null)
            {
                if(FollowCam.S.poi.tag == "Projectile") //If theres no poi, search for one.
                {
                    poi = FollowCam.S.poi;
                }
                else
                {
                    return; //Return if we didnt find a poi.
                }
            }
            else
            {
                return; //return if we didnt find a poi.
            }
        }
        //If there is a po, it's loc is added every FixedUpdate
        AddPoint();
        if(poi.GetComponent<Rigidbody>().IsSleeping())
        {
            poi = null; //Once the poin is sleeping, it is cleared.
        }
	}
}
