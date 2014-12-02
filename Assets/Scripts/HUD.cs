using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour {
	public Movement player;
	public Gun gun;
	public GUIText WaveText;
	public EnemySpawn enemyspawn;
	public int EnemiesLeft = 0;
	public bool EnemiesDone = false;
	public float GUIWAVETIMER = 3;
	public GUIText RoundOver;
	public float RoundTimer = 5f + 3.983581f;
	
	public GUIText scoreText;
	public int score;
	
	// Use this for initialization
	void Start () {
		EnemiesLeft = 0;
		EnemiesDone = false;
		enemyspawn = (EnemySpawn)GameObject.Find("SpawnPoint1").GetComponent("EnemySpawn");
		RoundOver = (GUIText)GameObject.Find ("RoundText").GetComponent ("GUIText");
		RoundOver.enabled = false;
		RoundTimer = 5f;
		score = 0;
		UpdateScore();
	}
	
	// Update is called once per frame
	void Update () 
	{
	
		if(enemyspawn.waveWait > 2)
		{
		
		RoundOver.enabled = true;
		
		}
		else
		{
		
		RoundOver.enabled = false;
		
		}
	
		if(EnemiesLeft == 1)
		{
			enemyspawn.waveWait -= Time.deltaTime;
			//RoundOver.enabled = true;
		}


		if (GUIWAVETIMER > 0)
		{
			GUIWAVETIMER -= Time.deltaTime;
			//RoundOver.enabled=true;
		}
		
		else
		{
		//RoundOver.enabled = false;
		}

		//ammoText.text = gun.ammo.ToString ();
	
		GameObject [] enemies = GameObject.FindGameObjectsWithTag("Enemy");
		EnemiesLeft = enemies.Length/2;
			
		if(RoundTimer < 0)
		{
			//RoundOver.enabled = false;
		}

		if (RoundOver.enabled == false)
		{
			RoundTimer = 5f;
			enemyspawn.NumberofEnemies = 0;
		}

		if (EnemiesLeft == 0)
		{
			EnemiesDone = true;
			
			if (!enemyspawn.LevelDoneOne)
			RoundOver.enabled = true;
		
			if (RoundTimer > 0)
			{
				RoundTimer -= Time.deltaTime;
			}




			/*if(RoundOver.enabled = true && RoundTimer > 0)
			{
				RoundTimer -= Time.deltaTime;
			}
			if(RoundTimer < 0)
			{
				RoundOver.enabled = false;
			}

			if (RoundOver.enabled = false)
			{
				RoundTimer = 5f;
			}*/
			
		}

	}

	void UpdateScore()
	{
		scoreText.text = "S C O R E : " + score;
	}
	
	public void AddScore (int newScoreValue)
	{
	
	score += newScoreValue;
	UpdateScore();
	audio.Play();
	
	}

}
