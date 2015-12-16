/// <summary>
/// Written by Jason Sullender
/// THis destorys the helmet prefab when the player collides with it
/// </summary>
using UnityEngine;
using System.Collections;

public class Helmet : MonoBehaviour {
	/// <summary>
	/// When player tag collides destroy the helmet prefab
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
