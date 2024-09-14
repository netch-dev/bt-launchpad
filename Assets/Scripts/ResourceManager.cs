using System;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour {
	[SerializeField] private int sacrificeGoal = 25;
	[SerializeField] private ResourceTypeListSO resourceTypeList;

	public static ResourceManager Instance;

	public Action OnResourceAmountChanged;

	private Dictionary<string, float> resourceAmounts;

	private void Awake() {
		Instance = this;

		resourceAmounts = new Dictionary<string, float>();
		foreach (ResourceTypeSO resourceType in resourceTypeList.list) {
			resourceAmounts.Add(resourceType.shortname, 0);
		}
	}


	public void AddResource(string resourceShortname, float amount) {
		resourceAmounts[resourceShortname] += amount;

		OnResourceAmountChanged?.Invoke();
	}

	public bool RemovedResource(string resourceShortname, float amount) {
		bool hasEnough = resourceAmounts[resourceShortname] >= amount;
		if (hasEnough) {
			resourceAmounts[resourceShortname] -= amount;
			OnResourceAmountChanged?.Invoke();
			return true;
		}

		return false;
	}

	public float GetResourceAmount(string resourceShortname) {
		if (resourceAmounts.ContainsKey(resourceShortname)) {
			return resourceAmounts[resourceShortname];
		} else {
			return 0;
		}
	}

	public void AddSacrificedWorker(string sacrificedWorkerShortname) {
		resourceAmounts[sacrificedWorkerShortname]++;
		OnResourceAmountChanged?.Invoke();

		if (resourceAmounts[sacrificedWorkerShortname] >= sacrificeGoal) {
			Debug.Log("You have enough sacrifices to summon the demon");
			//todo spawn the boss or win the game
		}
	}

	public string GetSacrificedWorkerString(string sacrificedWorkerShortname) {
		return $"{resourceAmounts[sacrificedWorkerShortname]}/{sacrificeGoal}";
	}
}
