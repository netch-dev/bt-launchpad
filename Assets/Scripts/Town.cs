using UnityEngine;

public class Town : MonoBehaviour {
	[SerializeField] private Transform workerPrefab;
	[SerializeField] private Transform spawnPoint;

	[SerializeField] private int amountOfWorkersToSpawn;

	[SerializeField] private float timeBetweenSpawns;
	private float nextSpawnTime;

	private void Update() {
		if (Time.time >= nextSpawnTime) {
			SpawnWorker();
			nextSpawnTime = Time.time + timeBetweenSpawns;
		}
	}

	private void SpawnWorker() {
		Instantiate(workerPrefab, spawnPoint.position, Quaternion.identity);

		amountOfWorkersToSpawn--;
		if (amountOfWorkersToSpawn <= 0) {
			Destroy(gameObject);
		}
	}
}
