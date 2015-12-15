using UnityEngine;
using System.Collections;

public class SwordController : MonoBehaviour {

	
	public Rigidbody2D sword;				
	public float speed;				
	public float fireRate;
	
	private CharController playerCtrl;		
	private float nextFire;
	private GameObject player;

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
