using UnityEngine;
using System.Collections;

public class MoveOn : MonoBehaviour {

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
	IEnumerator NextLevel()
	{			
		// ... pause briefly
		yield return new WaitForSeconds(2);
		// ... and then reload the level.
		Application.LoadLevel("LevelTwo");
		//Application.LoadLevel ("prototype");
	}
}
