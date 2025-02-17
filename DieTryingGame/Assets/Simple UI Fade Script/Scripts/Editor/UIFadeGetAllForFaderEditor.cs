#if UNITY_EDITOR
namespace ScoredProductions.UIFade.Editor {
	using UnityEditor;
	using UnityEngine;

	[CustomEditor(typeof(UIFadeGetAllForFader))]
	public class UIFadeGetAllForFaderEditor : Editor {
		public override void OnInspectorGUI() {
			this.DrawDefaultInspector();

			UIFadeGetAllForFader myScript = (UIFadeGetAllForFader)this.target;
			if (GUILayout.Button("Get Children")) {
				myScript.GetAllChildren();
			}
		}
	}
}
#endif