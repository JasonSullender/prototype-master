using UnityEngine;
using System.Collections;

public class CrumbleCube : MonoBehaviour {
	public Renderer rend;
	public Material crumble;

	void Start()
	{

	}
	/// <summary>
	/// When the Player object collides with the crumble cube object the material changes and the
	/// crumble cube object is destroyed after half a second
	/// </summary>
	/// <param name="col">Col.</param>
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
