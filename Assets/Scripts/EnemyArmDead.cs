﻿using UnityEngine;
using System.Collections;

public class EnemyArmDead : MonoBehaviour {

	public Animator anim;
	public GameObject enemy;


	// Use this for initialization
	void Start () {
	
	}
	
	
	// Update is called once per frame
	void Update () {
	
	if(enemy.GetComponent<EnemyHealth>().dead)
	{
	
	anim.SetBool("isDead",true);
	
	}
	
	if(enemy.GetComponent<EnemyHealth>().isStill)
	{
	anim.SetBool ("isAttacking", true);
	anim.SetBool("isStill",enemy.GetComponent<EnemyHealth>().isStill);
	}
	else{
	anim.SetBool("isStill",false);
	anim.SetBool ("isAttacking",false);
	}
	
	}
}
