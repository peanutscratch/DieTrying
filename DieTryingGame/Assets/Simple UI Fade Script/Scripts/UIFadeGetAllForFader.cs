using UnityEngine;

namespace ScoredProductions.UIFade {

	[ExecuteInEditMode]
	[RequireComponent(typeof(UIFadeGroupFader))]
	public class UIFadeGetAllForFader : MonoBehaviour {
		private UIFadeGroupFader GroupFader;

		void OnValidate() {
			UIFadeGroupFader groupfader = this.GetComponent<UIFadeGroupFader>();
			if (groupfader != null) {
				this.GroupFader = groupfader;
			}
		}

		public void GetAllChildren() {
			this.GroupFader.FadeScripts = this.GetComponentsInChildren<UIFadeBase>();
		}
	}
}