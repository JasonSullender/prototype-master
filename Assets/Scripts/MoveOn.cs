/// <summary>
/// Written by Jason Sullender
/// when the player collides move on to level two
/// </summary>
using UnityEngine;
using System.Collections;

public class MoveOn : MonoBehaviour {
	/// <summary>
	/// When player collides keep the player attributes and go to next level coroutine
	/// </summary>
	/// <param name="col">Col.</param>
	void OnTriggerEnter2D(Collider2D col)
	{
		// If the player hits the trigger...
		if(col.gameObject.tag == "Player")
		{
			
			// ... destroy the player.
			DontDestroyOnLoad (col.gameObject);
			// ... reload the level.
			StartCoroutine("NextLevel");
		}
	
	}
	/// <summary>
	/// wait two seconds then load level two
	/// </summary>
	/// <returns>The level.</returns>
	IEnumerator NextLevel()
	{			
		// ... pause briefly
		yield return new WaitForSeconds(2);
		// ... and then reload the level.
		Application.LoadLevel("LevelTwo");
		//Application.LoadLevel ("prototype");
	}
}
