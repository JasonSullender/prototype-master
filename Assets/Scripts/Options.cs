using UnityEngine;
using System.Collections;

public class Options : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	

	}
	/// <summary>
	/// The back button loads the Main Menu scene
	/// </summary>
	public void Back()
	{
		Application.LoadLevel ("Main Menu");
	}
}
