using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour {
	[SerializeField] private Transform bloodPrefab;

	[SerializeField] private float speed;

	[SerializeField] private float minX, maxX, minY, maxY;

	private Vector3 targetPosition;

	private void Start() {
		targetPosition = GetRandomPosition();
	}

	private void Update() {
		if (Vector3.Distance(transform.position, targetPosition) <= 0.1f) {
			targetPosition = GetRandomPosition();
		}

		transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
	}

	private void OnTriggerEnter2D(Collider2D collision) {
		if (collision.CompareTag("Altar")) {
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}

		if (collision.CompareTag("Trap")) {
			CameraAnimator.Instance.Shake();

			Destroy(collision.gameObject);
			Instantiate(bloodPrefab, gameObject.transform.position, Quaternion.identity);
			Destroy(gameObject);
		}
	}

	private Vector3 GetRandomPosition() {
		return new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 0);
	}
}
