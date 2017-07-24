using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public static void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void GoToExemple2()
    {
        SceneManager.LoadScene("Example2");
    }

}
