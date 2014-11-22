using UnityEngine;
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
	

	public int playerdamage;

	public Sprite sprite;
	public string gunType;
	public float fireRate;
	public float maxFireRate;
	public float throwTimer;
	public float maxThrowTime;
	public GameObject newGun;
	
	public SpriteRenderer Pistol;
	public SpriteRenderer AR;
	public SpriteRenderer RubberDuck;
	
	public int scoreValue = 50;
	public HUD hudd;


	void Start()
	{
		GetNewGun();
		tempScale = transform.localScale;
		arm = (Transform)GameObject.Find ("RightArm").GetComponent("Transform");
		player = (Movement)GameObject.Find ("Body").GetComponent("Movement");
		Pistol = (SpriteRenderer)GameObject.Find ("Pistol").GetComponent("SpriteRenderer");
		AR = (SpriteRenderer)GameObject.Find ("AR").GetComponent("SpriteRenderer");
		RubberDuck = (SpriteRenderer)GameObject.Find ("RubberDuck").GetComponent("SpriteRenderer");
		hudd = (HUD)GameObject.Find ("gameMaster").GetComponent("HUD");
		
	}

	public void Throw (bool isRight, float playerSpeed, Quaternion gunRot) 
	{

		if (ammo > 0) 
		{
			newGun = (GameObject)Instantiate (GameObject.Find ("GunPrefab"));
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
			
			if(player.facingRight)
			{
				if(playerSpeed < 5)
				{
					newGun.rigidbody2D.AddForce (dir * (velocity.x + playerSpeed));// throw the gun in the direction specified with a speed plus the player's current speed
				}
				else
				{
					newGun.rigidbody2D.AddForce (dir * (velocity.x * 1.5f + playerSpeed));// throw the gun in the direction specified with a speed plus the player's current speed
				}
			}
			else
			{
				if(playerSpeed > -5)
				{
					newGun.rigidbody2D.AddForce (dir * (velocity.x + playerSpeed));// throw the gun in the direction specified with a speed plus the player's current speed
				}
				else
				{
					newGun.rigidbody2D.AddForce (dir * (velocity.x * 1.5f + playerSpeed));// throw the gun in the direction specified with a speed plus the player's current speed
				}
			}
			Vector3 scale;
			switch(gunType)
			{
			case "Pistol":
				scale = transform.localScale;
				scale.x = -0.07364167f;
				scale.y = 0.07363904f;
				transform.localScale = scale;	
				Pistol.enabled = true;
				AR.enabled = false;
				RubberDuck.enabled = false;
				break;
			case "AR":
				scale = transform.localScale;
				scale.x = -0.2712036f;
				scale.y = 0.2712047f;
				transform.localScale = scale;
				AR.enabled = true;
				Pistol.enabled = false;
				RubberDuck.enabled = false;
				break;
			}

			newGun.rigidbody2D.AddTorque(Random.Range(50,150)); //rotate the gun randomly
			ammo -= 1;
			if(ammo == 0)
			{
			renderer.enabled = false;
			}
		}
	}
	void OnCollisionEnter2D(Collision2D col)
	{
		
		
		if(col.gameObject.tag == "Enemy" && !collided)
		   {
			Destroy(gameObject);
			col.gameObject.GetComponent<EnemyHealth>().health -= playerdamage;
			
			if(col.gameObject.GetComponent<EnemyHealth>().health <= 0)
			{
				hudd.AddScore(scoreValue);
			}

		}
		
		if(!collided)
		{
			
			gameObject.tag = "Untagged";
			rigidbody2D.drag = 20;
			collided = true;
			if(col.gameObject.tag == "Floor")
			{
				playerdamage = 0;
				gameObject.layer = 9;
			}
		}
	}
	
	public void GetNewGun()
	{
		if(gameObject.tag == "Player")
		{
			sprite = Resources.Load<Sprite> ("Weapons/Modern/" + gunType);
			gameObject.GetComponent<SpriteRenderer>().sprite = sprite;
			Vector3 scale;
			switch(gunType)
			{
			case "Pistol":
				velocity.x = 2000f;
				scale = transform.localScale;
				scale.x = -0.07364167f;
				scale.y = 0.07363904f;
				transform.localScale = scale;
				isAutomatic = false;
				twoHanded = false;
				fireRate = 0.5f;
				ammo = 5;		
				throwTimer = 0.25f;		
				playerdamage = 20;
				Pistol.enabled = true;
				AR.enabled = false;
				RubberDuck.enabled = false;
				break;
			case "AR":
				velocity.x = 2500f;
				scale = transform.localScale;
				scale.x = -0.2712036f;
				scale.y = 0.2712047f;
				transform.localScale = scale;
				isAutomatic = true;
				twoHanded = true;
				fireRate = 0.2f;
				ammo = 20;
				throwTimer = 0.1f;
				playerdamage = 35;
				Pistol.enabled = false;
				AR.enabled = true;
				RubberDuck.enabled = false;
				break;
			}
			maxAmmo = ammo;
			maxFireRate = fireRate;
			maxThrowTime = throwTimer;
			if(ammo ==0)
			{
			renderer.enabled = false;
			}
		}
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
