using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenuStartButton : MonoBehaviour {

	// Use this for initialization
	public void StartGame() {
	    SceneManager.LoadScene(1);
	}

    public void ExitGame()
    {
        Application.Quit();
    }
}
