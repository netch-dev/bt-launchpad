using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CameraAnimator : MonoBehaviour {
	public static CameraAnimator Instance;

	private Animator cameraAnimator;
	private void Awake() {
		Instance = this;
		cameraAnimator = GetComponent<Animator>();
	}

	public void Shake() {
		cameraAnimator.SetTrigger("shake");
	}
}
