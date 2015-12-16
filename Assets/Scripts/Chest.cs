/// <summary>
/// Written by Jason Sullender
/// This class is attached to the chest prefab 
/// this class is used to check whether the player has an armor or helmet prefab on to change
/// player health
/// </summary>
using UnityEngine;
using System.Collections;

public class Chest : MonoBehaviour {

	

		public int health;//health for chest
		
		public Collider2D armor;//armor prefab collider
		public Collider2D helmet;//helmet prefab collider
		public bool playerCtrlHelm;//checks if player has helmet
		public bool playerCtrlArmor;//checks if player has armor
		// Use this for initialization
		void Start () {
			//  playerCtrlHelm = GetComponent<CharController> ().hasHelm;
			//  playerCtrlArmor = GetComponent<CharController> ().hasArmor;
		}
		
		// Update is called once per frame
		void Update () {
			
		}
	/// <summary>
	/// when the tag of spear collides with the chest call hurt function
	/// </summary>
	/// <param name="col">Col.</param>
		void OnTriggerEnter2D (Collider2D col) 
		{
			// If it hits an enemy...
			if(col.tag == "Spear")
			{
				Hurt();
			}
			
			
		}
	/// <summary>
	/// decrements the chest health then destroys the chest prefab
	/// after destroyed instantiate the prefab that the player doesn't have yet
	/// </summary>
		public void Hurt()
		{
			
			health--;
			print (health);
			if (health <= 0) 
			{
				Destroy (gameObject);
				
				if(GameObject.Find ("Player").GetComponent <CharController>().hasHelm==false)
				{
					print ("Now have Helm");
					Collider2D helmInstance =Instantiate(helmet, transform.position, Quaternion.identity)as Collider2D;
					
				}
			if(GameObject.Find("Player").GetComponent<CharController>().hasArmor==false&&GameObject.Find ("Player").GetComponent <CharController>().hasHelm==true)
				{
					Collider2D ArmorInstance =Instantiate(armor, transform.position, Quaternion.identity)as Collider2D;
				}
			}
			
			
		}
	}

