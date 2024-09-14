using TMPro;
using UnityEngine;

public class BloodAltar : MonoBehaviour {
	[SerializeField] private TextMeshProUGUI sacrificedAmountText;
	[SerializeField] private ResourceTypeSO workerResourceType;

	[SerializeField] private float sacrificeTime = 2f;
	private float timer = 0f;

	private bool isWorkerInAltar = false;
	private Collider2D currentWorker;

	//todo add polish effects to a worker being sacrificed
	private void Update() {
		if (isWorkerInAltar && currentWorker != null) {
			timer += Time.deltaTime;

			if (timer >= sacrificeTime) {
				SacrificeWorker(currentWorker);
				ResetSacrifice();
			}
		}
	}

	private void OnTriggerEnter2D(Collider2D collision) {
		if (collision.CompareTag("Human")) {
			isWorkerInAltar = true;
			currentWorker = collision;
		}
	}

	private void OnTriggerExit2D(Collider2D collision) {
		if (collision.CompareTag("Human")) {
			ResetSacrifice();
		}
	}

	private void ResetSacrifice() {
		isWorkerInAltar = false;
		timer = 0f;
		currentWorker = null;
	}

	private void SacrificeWorker(Collider2D collision) {
		ResourceManager.Instance.AddSacrificedWorker(workerResourceType.shortname);
		Destroy(collision.gameObject);
		sacrificedAmountText.SetText(ResourceManager.Instance.GetSacrificedWorkerString(workerResourceType.shortname));
	}
}
