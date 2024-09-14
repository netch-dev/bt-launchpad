using UnityEngine;
using UnityEngine.UI;

public class ShopButton : MonoBehaviour {
	[SerializeField] private BuildingTypeSO buildingType;

	private Button button;

	private void Start() {
		button = GetComponent<Button>();

		ResourceManager.Instance.OnResourceAmountChanged += OnResourceAmountChanged;
		OnResourceAmountChanged();
	}

	private void OnResourceAmountChanged() {
		float currentResourceAmount = ResourceManager.Instance.GetResourceAmount(buildingType.constructionResourceCost.resourceType);
		bool hasEnoughResources = currentResourceAmount >= buildingType.constructionResourceCost.amount;
		button.interactable = hasEnoughResources;
	}
}
