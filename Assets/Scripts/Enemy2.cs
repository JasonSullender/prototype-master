/// <summary>
/// Written by Jason Sullender
/// This class is attached to the minotaur prefab to control the enemy
/// </summary>
using UnityEngine;
using System.Collections;

public class Enemy2 : MonoBehaviour {
	public float moveSpeed;//speed of the enemy can be changed in scene
	public bool moveRight;//Checks if enemy is moving right
	private Rigidbody2D rb;//rigid body of the enemy
	public Transform wallCheck;//checks if the enemy is against wall
	public float wallCheckRadius;//radius to check the wall
	public LayerMask whereIsWall;//check where the wall is 
	private bool onWall;//checks if enemy is colliding with the wall
	private bool atEdge;//checks if enemy is on the edge of a platform
	public Transform edgeCheck;//checks where the edge of platform is
	public int HP = 2;//sets the enemy health to two					
	private GameObject gameController;
	private bool playerCharge;//Checks if player is in the player charge area
	public LayerMask whereIsPlayer;//checks where the player is
	public float playerCheckRadius;//checks within radius of the object
	public Transform playerCheck;//checks if player is within radius
	private bool onEnemy;//checks if the player is colliding with another enemy
	public Transform enemyCheck;//checks if there is an enemy
	public float enemyCheckRadius;//radius where the enemy checks for another enemy
	public LayerMask whereIsEnemy;//checks where the enemy is 
	private Animator minotaurAnim;//minotaur walking animation
	private AudioSource source;//audio source of minotaur
	public AudioClip moo;//charge sound of minotaur
	/// <summary>
	/// We get the Enemy object rigidbody component
	/// </summary>
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		//gameController = GetComponent<CharController> ();
		minotaurAnim = GetComponent<Animator> ();
		source = GetComponent<AudioSource> ();
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
	

		if (playerCharge)
		{
			moveSpeed=3;
			source.PlayOneShot(moo,.17f);
			minotaurAnim.SetFloat("charge",moveSpeed);
			print ("Move faster");
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
