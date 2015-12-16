/// <summary>
/// Written by Jason Sullender
/// Runs the main menu buttons
/// </summary>
using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	/// <summary>
	/// When the playgame button is pressed we load the PlatformPrototype scene
	/// The options brings up the options menu
	/// The exit button will end the application.
	/// </summary>
	// Update is called once per frame
	void Update () {
	
	}
	
	public void PlayGame()
	{
		Application.LoadLevel ("LevelOne");
	}
	public void Options()
	{
		Application.LoadLevel ("Options Menu");
	}
	public void ExitGame()
	{
		Application.Quit();
	}
}
