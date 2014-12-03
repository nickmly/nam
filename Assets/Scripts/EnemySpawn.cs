using UnityEngine;
using System.Collections;

public class EnemySpawn : MonoBehaviour
{
	public GameObject enemy;
	public Vector3 spawnValues;
	public int enemyCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	public int EnemyWave;
	private float leftSide = 1;
	public int EnemyIterations;
	public int NumberofEnemies;
	public HUD hud; 
	public bool LevelDoneOne;
	public bool LevelDoneTwo;
	
	void Start ()
	{
		hud = (HUD)GameObject.Find ("gameMaster").GetComponent("HUD");
		StartCoroutine (SpawnWaves ());
		EnemyWave = 1;
		waveWait = 5f;
	}
	
	void Update()
	{


		if(leftSide > 0)
		{
			leftSide *= -1;
		}
		else
		{
			leftSide *= -1;
		}

	if(waveWait <= 0 && EnemyWave < 10)
		{
			switch (EnemyWave)
			{
			case 1:
				EnemyIterations = 10;
				break;
			case 2:
				EnemyIterations = 15;
				spawnWait = 0;
				break;
			case 3:
				EnemyIterations = 25;
				spawnWait = 0;
				break;
			case 4:
				EnemyIterations = 35;
				spawnWait = 0;
				break;
			case 5:
				EnemyIterations = 45;
				spawnWait = 0;
				break;
			case 6:
				EnemyIterations = 50;
				spawnWait = 0;
				break;
			case 7:
				EnemyIterations = 100;
				spawnWait = 0;
				break;
			
			
			}
			hud.EnemiesDone = false;
			StartCoroutine(SpawnWaves ());
			waveWait = 5f;
		}

	}

	
	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds (startWait);
			while(EnemyIterations > 0)
			{
			Vector3 spawnPosition = new Vector3(68f * leftSide,3f,1.57f);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (enemy, spawnPosition, spawnRotation);
				
				yield return new WaitForSeconds (spawnWait);
				EnemyIterations--;
				NumberofEnemies++;
			}
		EnemyWave++;
			yield return new WaitForSeconds (waveWait);
	}
	
}