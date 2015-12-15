using UnityEngine;
using System.Collections;

public class Chest : MonoBehaviour {

	

		public int health;
		
		public Collider2D armor;
		public Collider2D helmet;
		public bool playerCtrlHelm;
		public bool playerCtrlArmor;
		// Use this for initialization
		void Start () {
			//  playerCtrlHelm = GetComponent<CharController> ().hasHelm;
			//  playerCtrlArmor = GetComponent<CharController> ().hasArmor;
		}
		
		// Update is called once per frame
		void Update () {
			
		}
		void OnTriggerEnter2D (Collider2D col) 
		{
			// If it hits an enemy...
			if(col.tag == "Spear")
			{
				Hurt();
			}
			
			
		}
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

