using UnityEngine;

public class Ghost : MonoBehaviour {
	[SerializeField] private Transform prefabToSpawn;
	private Camera mainCamera;
	private void Start() {
		mainCamera = Camera.main;
	}

	private void Update() {
		MoveToMousePosition();
		HandleInput();
	}

	private void MoveToMousePosition() {
		Vector3 position = mainCamera.ScreenToWorldPoint(Input.mousePosition);
		position.z = 0;

		transform.position = position;
	}

	private void HandleInput() {
		if (Input.GetMouseButtonDown(0)) {
			Instantiate(prefabToSpawn, transform.position, transform.rotation);
			gameObject.SetActive(false);
		}

		if (Input.GetMouseButtonDown(1)) {
			gameObject.SetActive(false);
		}
	}
}
