using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour {

    //Made as extra, part of GameOver sequence. Trying to get button to work.
    public static bool clicked = false;
    public Button buttonComponent;

    // Use this for initialization
    void Start () {
        buttonComponent.onClick.AddListener(HandleClick);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void HandleClick()
    {
        clicked = true;
    }

    public void LoadByIndex(int sceneIndex)
    {
        //SceneManager.LoadScene(sceneIndex);

    }
}
