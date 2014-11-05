using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour {
	public Movement player;
	public Gun gun;
	//public GUIText ammoText;
	public GUIText WaveText;
	public EnemySpawn enemyspawn;
	public int EnemiesLeft = 0;
	public bool EnemiesDone = false;
	public float GUIWAVETIMER = 3;
	public GUIText RoundOver;
	public float RoundTimer = 5f + 3.983581f;
	public GUIText MissionOver;
	
	// Use this for initialization
	void Start () {
		EnemiesLeft = 1;
		enemyspawn = (EnemySpawn)GameObject.Find("SpawnPoint1").GetComponent("EnemySpawn");
		RoundOver = (GUIText)GameObject.Find ("RoundText").GetComponent ("GUIText");
		MissionOver = (GUIText)GameObject.Find ("RoundEndText").GetComponent("GUIText");
		RoundOver.enabled = false;
		MissionOver.enabled = false;
		RoundTimer = 5f;
	}
	
	// Update is called once per frame
	void Update () 
	{
	
		if(enemyspawn.LevelDoneTwo)
		{
		
		MissionOver.enabled = true;
		
		}
	
		if(EnemiesDone)
		{
			enemyspawn.waveWait -= Time.deltaTime;
		}


		if (GUIWAVETIMER > 0)
		{
			GUIWAVETIMER -= Time.deltaTime;
		}
		if (GUIWAVETIMER < 0)
		{
			WaveText.enabled = false;

		}

		//ammoText.text = gun.ammo.ToString ();
	
		GameObject [] enemies = GameObject.FindGameObjectsWithTag("Enemy");
		EnemiesLeft = enemies.Length/2;
			
		if(RoundTimer < 0)
		{
			RoundOver.enabled = false;
		}

		if (RoundOver.enabled = false)
		{
			RoundTimer = 5f;
			enemyspawn.NumberofEnemies = 0;
		}

		if (EnemiesLeft == 0 && enemyspawn.NumberofEnemies != 0)
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

	void OnGUI()
	{

	}

}
