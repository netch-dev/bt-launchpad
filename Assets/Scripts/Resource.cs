using TMPro;
using UnityEngine;

public class Resource : MonoBehaviour {
	[SerializeField] private ResourceTypeSO resourceType;
	[SerializeField] private float resourceAmount;

	public float OnCollect(float amount) {
		float collectedAmount = Mathf.Min(resourceAmount, amount);
		resourceAmount -= collectedAmount;
		ResourceManager.Instance.AddResource(resourceType.shortname, collectedAmount);

		if (resourceAmount <= 0) Destroy(gameObject);

		return collectedAmount;
	}
}
