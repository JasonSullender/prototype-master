/// <summary>
/// Written by Jason Sullender
/// This is used to hurt the enemy when the spear collides with the enemy tag
/// </summary>
using UnityEngine;
using System.Collections;

public class SpearController : MonoBehaviour {

	

		/// <summary>
		/// After 2 seconds we destroy the Spear object
		/// </summary>
		
		void Start () 
	{
			
			Destroy(gameObject, 2);
		}
		
		
		/// <summary>
		/// When the trigger of the collider for the Spear object hits the Enemy object then we call the hurt function that is in the 
	/// Enemy2.cs script
		/// </summary>
		/// <param name="col">Col.</param>
		void OnTriggerEnter2D (Collider2D col) 
		{
			// If it hits an enemy...
			if(col.tag == "Enemy")
			{
				// ... find the Enemy script and call the Hurt function.
				col.gameObject.GetComponent<Enemy2>().Hurt();
			col.gameObject.GetComponent<GorgonEnemy>().Hurt();
			Destroy(gameObject);
		
				
				//Destroy (gameObject);
			}

			
		}
}

