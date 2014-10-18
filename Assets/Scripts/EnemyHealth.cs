using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

	public int Health;
	public Gun gun;

	// Use this for initialization
	void Start () {
		Health = 100;
	}
	
	// Update is called once per frame
	void Update () {

		if(Health == 0 || Health < 0)
		{
			//anim.SetBool("isDead", true);
			Destroy (gameObject);
		}

	}
}
