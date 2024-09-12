using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worker : MonoBehaviour {

	private Camera mainCamera;

	private void Start() {
		mainCamera = Camera.main;
	}

	private void OnMouseDrag() {
		Vector3 position = mainCamera.ScreenToWorldPoint(Input.mousePosition);
		position.z = 0;

		transform.position = position;
	}
}
