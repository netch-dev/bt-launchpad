using TMPro;
using UnityEngine;

public class ResourceUI : MonoBehaviour {
	//Todo make the UI dynamic
	[SerializeField] private TextMeshProUGUI bloodText;
	[SerializeField] private TextMeshProUGUI woodText;
	[SerializeField] private TextMeshProUGUI crystalText;

	[SerializeField] private ResourceTypeSO bloodResourceSO;
	[SerializeField] private ResourceTypeSO woodResourceSO;
	[SerializeField] private ResourceTypeSO crystalResourceSO;

	private void Start() {
		ResourceManager.Instance.OnResourceAmountChanged += UpdateResourceUI;
	}

	private void UpdateResourceUI() {
		bloodText.text = ResourceManager.Instance.GetResourceAmount(bloodResourceSO).ToString("N0");
		woodText.text = ResourceManager.Instance.GetResourceAmount(woodResourceSO).ToString("N0");
		crystalText.text = ResourceManager.Instance.GetResourceAmount(crystalResourceSO).ToString("N0");
	}
}
