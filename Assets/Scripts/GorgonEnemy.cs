/// <summary>
/// Written by Jason Sullender
/// THis is attached to the gorgon prefab runs like the Enemy2 class
/// </summary>
using UnityEngine;
using System.Collections;

public class GorgonEnemy : MonoBehaviour {
	public float moveSpeed;//move speed of gorgon
	public bool moveRight;//checks if gorgon facing right
	private Rigidbody2D rb;//gets rigidbody of the gorgon
	public Transform wallCheck;//checks if the gorgon is against wall
	public float wallCheckRadius;//radius to check for wall
	public LayerMask whereIsWall;//checks if wall is in radius
	private bool onWall;//checks if the gorgon is colliding with wall
	private bool atEdge;//checks if the gorgon is colliding with edge of platform
	public Transform edgeCheck;//checks where edge of platform is 
	public int HP = 2;		//sets the health of the gorgon			
	private GameObject gameController;
	private bool playerCharge;//checks if player collides with player charge object
	public LayerMask whereIsPlayer;//Checks if player is colliding
	public float playerCheckRadius;//the radius to check for player
	public Transform playerCheck;//checks if player is in radius
	private bool onEnemy;//checks if colliding with another enemy
	public Transform enemyCheck;//checks if it is an enemy
	public float enemyCheckRadius;//radius to check for enemy
	public LayerMask whereIsEnemy;//checks if enemy is in radius
	
	/// <summary>
	/// We get the Enemy object rigidbody component
	/// </summary>
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		//gameController = GetComponent<CharController> ();
		
	}
	
	/// <summary>
	/// The onWall object checks mulitple things for the wall object this is the same for the edge checker object and the player check object
	/// If the Player object is in the Player Check area then the Enemy object will move faster by 3.
	/// If the onwall or the edge checker objects are in the area we then toggle the move right variable. if we are moving right
	/// then the rigidbody moves at a velocity and speed that we set.
	/// If we are not moving right then we do the same as moving right but flipped by a negative
	/// We also check to see the health status of the Enemy object if we are zero or lower then we destroy the Enemy object.
	/// </summary>
	void Update () {
		onWall = Physics2D.OverlapCircle (wallCheck.position, wallCheckRadius, whereIsWall);
		atEdge = Physics2D.OverlapCircle (edgeCheck.position, wallCheckRadius, whereIsWall);
		playerCharge = Physics2D.OverlapCircle (playerCheck.position, playerCheckRadius, whereIsPlayer);
		onEnemy = Physics2D.OverlapCircle (enemyCheck.position, enemyCheckRadius, whereIsEnemy);
		
		
		if (playerCharge) {
			moveSpeed = 1;

		} 
		else 
		{
			moveSpeed=1;
		}
		
		if (onWall || !atEdge||onEnemy) {
			moveRight = !moveRight;
			
		}
		if (moveRight) {
			transform.localScale = new Vector3 (-1f, 1f, 1f);
			rb.velocity = new Vector2 (moveSpeed, rb.velocity.y);
			
			
		} else 
		{
			transform.localScale = new Vector3 (1f, 1f, 1f);
			rb.velocity = new Vector2 (-moveSpeed, rb.velocity.y);
			
		}
		
		// If the enemy has zero or fewer hit points and isn't dead yet...
		if (HP <= 0) {
			// ... call the death function.
			Destroy (gameObject);
			
		}
		
	}
	/// <summary>
	/// This function reduces the set hp of the Enemy object by one when hit and print to make sure the function is called
	/// </summary>
	public void Hurt()
	{
		// Reduce the number of hit points by one.
		HP--;
		print ("Enemy hit");
	}
	/// <summary>
	/// When the trigger of the Enemy object is collided with the spear object then we call the hurt function
	/// </summary>
	/// <param name="col">Col.</param>
	void OnTriggerEnter2D (Collider2D col) 
	{
		
		if (col.tag == "Spear"){
			Hurt ();
			
		}
		
		
		
	}
}
