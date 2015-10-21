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

	// Use this for initialization
	void Start ()
	{
		rb = GetComponent<Rigidbody2D> ();
		box = GetComponent<BoxCollider2D> ();
	}
	void FixedUpdate()
	{
		onGround = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, whereIsGround);
	}
	// Update is called once per frame
	void Update () 
	{

//		input=new Vector3(Input.GetAxis ("Horizontal"),Input.GetAxis ("Jump"),0.0f);
//		if (rb.velocity.magnitude < maxSpeed) 
//		{
//			rb.AddForce (input*moveSpeed);
//		}


		if (onGround)
		{
			jumpTwice=false;
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
		if (Input.GetKey (KeyCode.D)) 
		{
			rb.velocity=new Vector2(moveSpeed,rb.velocity.y);
			if(!facingRight)
				Flip();
		}
	
		if (Input.GetKey (KeyCode.A)) {
			rb.velocity = new Vector2 (-moveSpeed, rb.velocity.y);
			if (facingRight)
				Flip ();
		}
		if (Input.GetKey (KeyCode.S)&&onGround) {
			box.size = new Vector2 (.1f, .1f);
			rb.velocity=new Vector2(0,0);


		} else {
			box.size=new Vector2(.5f,.5f);
		
		}
			
		
	}
	public void Jump()
	{
		rb.velocity=new Vector2(rb.velocity.x,jumpHeight);
	}
	void Flip ()
	{
		// Switch the way the player is labelled as facing.
		facingRight = !facingRight;
		
		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
	void OnCollisionEnter2D (Collision2D col) 
	{ 
		print ("detected collision between" + gameObject.name + "and" + col.collider.name);
		if (col.collider.name == "Enemy") {
			Destroy (gameObject);
			StartCoroutine ("ReloadLevel");
		}
	}
//	void OnTriggerEnter2D(Collider2D col)
//		{
//			// If the player hits the trigger...
//			if (col.gameObject.tag == "Slant") 
//			{
//			transform.Rotate(0f,0f,315f,Space.World);
//				
//			}
//		}


}
