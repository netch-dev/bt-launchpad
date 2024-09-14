using UnityEditor;
using UnityEngine;

public class CustomEditorKeybinds : EditorWindow {
	[MenuItem("Tools/Keybinds/Toggle Object #V")] // Shift + V
	private static void EnableDisableObject() {
		if (Selection.activeGameObject != null) {
			Selection.activeGameObject.SetActive(!Selection.activeGameObject.activeSelf);
		} else {
			Debug.LogWarning("No object selected to enable/disable.");
		}
	}

	[MenuItem("Tools/Keybinds/Reset Transform #T")] // Shift + T
	private static void ResetTransform() {
		if (Selection.activeTransform != null) {
			Undo.RecordObject(Selection.activeTransform, "Reset Transform");
			Selection.activeTransform.position = Vector3.zero;
			Selection.activeTransform.rotation = Quaternion.identity;
			Selection.transforms[0].localPosition = Vector3.zero;
			Selection.transforms[0].localRotation = Quaternion.identity;
			Selection.activeTransform.localScale = Vector3.one;
		} else {
			Debug.LogWarning("No object selected to reset transform.");
		}
	}

	[MenuItem("Tools/Keybinds/Reset Position #P")] // Shift + P
	private static void ResetPosition() {
		if (Selection.activeTransform != null) {
			Undo.RecordObject(Selection.activeTransform, "Reset Position");
			Selection.activeTransform.position = Vector3.zero;
		} else {
			Debug.LogWarning("No object selected to reset position.");
		}
	}

	[MenuItem("Tools/Keybinds/Reset Rotation #R")] // Shift + R
	private static void ResetRotation() {
		if (Selection.activeTransform != null) {
			Undo.RecordObject(Selection.activeTransform, "Reset Rotation");
			Selection.activeTransform.rotation = Quaternion.identity;
		} else {
			Debug.LogWarning("No object selected to reset rotation.");
		}
	}

	[MenuItem("Tools/Keybinds/Reset Scale #S")] // Shift + S
	private static void ResetScale() {
		if (Selection.activeTransform != null) {
			Undo.RecordObject(Selection.activeTransform, "Reset Scale");
			Selection.activeTransform.localScale = Vector3.one;
		} else {
			Debug.LogWarning("No object selected to reset scale.");
		}
	}

	// Disable the menu item if no object is selected
	[MenuItem("Tools/Keybinds/Toggle Object #V", true)]
	[MenuItem("Tools/Keybinds/Reset Transform #T", true)]
	[MenuItem("Tools/Keybinds/Reset Position #P", true)]
	[MenuItem("Tools/Keybinds/Reset Rotation #R", true)]
	[MenuItem("Tools/Keybinds/Reset Scale #S", true)]
	private static bool ValidateKeybinds() {
		return Selection.activeTransform != null;
	}
}
