using System;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour {
	public static ResourceManager Instance;

	public Action OnResourceAmountChanged;

	private void Awake() {
		Instance = this;
	}

	public Dictionary<string, float> resourceAmounts = new Dictionary<string, float>();

	public void AddResource(string resourceType, float amount) {
		if (resourceAmounts.ContainsKey(resourceType)) {
			resourceAmounts[resourceType] += amount;
		} else {
			resourceAmounts.Add(resourceType, amount);
		}

		OnResourceAmountChanged?.Invoke();
	}

	public bool RemovedResource(string resourceType, float amount) {
		bool hasEnough = resourceAmounts.ContainsKey(resourceType) && resourceAmounts[resourceType] >= amount;
		if (hasEnough) {
			resourceAmounts[resourceType] -= amount;
			OnResourceAmountChanged?.Invoke();
			return true;
		}

		return false;
	}

	public float GetResourceAmount(string resourceType) {
		if (resourceAmounts.ContainsKey(resourceType)) {
			return resourceAmounts[resourceType];
		} else {
			return 0;
		}
	}
}
