/// <summary>
/// Written by Jason Sullender
/// this class is used to instantiate the sword prefab on the player prefab
/// </summary>
using UnityEngine;
using System.Collections;

public class SwordController : MonoBehaviour {

	
	public Rigidbody2D sword;//sword rigidbody				
	public float speed;				//speed of sword
	public float fireRate;//rate at which sword is instantiated
	
	private CharController playerCtrl;//get the player code		
	private float nextFire;//time until next fire
	private GameObject player;//player game object

	/// <summary>
	/// We find the game object Player object
	/// We also get the charcontroller component and set it to the playerCtrl variable
	/// </summary>
	void Start()
	{

		player = GameObject.Find ("Player");
		playerCtrl = transform.root.GetComponent<CharController>();
	}
	
	/// <summary>
	/// If the x button is pressed and the time for the next fire is avalible then check which way the player is facing
	/// If the Player object is facing right then we instantiate the Spear object at a speed that we set 
	/// if the Player object is not facing right then we flip the way that the Spear is being instantiated by the opposite of the facing right
	/// </summary>
	void Update ()
	{
		
		if(Input.GetKeyDown(KeyCode.X)&& Time.time > nextFire)
		{
		
			if(playerCtrl.facingRight)
			{
				nextFire = Time.time + fireRate;
				
				Rigidbody2D bulletInstance = Instantiate(sword,transform.position, Quaternion.Euler(new Vector3(0f,0f,-180f))) as Rigidbody2D;
				bulletInstance.velocity = new Vector2(speed, 0);
			}
			else
			{
				nextFire = Time.time + fireRate;
				
				Rigidbody2D bulletInstance = Instantiate(sword, transform.position, Quaternion.Euler(new Vector3(0f,0f,360f))) as Rigidbody2D;
				bulletInstance.velocity = new Vector2(-speed, 0);
			}
		}
	}
}
