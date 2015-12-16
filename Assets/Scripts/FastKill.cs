/// <summary>
/// Written by Jason Sullender
/// This fires the faster fireball prefab to hurt the player
/// </summary>
using UnityEngine;
using System.Collections;

public class FastKill : MonoBehaviour {

	public Rigidbody2D fireBall;//rigid body of fireball prefab				
	public float speed;//speed of fireball prefab				
	public Vector2 spawnSpot;//spot where the prefab is instantiated
	private float startTime=2f;//wait time to shoot the prefab
	
	/// <summary>
	/// Starts timer from 2 to zero then calls the shoot function
	/// </summary>
	void Update()
	{
		startTime -= Time.deltaTime;
		print (startTime);
		if (startTime <= 0f)
		{
			Shoot ();
		}
	}
	/// <summary>
	/// Instantiates fireball then calls the resettimer function
	/// </summary>
	public void Shoot()
	{
		
		Rigidbody2D bulletInstance = Instantiate(fireBall,spawnSpot, Quaternion.Euler(new Vector3(0f,0,0f)))as Rigidbody2D;
		bulletInstance.velocity = new Vector2(0,-speed);
		ResetTimer ();
		
	}
	/// <summary>
	/// Resets the timer to 2
	/// </summary>
	public void ResetTimer()
	{
		startTime = 2f;
	}

}
