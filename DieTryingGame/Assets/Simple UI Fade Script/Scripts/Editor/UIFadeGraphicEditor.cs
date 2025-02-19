#if UNITY_EDITOR
namespace ScoredProductions.UIFade.Editor {
	using UnityEditor;
	using UnityEngine;

	[CustomEditor(typeof(UIFadeGraphic))]
	[CanEditMultipleObjects]
	public class UIFadeGraphicEditor : Editor {
		public override void OnInspectorGUI() {
			this.DrawDefaultInspector();

			UIFadeGraphic myScript = (UIFadeGraphic)this.target;

			switch (myScript.CurrentState) {
				case UIFadeBase.FadeStates.FadeIn:
					GUILayout.Label("Current State: Faded In");
					break;
				case UIFadeBase.FadeStates.FadeOut:
					GUILayout.Label("Current State: Faded Out");
					break;
			}
			if (myScript.Processing) {
				GUILayout.Label("Currently Processing");
			}
		}
	}
}
#endif