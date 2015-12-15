using UnityEngine;
using System.Collections;

public class FastKill : MonoBehaviour {

	public Rigidbody2D fireBall;				
	public float speed;				
	public Vector2 spawnSpot;
	private float startTime=2f;
	
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
