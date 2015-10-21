using UnityEngine;
using System.Collections;

public class Enemy2 : MonoBehaviour {
	public float moveSpeed;
	public bool moveRight;
	private Rigidbody2D rb;
	public Transform wallCheck;
	public float wallCheckRadius;
	public LayerMask whereIsWall;
	private bool onWall;
	private bool atEdge;
	public Transform edgeCheck;
	public int HP = 2;					

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		onWall = Physics2D.OverlapCircle (wallCheck.position, wallCheckRadius, whereIsWall);
		atEdge = Physics2D.OverlapCircle (edgeCheck.position, wallCheckRadius, whereIsWall);
		if (onWall || !atEdge) {
			moveRight = !moveRight;
	
		}
		if (moveRight) {
			transform.localScale = new Vector3 (-1f, 1f, 1f);
			rb.velocity = new Vector2 (moveSpeed, rb.velocity.y);


		} else {
			transform.localScale = new Vector3 (1f, 1f, 1f);
			rb.velocity = new Vector2 (-moveSpeed, rb.velocity.y);


		}
		// If the enemy has zero or fewer hit points and isn't dead yet...
		if (HP <= 0) {
			// ... call the death function.
			Destroy (gameObject);
	
		}
	}
	public void Hurt()
	{
		// Reduce the number of hit points by one.
		HP--;
		print ("Enemy hit");
	}
	void OnTriggerEnter2D (Collider2D col) 
	{
		// If it hits an enemy...
		if (col.tag == "Spear") {
			// ... find the Enemy script and call the Hurt function.
			
			Hurt ();

		}
	}

}
