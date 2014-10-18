using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

	public int Health;
	public Gun gun;
	public Transform Player;
	public Vector2 speed;
	public float speedx = 10;


	// Use this for initialization
	void Start () {
		Health = 100;
		Player = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {

	
		speed.x = speedx;
	
		if(Player.position.x > rigidbody2D.position.x)
		{
			speed.x *= 1;
		
		}

		if(Player.position.x < rigidbody2D.position.x)
		{
			speed.x *= -1;

		}
	
		rigidbody2D.AddForce(speed);
		Vector3 scale;
		if(Player.position.x < transform.position.x)
		{
			scale = transform.localScale;
			scale.x = 0.3289828f;
			transform.localScale = scale;		
		
		}
		else
			if(Player.position.x > transform.position.x)
		{
			scale = transform.localScale;
			scale.x = -0.3289828f;
			transform.localScale = scale;	   
		}   



		if(Health == 0 || Health < 0)
		{
			//anim.SetBool("isDead", true);
			Destroy (gameObject);
		}

	}
}
