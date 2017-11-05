using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	public float score;
	public Text scoreValues;
	public PlayerController contoller;
	public float prevHighscore;

	// Use this for initialization
	void Start () {
		prevHighscore = PlayerPrefs.GetFloat ("Highscore");
	}
	
	// Update is called once per frame
	void Update () {
		if (scoreValues != null) {
			score += contoller.runSpeed * Time.deltaTime;
			scoreValues.text = ("Score :  ") + ((int)score).ToString ();
		}
		if (contoller.dead) {
			Destroy (scoreValues);
		}
		if (score > prevHighscore) {
			PlayerPrefs.SetFloat ("Highscore", score);
		}
	}
}
