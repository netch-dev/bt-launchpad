using UnityEngine;

public class Resource : MonoBehaviour {
	[SerializeField] private string resourceType;
	[SerializeField] private float resourceAmount;

	public void OnCollect(float amount) {
		float collectedAmount = Mathf.Min(resourceAmount, amount);
		resourceAmount -= collectedAmount;
		Debug.Log($"Collected x{collectedAmount} {resourceType}. {resourceAmount} remain");
		if (resourceAmount <= 0) {
			Destroy(gameObject);
		}
	}
}
