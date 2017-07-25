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

    public void GoToExemple1()
    {
        SceneManager.LoadScene("Example1");
    }

    public void GoToExemple2()
    {
        SceneManager.LoadScene("Example2");
    }

    public void GoToExemple3()
    {
        SceneManager.LoadScene("Example3");
    }

    public void GoToExemple4()
    {
        SceneManager.LoadScene("Example4");
    }

}
