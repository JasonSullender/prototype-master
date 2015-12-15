using UnityEngine;
using System.Collections;

public class CharController : MonoBehaviour {

	private Rigidbody2D rb;
	public float moveSpeed;
	//private float maxSpeed=5f;
	private Vector2 input;
	public float jumpHeight;
	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask whereIsGround;
	private bool onGround;
	private bool jumpTwice;
	[HideInInspector]
	public bool facingRight = true;	
	BoxCollider2D box;
	public GameObject spear;
	public Transform spearSpawn;
	public float fireRate;
	private float nextFire;
	public float bulletDelay = .25f;
	float timeUntilNextBullet=0;
	public GameObject prefabSwordSwing;
	public bool hasHelm=false;
	public bool hasArmor=false;
	public int health;
	private Animator myAnim;
	private bool iswalking=false;
	private float slash=0;
	public bool frozen=false;
	private float jump=0;
	/// <summary>
	/// We get the rigidbody and the boxcollider of the Player object
	/// </summary>
	void Start ()
	{

		rb = GetComponent<Rigidbody2D> ();
		box = GetComponent<BoxCollider2D> ();
		myAnim = GetComponent<Animator> ();
	}
	/// <summary>
	/// We use the ground object checker to see if the ground object is touching the ground
	/// </summary>
	void FixedUpdate()
	{
		onGround = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, whereIsGround);
	}
	/// <summary>
	/// The update first checks if we are pressing the X button after this we need to check if the time for the next bullet is ready we 
	/// set this variable. If the player object is facing right then we call the RayCastShotRight function. if we are no facing right then
	/// we call the RayCastShotLeft function. then we call the primary attack function. the time that we check for the the bullet to fire is 
	/// set by us. 
	/// 
	/// If we are on the ground then we make the jumptwice to false
	/// if we press the W key we call the Jump function
	/// If we press the W key and the Player object has not jumped twice and the Player object is not on the ground then we call the jump function
	/// and we set the jumptwice to true
	/// 
	/// If the D key is pressed down we then put a moveSpeed variable that we set to a vector and multiply this by delta time so that we can portray a more real world scenario. If we are not facing
	/// right we then call the Flip function. We do this with the A key to go to the left of the scene.
	/// 
	/// When the S key is pressed down then the Player object rigidbody is set to be smaller and the Player object cannot move we are crouching
	/// 
	/// </summary>
	void Update () 
	{
		moveSpeed = 0;

//		input=new Vector3(Input.GetAxis ("Horizontal"),Input.GetAxis ("Jump"),0.0f);
//		if (rb.velocity.magnitude < maxSpeed) 
//		{
//			rb.AddForce (input*moveSpeed);
//		}
		if (Input.GetKeyDown(KeyCode.X)) {
			slash=1;
			if (timeUntilNextBullet <= 0) {
				if(facingRight)
				{
					RayCastShotRight ();
				}
				if(!facingRight)
				{
					RayCastShotLeft();
				}
				myAnim.SetFloat("slash",slash);
				PrimaryAttack ();
				timeUntilNextBullet = bulletDelay;
			} else {
				timeUntilNextBullet -= Time.deltaTime;
			}
		} else {
			timeUntilNextBullet = 0;
		}
		if (Input.GetKeyUp (KeyCode.X))
		{
			slash=0;
			myAnim.SetFloat("slash",slash);
		}
		
	

		if (onGround)
		{
			jump=0;
			jumpTwice=false;
			myAnim.SetFloat("jump",jump);
		}
		if (Input.GetKeyDown (KeyCode.W)&&onGround) 
		{
			Jump ();
		}
		if (Input.GetKeyDown (KeyCode.W)&&!jumpTwice&&!onGround) 
		{
			Jump ();
			jumpTwice=true;

		}
		if (Input.GetKey (KeyCode.D)&&frozen==false)
		{
		

			moveSpeed=1;
			rb.velocity = new Vector2 (moveSpeed, rb.velocity.y);

			myAnim.SetFloat("speed",moveSpeed);

			if (!facingRight)
			{
				Flip ();
			}

		}
		if(Input.GetKeyUp (KeyCode.D))
		{
			moveSpeed=0;
			myAnim.SetFloat("speed",moveSpeed);
		}

	
		if (Input.GetKey (KeyCode.A)&&frozen==false) 
		{
		
			moveSpeed=1;
			rb.velocity = new Vector2 (-moveSpeed, rb.velocity.y);

			myAnim.SetFloat ("speed",Mathf.Abs (moveSpeed));

			if (facingRight)
			{
				Flip ();
			}
			}


		if(Input.GetKeyUp (KeyCode.A))
		{
			moveSpeed=0;
			myAnim.SetFloat("speed",moveSpeed);
		}
	
		if (Input.GetKey (KeyCode.S)&&onGround) {
			box.size = new Vector2 (.1f, .1f);
			rb.velocity=new Vector2(0,0);


		} else {
			box.size=new Vector2(.5f,.5f);
		
		}


		
	}

	/// <summary>
	/// This fuction puts the rigidbody velocity to a vector that goes up in the x direction by a jumpheight variable that we set
	/// </summary>
	public void Jump()
	{
		jump = 1;
		myAnim.SetFloat ("jump", jump);
		rb.velocity=new Vector2(rb.velocity.x,jumpHeight);
	}
	/// <summary>
	///  The Flip function is used for making sure that the Player object is facing the way that the player object is moving 
	/// We start by toggling the facingright variable. After this we then multiply the player scale by -1 so that the Player object is facing
	///    the correct way.
	/// </summary>
	void Flip ()
	{
		// Switch the way the player is labelled as facing.
		facingRight = !facingRight;
		
		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
	/// <summary>
	/// The Collision function checks to see if the Enemy object touches the collision of the Player object if this is the case then
	/// we destory the Player object and we reload the level that we were playing
	/// </summary>
	/// <param name="col">Col.</param>
	void OnCollisionEnter2D (Collision2D col) 
	{ 

		print ("detected collision between" + gameObject.name + "and" + col.collider.name);
		if (col.collider.name == "Enemy"||col.collider.name=="Gorgon") {
			PlayerHurt();
		}

	}
	/// <summary>
	/// We set a ray called rayshot to a new ray that is set to the player position and facing to the right
	/// we draw the ray to test the ray function
	/// we set a raycast hit to a hit variable and if the raycast is shot and hits something then we check if
	/// the hit raycast hits Enemy object if this happens then we call the hurt function in the Enemy2.cs class
	/// </summary>
	void RayCastShotRight ()
	{
		Ray rayShot = new Ray (transform.position, transform.right);


		Debug.DrawRay (rayShot.origin, rayShot.direction * 1, Color.black, 1F);
		RaycastHit hit;
		if (Physics.Raycast (rayShot, out hit)) 
		{
			if(hit.rigidbody.gameObject.tag==("Enemy"))

			{
				print ("going to hurt");
				gameObject.GetComponent<Enemy2> ().Hurt();
			}
		
			}

	}
	/// <summary>
	/// We set a ray called rayshot to a new ray that is set to the player position and facing to the left
	/// we draw the ray to test the ray function
	/// we set a raycast hit to a hit variable and if the raycast is shot and hits something then we check if
	/// the hit raycast hits Enemy object if this happens then we call the hurt function in the Enemy2.cs class
	/// </summary>
	void RayCastShotLeft()
	{
		Ray rayShot = new Ray (transform.position, -transform.right);


		Debug.DrawRay (rayShot.origin, rayShot.direction * 1, Color.black, 1F);
		RaycastHit hit;
	
	}
	/// <summary>
	/// Used to instatiate the sword swing animation to the player object position 
	/// </summary>
	void PrimaryAttack ()
	

		 {
			Instantiate (prefabSwordSwing,transform.position, Quaternion.identity);
			

		}
		/// <summary>
		/// If the Fireball tag hits the Player object then destroy the player object and reload the level that was playing
		/// </summary>
		/// <param name="col">Col.</param>

	void OnTriggerEnter2D(Collider2D col)
		{
		if (col.tag == "FireBall")
		{
			PlayerHurt();
		}
		if (col.tag == "Helmet") {
			// ... find the Enemy script and call the Hurt function.
			
			health++;
			hasHelm=true;
			
			
		}
		if (col.tag == "Armor")
		{
			health++;
			hasArmor=true;
		}
		if (col.tag == "Freeze")
		{

			frozen=true;
			moveSpeed=0f;
			jumpHeight=0f;
			StartCoroutine(BackToNormal());

		}
	
		}
	IEnumerator BackToNormal() {

		yield return new WaitForSeconds(2);
		frozen = false;
		moveSpeed = 1f;
		jumpHeight = 3f;

	}

	
	public void PlayerHurt()
	{
		// Reduce the number of hit points by one.
		health--;
		if (health == 2)
		{
			hasArmor=false;
		}
		if (health == 1)
		{
			hasHelm=false;
		}
		if (health <= 0) 
		{
			Destroy (gameObject);
			Application.LoadLevel("DeathScreen");
		}
		print ("Enemy hit");
	}


}
