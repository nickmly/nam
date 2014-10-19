using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

	public int health;
	public Gun gun;
	public Transform player;
	public Vector2 speed;
	public float speedx = 10;


	// Use this for initialization
	void Start () {
		health = 100;
		player = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {

	
		speed.x = speedx;
	
		if(player.position.x > rigidbody2D.position.x)
		{
			speed.x *= 1;
		
		}

		if(player.position.x < rigidbody2D.position.x)
		{
			speed.x *= -1;

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
			//anim.SetBool("isDead", true);
			Destroy (gameObject);
		}

	}
}
