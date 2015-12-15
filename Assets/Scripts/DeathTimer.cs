using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DeathTimer : MonoBehaviour {
	Text txt;

	// Use this for initialization
	void Start () {
		txt = gameObject.GetComponent<Text> ();


		txt.text = "You died at time: ";
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
