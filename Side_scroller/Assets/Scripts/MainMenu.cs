using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class MainMenu : MonoBehaviour {

	public Text highestScore;

	// Update is called once per frame
	void Start() {
		highestScore.text = "Highscore : " + (int)PlayerPrefs.GetFloat("Highscore");
	}

	public void Restart() {

		SceneManager.LoadScene ("Play");

	}

	public void Exit() {
		Application.Quit();
	}
}
