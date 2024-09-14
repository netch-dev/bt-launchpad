using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/ResourceType")]
public class ResourceTypeSO : ScriptableObject {
	public string displayName;
	public string shortname;
	public Sprite sprite;
	public string colourHex;
}
