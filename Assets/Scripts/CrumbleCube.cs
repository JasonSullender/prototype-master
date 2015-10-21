using UnityEngine;
using System.Collections;

public class CrumbleCube : MonoBehaviour {
	public Renderer rend;
	public Material crumble;

	void Start()
	{

	}
	void OnCollisionEnter2D (Collision2D col) 
	{ 
		print ("detected collision between" + gameObject.name + "and" + col.collider.name);
		if (col.collider.name == "Player") 
		{
			rend.material=crumble;
			Destroy (gameObject,.5f);
		}
		
	}
}
