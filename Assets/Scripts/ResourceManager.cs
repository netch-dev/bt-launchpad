using System;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour {
	[SerializeField] private ResourceTypeListSO resourceTypeList;

	public static ResourceManager Instance;

	public Action OnResourceAmountChanged;

	private Dictionary<ResourceTypeSO, float> resourceAmounts;

	private void Awake() {
		Instance = this;

		resourceAmounts = new Dictionary<ResourceTypeSO, float>();
		foreach (ResourceTypeSO resourceType in resourceTypeList.list) {
			resourceAmounts.Add(resourceType, 0);
		}
	}


	public void AddResource(ResourceTypeSO resourceType, float amount) {
		resourceAmounts[resourceType] += amount;

		OnResourceAmountChanged?.Invoke();
	}

	public bool RemovedResource(ResourceTypeSO resourceType, float amount) {
		bool hasEnough = resourceAmounts[resourceType] >= amount;
		if (hasEnough) {
			resourceAmounts[resourceType] -= amount;
			OnResourceAmountChanged?.Invoke();
			return true;
		}

		return false;
	}

	public float GetResourceAmount(ResourceTypeSO resourceType) {
		if (resourceAmounts.ContainsKey(resourceType)) {
			return resourceAmounts[resourceType];
		} else {
			return 0;
		}
	}
}
