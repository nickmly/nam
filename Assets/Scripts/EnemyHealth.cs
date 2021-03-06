﻿using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour
{
	public Transform enemyclone;
	public int health;
	public Transform player;
	public Vector2 speed;
	public float speedX;
	Animator anim;
	public float deathTimer = 5f;
	public bool dead;

	public float DeltaDistance;
	private float AttackingDistance = 1.0f;

	public Animator EnemyBodyAnim;

	public bool isStill;
	public GameObject Weapon;
	
	public int scoreValue = 50;
	public HUD hudd;

	public bool paused = false;
	private int willPickupSpawn;

	// Use this for initialization
	void Start ()
	{
		isStill = false;
		health = 100;
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		enemyclone = GameObject.FindGameObjectWithTag("Enemy").transform;
		dead = false;
		speedX = Random.Range(10,20);
		EnemyBodyAnim = (Animator)GameObject.Find("/EnemyBody/EnemyBodyHolder").GetComponent("Animator");
		Weapon = (GameObject)GameObject.Find ("/EnemyBody/EnemyBodyHolder/EnemyArms/Right Arm/Right Wrist/Right Hand/Club");
		Weapon.tag = "Enemy Weapon";
		
	}
	void OnPauseGame()
	{
		paused = true;
		rigidbody2D.isKinematic = true;
	}
	void OnResumeGame()
	{
		paused = false;
		rigidbody2D.isKinematic = false;
	}	
	
	// Update is called once per frame
	void Update ()
	{
		if(!paused)
		{
			
			EnemyBodyAnim.SetBool("isStill",isStill);
		
			DeltaDistance = Mathf.Abs (player.rigidbody2D.position.x) - Mathf.Abs(this.rigidbody2D.position.x);
			
			if(dead == true)
			{
		
			}
			speed.x = speedX;
			
			if (player.position.x > rigidbody2D.position.x + 1) 
			{
				speed.x *= 1;					
			}
			
			if (player.position.x < rigidbody2D.position.x - 1f) 
			{
				speed.x *= -1;		
			}
			
			if ((Mathf.Abs (DeltaDistance)) < AttackingDistance) 
			{
				this.speed.x *= 0;
				isStill = true;
			}
			else
			{
				isStill = false;
			}
	
	
			
			rigidbody2D.AddForce (speed);
			GameObject exp = GameObject.Find ("Explosion");
			float dist = Vector3.Distance(transform.position,exp.transform.position);
			if(dist < 8 && exp.particleSystem.isPlaying && health > 0)
			{
				health = 0;	
				GameObject.Find("GunPrefab").GetComponent<Gun>().hudd.AddScore(50);
			}
			Vector3 scale;
			if (!dead) 
			{
				if (player.position.x < transform.position.x) 
				{
					scale = transform.localScale;
					scale.x = 0.3289828f;
					transform.localScale = scale;		
					
				} 
				else if (player.position.x > transform.position.x) 
				{
					scale = transform.localScale;
					scale.x = -0.3289828f;
					transform.localScale = scale;	   
				}   
			}
			
			if (health <= 0) 
			{
				speedX = 0;			
				dead = true; 
	
			
			
					
				
				if (deathTimer > 0) 
				{
					deathTimer -= Time.deltaTime;
					
				} 
				else 
				{
					willPickupSpawn = Random.Range(0,6);
					if(willPickupSpawn == 1)
					{
						GameObject newPickup;
						newPickup = (GameObject)Instantiate((Object)Resources.Load ("PickupPrefab"));		
						newPickup.transform.position = transform.position;
						int rand = Random.Range(1,hudd.enemyspawn.EnemyWave);
						switch(rand)
						{
							case 1:
								newPickup.GetComponent<GunPickup>().wType = "Pistol";
								break;
							case 2:
								newPickup.GetComponent<GunPickup>().wType = "SawedOffShot";
								break;
							case 3:
								newPickup.GetComponent<GunPickup>().wType = "AR";
								break;
							case 4:
								newPickup.GetComponent<GunPickup>().wType = "LMG";
								break;
							case 5:
								newPickup.GetComponent<GunPickup>().wType = "Winchester";
								break;
							case 6:
								newPickup.GetComponent<GunPickup>().wType = "Revolver";
								break;
							case 7:
								int duckChoose = Random.Range(0,4);							
								if(duckChoose == 1)
								{
									newPickup.GetComponent<GunPickup>().wType = "RubberDuck";
								}
								break;
							default:
								
								break;
						}
						newPickup.GetComponent<GunPickup>().gun = GameObject.Find ("GunPrefab").GetComponent<Gun>();
						newPickup.GetComponent<GunPickup>().hud = GameObject.Find ("gameMaster").GetComponent<HUD>();
						Sprite pSprite = Resources.Load<Sprite> ("Weapons/" + newPickup.GetComponent<GunPickup>().wType);
						newPickup.GetComponent<SpriteRenderer>().sprite = pSprite;
						
					}
					Destroy (gameObject);
					
				}	
			}
		}	
	}

}
