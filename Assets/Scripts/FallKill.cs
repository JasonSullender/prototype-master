using UnityEngine;
using System.Collections;

public class FallKill : MonoBehaviour {

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

	IEnumerator ReloadGame()
	{			
		// ... pause briefly
		yield return new WaitForSeconds(2);
		// ... and then reload the level.
		Application.LoadLevel(Application.loadedLevel);
		//Application.LoadLevel ("prototype");
	}
}
