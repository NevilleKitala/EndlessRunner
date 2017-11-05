using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class DeathMenu : MonoBehaviour {

	public Image backgroundImage;
	public Text scoreText;

	public float transition = 0.0f;
	public bool isShown = false;
	// Use this for initialization
	void Start () {
		
		gameObject.SetActive (false);

	}
	
	// Update is called once per frame
	void Update () {

		if (!isShown) 
			return;

		transition += Time.deltaTime;
		backgroundImage.color = Color.Lerp (new Color (0, 0, 0, 0), new Color (255, 255, 255, 0.8f), transition);
	}

	public void ToggleEndMenu(float score) {
		gameObject.SetActive (true);
		scoreText.text = ((int)score).ToString();
		isShown = true;
	}

	public void Restart() {

		SceneManager.LoadScene ("Play");

	}

	public void Menu() {
		SceneManager.LoadScene ("Menu");
	}
}
