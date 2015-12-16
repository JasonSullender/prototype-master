/// <summary>
/// Written by Jason Sullender
/// this is attached to the freeze cone prefab to detroy the prefab after 1 second
/// </summary>
using UnityEngine;
using System.Collections;

public class DestroyFreeze : MonoBehaviour {

/// <summary>
/// Destory prefab after 1 second

	void Start () {
		Destroy (gameObject, 1f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
