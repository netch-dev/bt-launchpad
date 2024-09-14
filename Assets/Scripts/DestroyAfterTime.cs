using UnityEngine;

public class DestroyAfterTime : MonoBehaviour {
	[SerializeField] private float destroyTime = 10f;
	private void Awake() {
		Destroy(gameObject, destroyTime);
	}
}
