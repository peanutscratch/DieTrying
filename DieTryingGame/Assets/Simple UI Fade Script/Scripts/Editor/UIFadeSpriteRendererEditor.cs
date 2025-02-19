#if UNITY_EDITOR
namespace ScoredProductions.UIFade.Editor {
	using UnityEditor;
	using UnityEngine;

	[CustomEditor(typeof(UIFadeSpriteRenderer))]
	[CanEditMultipleObjects]
	public class UIFadeSpriteRendererEditor : Editor {
		public override void OnInspectorGUI() {
			this.DrawDefaultInspector();

			UIFadeSpriteRenderer myScript = (UIFadeSpriteRenderer)this.target;

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