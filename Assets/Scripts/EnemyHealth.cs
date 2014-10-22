using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

	public int health;

	public Transform player;
	public Vector2 speed;
	public float speedx = 10;
	Animator anim;
	public float DeathTimer = 5;
	public bool Dead;

	// Use this for initialization
	void Start () {
		health = 100;
		player = GameObject.FindGameObjectWithTag("Player").transform;
		Dead = false;
	}
	
	// Update is called once per frame
	void Update () {

	
		speed.x = speedx;
	
		if(player.position.x > rigidbody2D.position.x +1)
		{
			speed.x *= 1;
		
		}

		if(player.position.x < rigidbody2D.position.x - 1f)
		{
			speed.x *= -1;

		}
	
		if(player.position.x == rigidbody2D.position.x)
		{
		speed.x *= 0;
		}
		
		rigidbody2D.AddForce(speed);
		
		Vector3 scale;
		if(player.position.x < transform.position.x)
		{
			scale = transform.localScale;
			scale.x = 0.3289828f;
			transform.localScale = scale;		
		
		}
		else
			if(player.position.x > transform.position.x)
		{
			scale = transform.localScale;
			scale.x = -0.3289828f;
			transform.localScale = scale;	   
		}   


		if(health <= 0)
		{
		speedx = 0;
		Dead = true;
		gameObject.layer = 13; 
		
		if(DeathTimer > 0)
		{
		DeathTimer -= Time.deltaTime;
		}
		else
		{
		Destroy(gameObject);
		}
		
		}

	}
}
