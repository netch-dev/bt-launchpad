using UnityEngine;

public class EnemyManager : MonoBehaviour {
	[SerializeField] private Transform[] spawnPoints;
	[SerializeField] private Transform enemyPrefab;

	[SerializeField] private float timeBetweenSpawns;
	private float nextSpawnTime;

	private void Update() {
		if (Time.time >= nextSpawnTime) {
			SpawnEnemy();
			nextSpawnTime = Time.time + timeBetweenSpawns;
		}
	}

	private void SpawnEnemy() {
		Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
		Instantiate(enemyPrefab, randomSpawnPoint.position, Quaternion.identity);
	}
}
