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
	private float leftSide = 1;
	public int EnemyIterations;
	
	void Start ()
	{
		StartCoroutine (SpawnWaves ());
	}
	
	void Update()
	{
	
	if(gameObject.tag == "SpawnPoint1")
	{
	leftSide = -1;
	}
	else if(gameObject.tag == "SpawnPoint2")
	{
	leftSide = 1;
	}
	}
	
	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds (startWait);
		while (true)
		{
			while(EnemyIterations > 0)
			{
				Vector3 spawnPosition = new Vector3(68f * leftSide,3f,1.57f);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (enemy, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);
				EnemyIterations--;
			}
			yield return new WaitForSeconds (waveWait);
		}
	}
	
}