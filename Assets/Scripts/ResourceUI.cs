using TMPro;
using UnityEngine;

public class ResourceUI : MonoBehaviour {
	[SerializeField] private TextMeshProUGUI bloodText;
	[SerializeField] private TextMeshProUGUI woodText;
	[SerializeField] private TextMeshProUGUI crystalText;

	private void Start() {
		ResourceManager.Instance.OnResourceAmountChanged += UpdateResourceUI;
	}

	private void UpdateResourceUI() {
		bloodText.text = ResourceManager.Instance.GetResourceAmount(ResourceManager.ResourceType.Blood).ToString("N0");
		woodText.text = ResourceManager.Instance.GetResourceAmount(ResourceManager.ResourceType.Wood).ToString("N0");
		crystalText.text = ResourceManager.Instance.GetResourceAmount(ResourceManager.ResourceType.Crystal).ToString("N0");
	}
}
