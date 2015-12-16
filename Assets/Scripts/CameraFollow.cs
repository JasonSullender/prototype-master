/// <summary>
/// Written by Jason Sullender
/// The CameraFollow class is the class that because the camera is a child of the Player object that the camera is able 
/// to follow the Player object when the Player object is moving.
/// </summary>
using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public GameObject player;
	private Vector3 offset;

	
	/// <summary>
	/// This finds the position of the Main Camera object compared to the Player object. 
	/// </summary>
	void Start () 
	{
		offset = transform.position - player.transform.position;
		
	}
	
	/// <summary>
	/// Updating every frame is that we first have to check and see if the Player object is still there because the Player object
	/// can be destroyed. So if the Player object is not destroyed then the Main Camera object will take the Player object position
	/// plus the offset that we calculated at the start of the scene.
	/// </summary>
	void LateUpdate () 
	{
		if (player != null) {
			transform.position = player.transform.position + offset;
		}
		
	}
}
