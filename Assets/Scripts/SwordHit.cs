using UnityEngine;
using System.Collections;

public class SwordHit : MonoBehaviour {
/// <summary>
/// Destroy the Sword after .1 seconds
/// </summary>
	void Start () 
	{
		
		Destroy(gameObject, .1f);
	}
	
	
	/// <summary>
	/// If the sword collides with the Enemy object then we call the Hurt function in the Enemy2.cs class
	/// </summary>
	/// <param name="col">Col.</param>
	void OnTriggerEnter2D (Collider2D col) 
	{
		// If it hits an enemy...
		if(col.tag == "Enemy")
		{
			// ... find the Enemy script and call the Hurt function.
			col.gameObject.GetComponent<Enemy2>().Hurt();
			col.gameObject.GetComponent<GorgonEnemy>().Hurt ();
			
			//Destroy (gameObject);
		}
		
		
	}
}
