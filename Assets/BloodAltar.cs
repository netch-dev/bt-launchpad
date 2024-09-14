using TMPro;
using UnityEngine;

public class BloodAltar : MonoBehaviour {
	[SerializeField] private TextMeshProUGUI sacrificedAmountText;
	[SerializeField] private ResourceTypeSO workerResourceType;

	//todo update this to make the user hold the worker over the altar for 2 seconds
	// instead of instantly sacrificing the worker
	private void OnTriggerEnter2D(Collider2D collision) {
		TrySacrificeWorker(collision);
	}

	private void TrySacrificeWorker(Collider2D collision) {
		if (collision.CompareTag("Human")) {
			ResourceManager.Instance.AddSacrificedWorker(workerResourceType.shortname);
			Destroy(collision.gameObject);

			sacrificedAmountText.SetText(ResourceManager.Instance.GetSacrificedWorkerString(workerResourceType.shortname));
		}
	}
}
