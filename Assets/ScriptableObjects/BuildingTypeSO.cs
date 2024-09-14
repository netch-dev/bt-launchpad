using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/BuildingType")]
public class BuildingTypeSO : ScriptableObject {
	public string nameString;
	public Transform prefab;
	public Sprite sprite;
	public ResourceAmount constructionResourceCost;
	public int healthAmountMax;
}
