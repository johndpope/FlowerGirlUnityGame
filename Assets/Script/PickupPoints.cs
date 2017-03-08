using UnityEngine;
using System.Collections;

public class PickupPoints : MonoBehaviour {

	public int scoreToGive;

	private ScoreManager theScoreManager;

	private AudioSource flowerSound;

	// Use this for initialization
	void Start () {
		theScoreManager = FindObjectOfType<ScoreManager> ();
	
		flowerSound = GameObject.Find ("FlowerSound").GetComponent<AudioSource> ();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.name == "Player") {
			theScoreManager.AddScore(scoreToGive);
			gameObject.SetActive (false);

			/*if (flowerSound.isPlaying) {
				flowerSound.Stop ();
				flowerSound.Play ();
			} else {
			*/	flowerSound.Play ();
			//}
		}
	}
}
