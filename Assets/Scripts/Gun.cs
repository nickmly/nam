﻿using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour 
{
	public Vector2 velocity;
	public Transform arm;
	public Movement player;

	private float timer = 30f;
	private bool collided = false;
	public Vector3 tempScale;

	public int ammo;
	public int maxAmmo;

	public bool isAutomatic = false;
	public bool twoHanded = false;

	public Sprite sprite;
	public string gunType;
	public float fireRate;
	public float maxFireRate;

	void Start()
	{
		GetNewGun();
		tempScale = transform.localScale;
		arm = (Transform)GameObject.Find ("RightArm").GetComponent("Transform");
		player = (Movement)GameObject.Find ("Body").GetComponent("Movement");
	}

	public void Throw (bool isRight, float playerSpeed, Quaternion gunRot) 
	{

		if (ammo > 0) 
		{
			GameObject newGun = (GameObject)Instantiate (GameObject.Find (name));
			newGun.AddComponent ("BoxCollider2D");


			if (!isRight) 
			{
				newGun.transform.localScale = new Vector3 (-tempScale.x, -tempScale.y, tempScale.z);
			} 
			else 
			{
				newGun.transform.localScale = new Vector3 (-tempScale.x, tempScale.y, tempScale.z);
			}
			newGun.transform.rotation = gunRot;
			newGun.rigidbody2D.isKinematic = false;
			newGun.transform.position = transform.position;
			Vector3 sp = Camera.main.WorldToScreenPoint (newGun.transform.position); // get gun position in screen space (where the mouse is)
			Vector3 dir = (Input.mousePosition - sp).normalized; // the direction we want the gun to go is the mousePosition minus the gun position normalized
			if(Mathf.Abs(playerSpeed) < 5)
			{
				newGun.rigidbody2D.AddForce (dir * (velocity.x + playerSpeed));// throw the gun in the direction specified with a speed plus the player's current speed
			}
			else
			{
				newGun.rigidbody2D.AddForce (dir * (velocity.x * 1.5f + playerSpeed));// throw the gun in the direction specified with a speed plus the player's current speed
			}
			newGun.rigidbody2D.AddTorque(Random.Range(50,150)); //rotate the gun randomly
			ammo -= 1;
			renderer.enabled = false;
		}
	}
	void OnCollisionEnter2D(Collision2D col)
	{
		if(!collided)
		{
			rigidbody2D.drag = 20;
			collided = true;
		}
	}

	public void GetNewGun()
	{
		sprite = Resources.Load<Sprite> ("Weapons/Modern/" + gunType);
		gameObject.GetComponent<SpriteRenderer>().sprite = sprite;
		Vector3 scale;
		switch(gunType)
		{
			case "Pistol":
				scale = transform.localScale;
				scale.x = -0.07364167f;
				scale.y = 0.07363904f;
				transform.localScale = scale;
				isAutomatic = false;
				twoHanded = false;
				fireRate = 0.5f;
				ammo = 5;				
				break;
			case "AR":
				scale = transform.localScale;
				scale.x = -0.2712036f;
				scale.y = 0.2712047f;
				transform.localScale = scale;
				isAutomatic = true;
				twoHanded = true;
				fireRate = 0.2f;
				ammo = 20;
				break;
		}
		maxAmmo = ammo;
		maxFireRate = fireRate;
	}

	// Update is called once per frame
	void Update () 
	{

		if (Input.GetKeyDown (KeyCode.Alpha1))
		{
			gunType = "Pistol";
			GetNewGun();
		}
		if (Input.GetKeyDown (KeyCode.Alpha2))
		{
			gunType = "AR";
			GetNewGun();
		}
		if (Input.GetKeyDown (KeyCode.R)) 
		{
			ammo = maxAmmo;
			if(!renderer.enabled)
			{
				renderer.enabled = true;
			}
		}

		if (collided)
		{
			if(timer > 0f)
			{
				timer -= Time.deltaTime;
			}
			else
			{

				Destroy (gameObject);
			}
		}
	}
}
