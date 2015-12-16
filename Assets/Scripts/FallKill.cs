/// <summary>
/// Written by Jason Sullender
/// this will kill the player when the player comes in contact with the fall kill
/// </summary>
using UnityEngine;
using System.Collections;

public class FallKill : MonoBehaviour {
	/// <summary>
	/// When the Player object collides with the killtrigger object then we destroy the Player object and call the ReloadGame
	/// If it is not the player we just destroy that game object.
	/// </summary>
	/// <param name="col">Col.</param>
	void OnTriggerEnter2D(Collider2D col)
	{
		// If the player hits the trigger...
		if(col.gameObject.tag == "Player")
		{
		
			// ... destroy the player.
			Destroy (col.gameObject);
			// ... reload the level.
			StartCoroutine("ReloadGame");
		}
		else
		{

			// Destroy the enemy.
			Destroy (col.gameObject);	
		}
	}
	/// <summary>
	/// This Coroutine waits for 2 seconds then reloads the level that we were playing.
	/// </summary>
	/// <returns>The game.</returns>
	IEnumerator ReloadGame()
	{			
		// ... pause briefly
		yield return new WaitForSeconds(2);
		// ... and then reload the level.
		Application.LoadLevel("DeathScreen");
		//Application.LoadLevel ("prototype");
	}
}
