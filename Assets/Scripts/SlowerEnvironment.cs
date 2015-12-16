/// <summary>
/// Written by Jason Sullender
/// Shoots the fireball prefab when after a certain amount of time to hurt the player
/// </summary>
using UnityEngine;
using System.Collections;

public class SlowerEnvironment : MonoBehaviour {
	public Rigidbody2D fireBall;//fireball prefab				
	public float speed;	//speed of fireball			
	public Vector2 spawnSpot;//spawn of fireball
	private float startTime=4f;//count down seconds till next fireball shoot

	/// <summary>
	/// Starts timer from 4 seconds to zero then calls the shoot function
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
	/// Instantiates the fireball then calls the reset timer function
	/// </summary>
	public void Shoot()
	{

		Rigidbody2D bulletInstance = Instantiate(fireBall,spawnSpot, Quaternion.Euler(new Vector3(0f,0,0f)))as Rigidbody2D;
		bulletInstance.velocity = new Vector2(0,-speed);
		ResetTimer ();

	}
	/// <summary>
	/// Resets the timer to 4 seconds
	/// </summary>
	public void ResetTimer()
	{
		startTime = 4f;
	}

	}

