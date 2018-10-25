using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour {
/*
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}
*/

  void OnGui()
  {
      Rect buttonRect = new Rect((Screen.width / 2) - 50, 10, 100, 24);//(0, 0, 50, 50);// //Draw the GUI button for view switching at top of screen.
			//Button buttonRect = this.GetComponent<Button>();
      switch (MissionDemolition.showingStat)
      {
          case "Slingshot":
              if (GUI.Button(buttonRect, "Show Castle"))
              {
                  MissionDemolition.SwitchView("Castle");
              }
              break;
          case "Castle":
              if (GUI.Button(buttonRect, "Show Both"))
              {
                  MissionDemolition.SwitchView("Both");
              }
              break;
          case "Both":
              if (GUI.Button(buttonRect, "Show Slingshot"))
              {
                  MissionDemolition.SwitchView("Slingshot");
              }
              break;
      }
  }
}
