using System;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour {
	public static ResourceManager Instance;

	public Action OnResourceAmountChanged;

	public enum ResourceType {
		Blood,
		Wood,
		Crystal
	}

	private void Awake() {
		Instance = this;

		foreach (ResourceType resourceType in Enum.GetValues(typeof(ResourceType))) {
			resourceAmounts.Add(resourceType, 0);
		}
	}

	public Dictionary<ResourceType, float> resourceAmounts = new Dictionary<ResourceType, float>();

	public void AddResource(ResourceType resourceType, float amount) {
		resourceAmounts[resourceType] += amount;

		OnResourceAmountChanged?.Invoke();
	}

	public bool RemovedResource(ResourceType resourceType, float amount) {
		bool hasEnough = resourceAmounts[resourceType] >= amount;
		if (hasEnough) {
			resourceAmounts[resourceType] -= amount;
			OnResourceAmountChanged?.Invoke();
			return true;
		}

		return false;
	}

	public float GetResourceAmount(ResourceType resourceType) {
		if (resourceAmounts.ContainsKey(resourceType)) {
			return resourceAmounts[resourceType];
		} else {
			return 0;
		}
	}
}
