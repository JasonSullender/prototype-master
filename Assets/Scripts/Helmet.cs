﻿using UnityEngine;
using System.Collections;

public class Helmet : MonoBehaviour {
	void OnTriggerEnter2D (Collider2D col) 
	{
		// If it hits an enemy...
		if(col.tag == "Player")
		{
			Destroy (gameObject);
		}
		
		
	}

}