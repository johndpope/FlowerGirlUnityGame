using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public string playGameLevel;

	public void PlayGame()
	{
		//Application.LoadLevel (playGameLevel);
		SceneManager.LoadScene (playGameLevel);
	}
		

	public void QuitGame()
	{
		Application.Quit ();
	}
}
