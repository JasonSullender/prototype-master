/// <summary>
/// Written by Jason Sullender
/// This is on the camera in the death scene to either reset the game or quit
/// </summary>
using UnityEngine;
using System.Collections;

public class Death : MonoBehaviour {


	/// <summary>
	/// Reset the game to level one scene
	/// </summary>
		public void Reset()
		{
			Application.LoadLevel ("LevelOne");
		}
		/// <summary>
		/// Quits the game
		/// </summary>
		public void ExitGame()
		{
		Application.LoadLevel ("Main Menu");
		}
	

}
