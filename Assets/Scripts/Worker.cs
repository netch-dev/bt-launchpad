using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worker : MonoBehaviour {
	private bool isSelected = false;

	private Camera mainCamera;

	private void Start() {
		mainCamera = Camera.main;
	}

	private void Update() {
		if (IsSelected()) {
			Vector3 position = mainCamera.ScreenToWorldPoint(Input.mousePosition);
			position.z = 0;

			transform.position = position;
		}
	}

	private void OnMouseDown() {
		isSelected = true;
	}

	private void OnMouseUp() {
		isSelected = false;
	}

	public bool IsSelected() {
		return isSelected;
	}
}
