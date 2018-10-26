using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour {

	public static bool clickedButt = false;
	public Button buttonComponentSling;

	// Use this for initialization
	void Start () {
			buttonComponentSling.onClick.AddListener(HandleClick);
			//Debug.Log("In start of button script");

	}

// Update is called once per frame
void Update () {

}
	public void HandleClick()
	{
			clickedButt = true;
	}

	public void SwitchToSlingshot()
	{
		Debug.Log("Switching to Slingshot");

		MissionDemolition.SwitchView("Slingshot");
	}

/* This stuff from the book to make the button appear to switch views just doesnt wanna work some reason.:
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
  }*/
}
