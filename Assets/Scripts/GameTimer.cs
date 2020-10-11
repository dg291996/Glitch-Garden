﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameTimer : MonoBehaviour {
	public float levelSeconds=100;

	private bool isEndOfLevel = false;
	private AudioSource audioSource;
	private Slider slider;
	private LevelManager levelManager;
	private GameObject winLabel;

	// Use this for initialization
	void Start () {
		slider = GetComponent<Slider> ();
		audioSource = GetComponent<AudioSource> ();
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
		FindYouWin ();
		winLabel.SetActive (false);
	}

	void FindYouWin ()
	{
		winLabel = GameObject.Find ("You Win");
		if (!winLabel) {
			Debug.LogWarning ("Create You Win");
		}
	}
	 
	// Update is called once per frame
	void Update () {
		slider.value=Time.timeSinceLevelLoad/levelSeconds;
		bool timeIsUp = (Time.timeSinceLevelLoad >= levelSeconds);
		if (timeIsUp && !isEndOfLevel) {
			audioSource.Play ();
			winLabel.SetActive(true);
			Invoke ("LoadNextLevel", audioSource.clip.length);
			isEndOfLevel = true;
		}
	}
	void LoadNextLevel(){
		levelManager.LoadNextLevel ();
	}
}
