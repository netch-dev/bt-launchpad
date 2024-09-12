using UnityEngine;

public class Resource : MonoBehaviour {
	[SerializeField] private string resourceType;
	[SerializeField] private float resourceAmount;

	public void OnCollect(float amount) {
		float collectedAmount = Mathf.Min(resourceAmount, amount);
		resourceAmount -= collectedAmount;
		ResourceManager.Instance.AddResource(resourceType, collectedAmount);

		if (resourceAmount <= 0) Destroy(gameObject);
	}
}
