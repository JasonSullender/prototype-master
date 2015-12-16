/// <summary>
/// written by jason sullender
/// the armor class attached to the 'armor' prefab.
/// this is used so that the the player health will go up by one when the player picks up 
/// the 'armor' prefab. this prefab is only available for pickup if the player has the 
/// helmet prefab on. 
/// </summary>
using UnityEngine;
using System.Collections;

public class Armor : MonoBehaviour {
	/// <summary>
	/// when the player collides with the 'armor' prefab destroy the armor prefab
	/// </summary>
	/// <param name="col">Col.</param>
	void OnTriggerEnter2D (Collider2D col) 
	{
		// If it hits an enemy...
		if(col.tag == "Player")
		{
			Destroy (gameObject);
		}
}
}