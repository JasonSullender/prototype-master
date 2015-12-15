using UnityEngine;
using System.Collections;

public class Gorgon : MonoBehaviour {

	public Rigidbody2D freeze;				
	public float speed;				
	private float startTime=3f;
	private GorgonEnemy gorgonCtrl;

	void Start()
	{
		
		
		gorgonCtrl = transform.root.GetComponent<GorgonEnemy>();
	}
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
