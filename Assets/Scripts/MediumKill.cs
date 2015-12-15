using UnityEngine;
using System.Collections;

public class MediumKill : MonoBehaviour {

	public Rigidbody2D fireBall;				
	public float speed;				
	public Vector2 spawnSpot;
	private float startTime=3f;
	/// <summary>
	/// Count down the timer from 3 to zero then call Shoot function
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
	/// Instantiate fireball then call resettimer
	/// </summary>
	public void Shoot()
	{
		
		Rigidbody2D bulletInstance = Instantiate(fireBall,spawnSpot, Quaternion.Euler(new Vector3(0f,0f,0f)))as Rigidbody2D;
		bulletInstance.velocity = new Vector2(0,-speed);
		ResetTimer ();
		
	}
	/// <summary>
	/// Resets time to 3
	/// </summary>
	public void ResetTimer()
	{
		startTime = 3f;
	}

}
