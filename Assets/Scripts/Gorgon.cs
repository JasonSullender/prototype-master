/// <summary>
/// Written by Jason Sullender
/// This is class that is on the object attached to the gorgon to fire the freeze cone at the player
/// </summary>
using UnityEngine;
using System.Collections;

public class Gorgon : MonoBehaviour {

	public Rigidbody2D freeze;//freeze rigidbody				
	public float speed;//speed of the freeze				
	private float startTime=3f;//timer count down till the next fire of the freeze
	private GorgonEnemy gorgonCtrl;//reference to the gorgon controller code
	/// <summary>
	/// gets the gorgon controller code
	/// </summary>
	void Start()
	{
		
		
		gorgonCtrl = transform.root.GetComponent<GorgonEnemy>();
	}
	/// <summary>
	/// Counts down timer once timer is zero then triggers the shoot function
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
	/// Instantiate freeze then call resettimer
	/// </summary>
	public void Shoot()
	{
		
		if(gorgonCtrl.moveRight)
		{

			
			Rigidbody2D bulletInstance = Instantiate(freeze, transform.position, Quaternion.Euler(new Vector3(0f,0,-180f))) as Rigidbody2D;
			bulletInstance.velocity = new Vector2(speed, 0);
		}
		else
		{

			
			Rigidbody2D bulletInstance = Instantiate(freeze, transform.position, Quaternion.Euler(new Vector3(0f,0f,180f))) as Rigidbody2D;
			bulletInstance.velocity = new Vector2(-speed, 0);
		}
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
