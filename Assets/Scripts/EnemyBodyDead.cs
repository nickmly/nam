using UnityEngine;
using System.Collections;

public class EnemyBodyDead : MonoBehaviour {

	public GameObject enemy;
	public Animator anim;
	public bool isDying = false;



	// Use this for initialization
	void Start () {
	isDying = false;
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if(enemy.GetComponent<EnemyHealth>().health <= 0)
		{
		gameObject.layer = 9;
		}
	
	if(enemy.GetComponent<EnemyHealth>().dead == true)
	{
	isDying = true;
	}
	
	anim.SetBool("isDead", isDying);
	
	}

	void OnCollisionEnter2D (Collision2D col)
	{
		if(col.gameObject.layer == 12 && !isDying)
		{

		}
	}
	
	
	
}
