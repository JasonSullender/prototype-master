using UnityEngine;
using System.Collections;

public class SpearController : MonoBehaviour {

	

		
		
		void Start () 
		{
			
			Destroy(gameObject, 2);
		}
		
		
		
		void OnTriggerEnter2D (Collider2D col) 
		{
			// If it hits an enemy...
			if(col.tag == "Enemy")
			{
				// ... find the Enemy script and call the Hurt function.
				//col.gameObject.GetComponent<Enemy>().Hurt();
		
				
				Destroy (gameObject);
			}

			
		}
}

