using UnityEngine;

public class Ghost : MonoBehaviour {
	[SerializeField] private BuildingTypeSO buildingTypeSO;
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
			bool removedResources = ResourceManager.Instance.RemovedResource(buildingTypeSO.constructionResourceCost.resourceType.shortname,
																			 buildingTypeSO.constructionResourceCost.amount);
			if (removedResources) {
				Instantiate(buildingTypeSO.prefab, transform.position, transform.rotation);
			} else {
				//todo show a message that the player doesn't have enough resources
			}

			gameObject.SetActive(false);
		}

		if (Input.GetMouseButtonDown(1)) {
			gameObject.SetActive(false);
		}
	}
}
