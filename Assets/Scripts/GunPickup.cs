using UnityEngine;
using System.Collections;

public class GunPickup : MonoBehaviour {

	public string wType;
	public Gun gun;
	public HUD hud;
	private double timeLeft = 5;
	void Start () 
	{
		Vector3 scale;
		switch(wType)
		{
			
			case "Pistol":
			scale = transform.localScale;
			scale.x = -0.07364167f;
			scale.y = 0.07363904f;
			transform.localScale = scale;	
			//				Pistol.enabled = true;
			//				AR.enabled = false;
			//				RubberDuck.enabled = false;
			break;
			case "AR":
			scale = transform.localScale;
			scale.x = -0.2712036f;
			scale.y = 0.2712047f;
			transform.localScale = scale;
			//				AR.enabled = true;
			//				Pistol.enabled = false;
			//				RubberDuck.enabled = false;
			break;
			case "RubberDuck":
			scale = transform.localScale;
			scale.x = -0.2306246f;
			scale.y = 0.2245191f;
			transform.localScale = scale;
			//				AR.enabled = true;
			//				Pistol.enabled = false;
			//				RubberDuck.enabled = false;
			break;
			case "SawedOffShot":
			scale = transform.localScale;
			scale.x = 0.05649794f;
			scale.y = 0.07662619f;
			transform.localScale = scale;
			//				AR.enabled = true;
			//				Pistol.enabled = false;
			//				RubberDuck.enabled = false;
			break;
			case "Revolver":
			scale = transform.localScale;
			scale.x = -0.08208004f;
			scale.y = 0.06501424f;
			transform.localScale = scale;
			//				AR.enabled = true;
			//				Pistol.enabled = false;
			//				RubberDuck.enabled = false;
			break;
			case "LMG":
			scale = transform.localScale;
			scale.x = 0.1900526f;
			scale.y = 0.1900525f;
			transform.localScale = scale;
			//				AR.enabled = true;
			//				Pistol.enabled = false;
			//				RubberDuck.enabled = false;
			break;
			case "Winchester":
			scale = transform.localScale;
			scale.x = 0.1022699f;
			scale.y = 0.1022698f;
			transform.localScale = scale;
			//				AR.enabled = true;
			//				Pistol.enabled = false;
			//				RubberDuck.enabled = false;
			break;
		}
	}

	void Update () 
	{
		if(timeLeft > 0)
		{
			timeLeft -= Time.deltaTime;
		}
		else
		{
			hud.pickupText.enabled = false;	
			Destroy(gameObject);
		}
	}

	void OnTriggerStay2D (Collider2D col)
	{			
	 
		if(col.gameObject.layer == 10)	
		{			
			hud.pickupText.text = "Press E to pickup " + wType;
			hud.pickupText.enabled = true;	
			if(Input.GetKeyDown(KeyCode.E))
			{
				hud.pickupText.enabled = false;	
				gun.gunType = wType; 
				gun.GetNewGun ();
				Destroy(gameObject);
			}	
		}
	}
	
	void OnTriggerExit2D(Collider2D col)
	{
		//hud.pickupText.text = "Press E to pickup " + wType;
		hud.pickupText.enabled = false;	
	}
}
