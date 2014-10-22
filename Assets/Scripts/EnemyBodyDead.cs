﻿using UnityEngine;
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
	
	if(enemy.GetComponent<EnemyHealth>().Dead == true)
	{
	isDying = true;
	}
	
	anim.SetBool("isDead", isDying);
	
	}
}
