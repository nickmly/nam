using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

	public int health;

	//public Gun gun;
	public Transform player;
	public Vector2 speed;
	public float speedx = 10;
	Animator anim;
	public float DeathTimer = 5;
	public bool Dead;

	// Use this for initialization
	void Start () {
		health = 1;
		//player = GameObject.FindGameObjectWithTag("Player").transform;
		Dead = false;
	}
	
	
	// Update is called once per frame
	void Update () {


	
		speed.x = speedx;
	
		if(player.position.x > rigidbody2D.position.x +1)
		{
			speed.x *= 1;
		
		}

		if(player.position.x < rigidbody2D.position.x - 1f && !Dead)
		{
			speed.x *= -1;

		}
	
		if(player.position.x == rigidbody2D.position.x && !Dead)
		{
		speed.x *= 0;
		}
		
		rigidbody2D.AddForce(speed);
		
		Vector3 scale;
		if(player.position.x < transform.position.x && !Dead)
		{
			scale = transform.localScale;
			scale.x = 0.3289828f;
			transform.localScale = scale;		
		
		}
		else
			if(player.position.x > transform.position.x && !Dead)
		{
			scale = transform.localScale;
			scale.x = -0.3289828f;
			transform.localScale = scale;	   
		}   


		if(health <= 0)
		{
		speedx = 0;
		speed.x = 0;
		Dead = true;
		gameObject.layer = 13;
		gameObject.tag = "DeadEnemy";
		
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
	
	void OnCollisionEnter2D(Collision2D col)
	{
	
		if(col.gameObject.tag == "Gun")
		{
			Debug.Log ("ouch");
			health -= col.gameObject.GetComponent<Gun>().playerdamage;
		}
	}
}
