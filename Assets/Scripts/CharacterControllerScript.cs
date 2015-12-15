using UnityEngine;
using System.Collections;

public class CharacterControllerScript : MonoBehaviour {
	private CharacterController inputController;
	public bool isGrounded=true;
	public float gravity;
	private float fallSpeed;
	public float jumpSpeed;
	public float moveSpeed;
	public bool facingRight = true;	

	/// <summary>
	/// We set the CharacterController variable to the component charactercontroller on the Player object.
	/// </summary>
	void Start () {
		inputController = GetComponent<CharacterController> ();

	}
	
	/// <summary>
	/// Each frame we check if we are doing a function.
	/// </summary>
	void Update () {
		IsGrounded();
		Fall ();
		Jump ();
		Move ();
	}
	/// <summary>
	/// The Jump function allows the Player object in the scene to leave the ground in the scene. We first check to see if the W key is pressed
	/// if this and the Player object is on the ground that is tagged ground then we are able to jump off of the ground.
	/// </summary>
	public void Jump()
	{
		if (Input.GetKeyDown (KeyCode.W) && isGrounded)
		{
			fallSpeed=-jumpSpeed;
		}
	}
	/// <summary>
	/// The Move function allows the Player object to move left or right in the scene. If the D key is pressed down we then put a moveSpeed
	/// variable that we set to a vector and multiply this by delta time so that we can portray a more real world scenario. If we are not facing
	/// right we then call the Flip function. We do this with the A key to go to the left of the scene.
	/// </summary>
	public void Move()
	{
		if(Input.GetKey (KeyCode.D))
		{
			inputController.Move(new Vector2(moveSpeed,0)*moveSpeed*Time.deltaTime);
			if(!facingRight)
			{
			Flip ();
			}
		}
		if (Input.GetKey (KeyCode.A)) {
			inputController.Move( new Vector2 (-moveSpeed,0)*moveSpeed*Time.deltaTime);
			if(facingRight)
			{
			Flip ();
			}
		}
	}
	/// <summary>
	/// This function is called so that when we jump off of the ground that we are able to fall back to the ground
	/// first we check if we are not grounded so this means that we are jumping so our fall speed is the gravity speed we set times delta time
	/// if we are not jumping then we do not have to fall. 
	/// </summary>
	public void Fall ()
	{
		if (!isGrounded) {
			fallSpeed += gravity * Time.deltaTime;
		}
		else 
		{
			if(fallSpeed>0)fallSpeed=0;
		}

		inputController.Move (new Vector2(0, -fallSpeed) * Time.deltaTime);
	}
	/// <summary>
	/// This function checks to see if the Player object is on the ground to do this we cast a ray to see if it is hitting the ground
	/// if we are then grounded is ture otherwise it is false 
	/// </summary>
	/// <returns><c>true</c> if this instance is grounded; otherwise, <c>false</c>.</returns>
	public void IsGrounded()
	{
		if (Physics.Raycast (transform.position, -transform.up, inputController.height/1.53f)) {
			isGrounded = true;
		} 
		else 
		{
			isGrounded=false;
		}
	}
	/// <summary>
	/// The Flip function is used for making sure that the Player object is facing the way that the player object is moving 
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
	/// This fuction will destroy the Player object if the enemy object hits the player object and then starts the loaded scene over.
	/// </summary>
	/// <param name="col">Col.</param>
	void OnTriggerEnter (Collider col) 
	{
		print ("detected collision between" + gameObject.name + "and" + col.GetComponent<Collider>().name);
		if (col.GetComponent<Collider>().name == "Enemy") {
			Destroy (gameObject);
			StartCoroutine ("ReloadLevel");
		}
	}

}
