using TMPro;
using UnityEngine;

public class Worker : MonoBehaviour {
	[SerializeField] private LayerMask resourceLayer;

	[SerializeField] private Transform resourcePopupPrefab;
	[SerializeField] private Vector3 resourcePopupOffset;

	[SerializeField] private float collectDistance;

	[SerializeField] private float collectAmount;
	[SerializeField] private float collectInterval;
	private float nextCollectTime;

	private Resource currentResource;

	private Camera mainCamera;
	private bool isSelected;

	private void Start() {
		mainCamera = Camera.main;
	}

	private void OnMouseDown() {
		isSelected = true;
	}

	private void OnMouseUp() {
		isSelected = false;
	}

	private void Update() {
		if (isSelected) {
			MoveToMousePosition();
		} else {
			FindNearbyResource();
			TryHarvestResource();
		}
	}

	private void MoveToMousePosition() {
		Vector3 position = mainCamera.ScreenToWorldPoint(Input.mousePosition);
		position.z = 0;

		transform.position = position;
	}

	private void FindNearbyResource() {
		Collider2D col = Physics2D.OverlapCircle(transform.position, collectDistance, resourceLayer);
		if (col != null && currentResource == null) {
			currentResource = col.GetComponent<Resource>();
		} else {
			currentResource = null;
		}
	}
	private void TryHarvestResource() {
		if (currentResource != null) {
			if (Time.time >= nextCollectTime) {
				nextCollectTime = Time.time + collectInterval;
				float collectedAmount = currentResource.OnCollect(collectAmount);

				Transform resourcePopup = Instantiate(resourcePopupPrefab, transform.position + resourcePopupOffset, Quaternion.identity);
				resourcePopup.gameObject.GetComponentInChildren<TextMeshProUGUI>()?.SetText($"+{collectedAmount}");
			}
		}
	}
}
