using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour {
	[SerializeField] private Transform workerGhost;
	[SerializeField] private Transform townGhost;
	[SerializeField] private Transform treeGhost;
	[SerializeField] private Transform crystalGhost;
	[SerializeField] private Transform trapGhost;

	private Dictionary<BuildingType, Transform> buildingGhosts;

	public enum BuildingType {
		Worker = 0,
		Town = 1,
		Tree = 2,
		Crystal = 3,
		Trap = 4
	}

	private void Awake() {
		buildingGhosts = new Dictionary<BuildingType, Transform> {
			{ BuildingType.Worker, workerGhost },
			{ BuildingType.Town, townGhost },
			{ BuildingType.Tree, treeGhost },
			{ BuildingType.Crystal, crystalGhost },
			{ BuildingType.Trap, trapGhost }
		};

		DisableGhostObjects();
	}

	private void DisableGhostObjects() {
		foreach (Transform ghost in buildingGhosts.Values) {
			ghost.gameObject.SetActive(false);
		}
	}

	public void OnShopButtonClick(int buildingTypeIndex) {
		DisableGhostObjects();

		BuildingType buildingType = (BuildingType)buildingTypeIndex;

		if (buildingGhosts.TryGetValue(buildingType, out Transform ghost)) {
			ghost.gameObject.SetActive(true);
		}
	}
}
