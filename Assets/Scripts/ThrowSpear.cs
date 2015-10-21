using UnityEngine;
using System.Collections;

public class ThrowSpear : MonoBehaviour {

	public Rigidbody2D spear;				// Prefab of the spear.
	public float speed;				// The speed the spearwill fire at.
	public float fireRate;
	
	private CharController playerCtrl;		// Reference to the PlayerControl script.
	private float nextFire;
	
	
	void Start()
	{
		// Setting up the references.

		playerCtrl = transform.root.GetComponent<CharController>();
	}
	
	
	void Update ()
	{
		// If the fire button is pressed which is space bar
		if(Input.GetButtonDown("Jump")&& Time.time > nextFire)
		{

			// If the player is facing right...
			if(playerCtrl.facingRight)
			{
				nextFire = Time.time + fireRate;
				// ... instantiate the spear facing right and set it's velocity to the right. 
				Rigidbody2D bulletInstance = Instantiate(spear, transform.position, Quaternion.Euler(new Vector3(0f,0,-90f))) as Rigidbody2D;
				bulletInstance.velocity = new Vector2(speed, 0);
			}
			else
			{
				nextFire = Time.time + fireRate;
				// Otherwise instantiate the spearfacing left and set it's velocity to the left.
				Rigidbody2D bulletInstance = Instantiate(spear, transform.position, Quaternion.Euler(new Vector3(0f,0f,90f))) as Rigidbody2D;
				bulletInstance.velocity = new Vector2(-speed, 0);
			}
		}
	}

}
