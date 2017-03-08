﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public Text scoreText;
	public Text highScoreText;

	public float scoreCount;
	public float highScoreCount;

	public float pointsPerSecond;

	public bool scoreIncreasing;

	// Use this for initialization
	void Start () {
		if (PlayerPrefs.HasKey ("HighScore")) 
		{
			highScoreCount = PlayerPrefs.GetFloat ("HighScore");
		}
	}
	
	// Update is called once per frame
	void Update () {

		if (scoreIncreasing) {
			scoreCount += pointsPerSecond;
		}
			
		if (scoreCount > highScoreCount) {
		
			highScoreCount = scoreCount;
			PlayerPrefs.SetFloat ("HighScore", highScoreCount);
		}

		scoreText.text = "Score: " + Mathf.Round(scoreCount);

		highScoreText.text = "High Score: " + Mathf.Round(highScoreCount);

	}

	public void AddScore(int pointsToAdd)
	{
		scoreCount += pointsToAdd;
	}
}
