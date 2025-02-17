using System.Collections;

using UnityEngine;

namespace ScoredProductions.UIFade {

	public class UIFadeSingleton : MonoBehaviour {

		public void StartManageAllFadeOut() => this.StartCoroutine(this.ManageAllFadeOut());
		private IEnumerator ManageAllFadeOut() {
			UIFadeScript.GlobalLock = true;
			while (!UIFadeScript.AllFadedOut) {
				yield return null;
			}
			UIFadeScript.GlobalLock = false;
		}

		public void StartManageAllFadeIn() => this.StartCoroutine(this.ManageAllFadeIn());
		private IEnumerator ManageAllFadeIn() {
			UIFadeScript.GlobalLock = true;
			while (!UIFadeScript.AllFadedIn) {
				yield return null;
			}
			UIFadeScript.GlobalLock = false;
		}
	}

}
