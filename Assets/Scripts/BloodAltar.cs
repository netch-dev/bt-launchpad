using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BloodAltar : MonoBehaviour {
	[SerializeField] private TextMeshProUGUI sacrificedAmountText;
	[SerializeField] private ResourceTypeSO workerResourceType;

	[SerializeField] private float sacrificeTime = 2f;
	private float timer = 0f;

	private AudioSource sacrificeAudioSource;

	private List<Collider2D> currentWorkers = new List<Collider2D>();

	private void Awake() {
		sacrificeAudioSource = GetComponent<AudioSource>();
	}

	//todo add polish effects to a worker being sacrificed. maybe fire on the altar
	private void Update() {
		if (currentWorkers.Count > 0) {
			timer += Time.deltaTime;

			if (timer >= sacrificeTime) {
				SacrificeWorker(currentWorkers[0]);
				ResetSacrifice(null);
			}
		}
	}

	private void OnTriggerEnter2D(Collider2D collision) {
		if (collision.CompareTag("Human")) {
			if (!currentWorkers.Contains(collision)) currentWorkers.Add(collision);
		}
	}

	private void OnTriggerExit2D(Collider2D collision) {
		if (collision.CompareTag("Human")) {
			ResetSacrifice(collision);
		}
	}

	private void ResetSacrifice(Collider2D collision) {
		timer = 0f;
		if (collision != null) currentWorkers.Remove(collision);
	}

	private void SacrificeWorker(Collider2D collision) {
		currentWorkers.Remove(collision);

		sacrificeAudioSource.pitch = Random.Range(0.95f, 1.05f);
		sacrificeAudioSource.Play();

		ResourceManager.Instance.AddSacrificedWorker(workerResourceType.shortname);
		Destroy(collision.gameObject);

		sacrificedAmountText.SetText(ResourceManager.Instance.GetSacrificedWorkerString(workerResourceType.shortname));
	}
}
