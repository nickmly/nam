using UnityEngine;
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
	private float AttackingDistance = 2.5f;

	public Animator EnemyBodyAnim;
	public Animator EnemyArmAnim;
	public Animator EnemyLegAnim;

	public bool isStill;


	
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
		EnemyArmAnim = (Animator)GameObject.Find("/EnemyBody/EnemyBodyHolder/EnemyArms").GetComponent("Animator");
		EnemyLegAnim = (Animator)GameObject.Find("/EnemyBody/EnemyBodyHolder/EnemyLegs").GetComponent("Animator");

	}

	// Update is called once per frame
	void Update ()
	{
		EnemyBodyAnim.SetBool("isStill",isStill);
		EnemyArmAnim.SetBool("isStill",isStill);
		EnemyLegAnim.SetBool("isStill",isStill);
	
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
				Destroy (gameObject);
				
			}	
		}
		
	}

}
