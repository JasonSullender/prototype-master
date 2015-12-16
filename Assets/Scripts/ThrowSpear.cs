/// <summary>
/// Written by Jason Sullender
/// Instantiates a spear on the player 
/// </summary>
using UnityEngine;
using System.Collections;

public class ThrowSpear : MonoBehaviour {

	public Rigidbody2D spear;//rigidbody of spear				
	public float speed;		//speed of spear		
	public float fireRate;//When another spear can instantiate
	
	private CharController playerCtrl;	//player controller code	
	private float nextFire;//Time until next fire
	private Animator throwanim;//Player throw animation
	
	/// <summary>
	/// We get the charcontroller component to reference code.
	/// </summary>
	void Start()
	{


		playerCtrl = transform.root.GetComponent<CharController>();
	}
	
	/// <summary>
	/// If the space button is pressed and the time for the fire is ready then we check which way the Player object is facing
	/// If the Player object is facing right then we instantiate the Spear object at a speed that we set 
	/// if the Player object is not facing right then we flip the way that the Spear is being instantiated by the opposite of the facing right
	/// </summary>
	void Update ()
	{

		if(Input.GetButtonDown("Jump")&& Time.time > nextFire)
		{


			if(playerCtrl.facingRight)
			{
				nextFire = Time.time + fireRate;

				Rigidbody2D bulletInstance = Instantiate(spear, transform.position, Quaternion.Euler(new Vector3(0f,0,0f))) as Rigidbody2D;
				bulletInstance.velocity = new Vector2(speed, 0);
			}
			else
			{
				nextFire = Time.time + fireRate;

				Rigidbody2D bulletInstance = Instantiate(spear, transform.position, Quaternion.Euler(new Vector3(0f,0f,-180f))) as Rigidbody2D;
				bulletInstance.velocity = new Vector2(-speed, 0);
			}
		}
	}

}
