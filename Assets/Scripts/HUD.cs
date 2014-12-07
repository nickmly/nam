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
	public float RoundTimer = 5f;
	
	public GUIText scoreText;
	public int score;
	
	public Canvas deadCanvas;
	public GUIText deadText;
	public SpriteRenderer deadBG;
	
	public bool paused = false;
	public GUIText pausedText;
	
	public GUIText pickupText;

	// Use this for initialization
	void Start () 
	{
		EnemiesLeft = 0;
		EnemiesDone = false;
		enemyspawn = (EnemySpawn)GameObject.Find("SpawnPoint1").GetComponent("EnemySpawn");
		RoundOver = (GUIText)GameObject.Find ("RoundText").GetComponent ("GUIText");
		RoundOver.enabled = false;
		score = 0;
		UpdateScore();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		if(player.health <= 0)
		{
			player.transform.position = new Vector3(0.85507f,5.1239f,1.762541f);
			deadCanvas.enabled = true;
			deadText.enabled = true;
			deadBG.enabled = true;
		}
		
		if(Input.GetKeyDown (KeyCode.Escape))
		{
			if(!paused)
			{
				pausedText.enabled = true;
				paused = true;
				Object[] objects = FindObjectsOfType (typeof(GameObject));
				foreach (GameObject go in objects) 
				{
					go.SendMessage ("OnPauseGame", SendMessageOptions.DontRequireReceiver);
				}
				Time.timeScale = 0f;
			}
			else
			{
				pausedText.enabled = false;
				paused = false;
				Object[] objects = FindObjectsOfType (typeof(GameObject));
				foreach (GameObject go in objects) 
				{
					go.SendMessage ("OnResumeGame", SendMessageOptions.DontRequireReceiver);
				}
				Time.timeScale = 1f;
			}
		}
	
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
			RoundOver.enabled = false;
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
//	audio.Play();
	
	}

}
