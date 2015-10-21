using UnityEngine;
using System.Collections;

public class OtherCharControl : MonoBehaviour {
	
	BoxCollider2D box;
	Vector2 velocity = new Vector2();
	public LayerMask mask;
	bool hitAbove;
	bool hitBelow;
	bool hitRight;
	bool hitLeft;
	[HideInInspector]
	public bool facingRight = true;
	float skin = .02f;
	
	float gravity;
	float jumpSpeed;
	float jumpHeight = 3f;
	float jumpTimeToApex = .4F;
	
	
	float moveSpeed = 100;
	
	
	// Use this for initialization
	void Start () {
		box = GetComponent<BoxCollider2D> ();
		// h = g * t * t / 2
		gravity = jumpHeight * 2 / (jumpTimeToApex * jumpTimeToApex);
		jumpSpeed = gravity * jumpTimeToApex;
		gravity = -gravity;
		
		
	}
	
	// Update is called once per frame
	void Update () {
		
		//adjust velocity
		if (hitBelow || hitAbove)
			velocity.y = 0;
		if (hitRight || hitLeft)
			velocity.x = 0;

	
		float h = Input.GetAxis("Horizontal");
		velocity.x = h * moveSpeed * Time.deltaTime;
		
		if (Input.GetButtonDown ("Jump")) {
			velocity.y = jumpSpeed;
			
		}
	
		// If the input is moving the player right and the player is facing left...
		if(h > 0 && !facingRight)
			// ... flip the player.
			Flip();
		// Otherwise if the input is moving the player left and the player is facing right...
		else if(h < 0 && facingRight)
			// ... flip the player.
			Flip();

		
		
		velocity.y += gravity * Time.deltaTime;
		
		
		// call move
		
		Move (velocity * Time.deltaTime);
		
		
	}
	
	void Move(Vector2 v){
		// detect collisions
		// move
		
		hitAbove = false;
		hitBelow = false;
		hitRight = false;
		hitLeft = false;
		
		
		if (v.y < 0)
			RaycastDown (ref v);
		if (v.x > 0)
			RaycastLeft (ref v);
		if (v.x < 0)
			RaycastRight (ref v);
		
		transform.Translate (v);
		
		
		
	}
	
	void RaycastDown(ref Vector2 v ){
		
		Bounds b = box.bounds;
		b.Expand (skin * -2);
		
		Vector2 p1 = new Vector2 (b.min.x, b.min.y);
		Vector2 p2 = new Vector2 (b.center.x, b.center.y);
		Vector3 p3 = new Vector2 (b.max.x, b.max.y);
		
		Vector2[] origins = {p1, p2, p3};
		
		float dis = RaycastMultiple (origins, Vector2.down, skin-v.y);
		if (dis > 0) {
			// hit ground!
			v.y  = skin-dis;
			hitBelow = true;
			
		}
		
	}
	
	void RaycastLeft(ref Vector2 v ){
		
		Bounds b = box.bounds;
		b.Expand (skin * -2);
		
		Vector2 p1 = new Vector2 (b.min.x, b.max.y);
		Vector2 p2 = new Vector2 (b.min.x, b.center.y);
		Vector3 p3 = new Vector2 (b.min.x, b.min.y);
		
		Vector2[] origins = {p1, p2, p3};
		
		float dis = RaycastMultiple (origins, Vector2.left, skin-v.x);
		if (dis > 0) {
			// hit left
			v.x  = skin-dis;
			hitLeft = true;
			
		}
		
	}
	
	void RaycastRight(ref Vector2 v ){
		
		Bounds b = box.bounds;
		b.Expand (skin * -2);
		
		Vector2 p1 = new Vector2 (b.max.x, b.max.y);
		Vector2 p2 = new Vector2 (b.max.x, b.center.y);
		Vector3 p3 = new Vector2 (b.max.x, b.min.y);
		
		Vector2[] origins = {p1, p2, p3};
		
		float dis = RaycastMultiple (origins, Vector2.right, skin+v.x);
		if (dis > 0) {
			// hit ground!
			v.x  = dis-skin;
			hitRight = true;
			
		}
		
	}
	
	
	
	
	float RaycastMultiple(Vector2[] origins, Vector2 dir, float length){
		float dis = float.MaxValue;
		bool success = false;
		
		foreach (Vector2 pt in origins) {
			RaycastHit2D hit = Physics2D.Raycast(pt, dir, length, mask);
			Debug.DrawRay(pt, dir * length, Color.white);
			if(hit){
				if(hit.distance < dis){
					success = true;
					dis = hit.distance;
				}
			}
		}
		
		return success ?  dis: -1;
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
}
