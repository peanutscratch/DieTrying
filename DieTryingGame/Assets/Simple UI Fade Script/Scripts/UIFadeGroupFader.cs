using System.Collections.Generic;


using UnityEngine;
using UnityEngine.Events;

namespace ScoredProductions.UIFade {

	public class UIFadeGroupFader : MonoBehaviour {

		[Tooltip("The fader will not initiate any fade while any of the listed faders are processing.")]
		public bool WaitForProcessing = false;

		public UIFadeBase[] FadeScripts;

		[Header("Fade Complete Event")]
		public UnityEvent OnProcessComplete;

		public bool AllFadedOut => this.AllOfState(UIFadeBase.FadeStates.FadeOut);

		public bool AllFadedIn => this.AllOfState(UIFadeBase.FadeStates.FadeIn);

		public bool AnyProcessing => this.AnyFadesProcessing();

		protected IEnumerator<bool> task;

		private bool AllOfState(UIFadeBase.FadeStates state) {
			foreach (UIFadeBase fade in this.FadeScripts) { 
				if (fade.isActiveAndEnabled && (fade.Processing || fade.CurrentState != state)) {
					return false;
				}
			}
			return true;
		}

		private bool AnyFadesProcessing() {
			foreach (UIFadeBase fade in this.FadeScripts) {
				if (fade.Processing) {
					return true;
				}
			}
			return false;
		}

		#region ### Fade Toggle ###

		public void FadeAllToggle() {
			if (this.WaitForProcessing && this.AnyProcessing) {
				return;
			}

			if (this.task == null || this.task.Current) {
				this.StartCoroutine(this.task = this.RoutineFadeAllToggle());
			}
		}

		private IEnumerator<bool> RoutineFadeAllToggle() {
			foreach (UIFadeBase x in this.FadeScripts) {
				if (x.isActiveAndEnabled) {
					x.ToggleFade();
				}
			}

			while (this.AnyProcessing) {
				yield return false;
			}

			yield return true;
		}

		#endregion

		#region ### Fade Out ###

		public void FadeAllOut() {
			if (this.WaitForProcessing && this.AnyProcessing) {
				return;
			}

			if (this.task == null || this.task.Current) {
				this.StartCoroutine(this.task = this.RoutineFadeAllOut());
			}
		}

		private IEnumerator<bool> RoutineFadeAllOut() {
			foreach (UIFadeBase x in this.FadeScripts) {
				if (x.isActiveAndEnabled && x.CurrentState == UIFadeBase.FadeStates.FadeIn) {
					x.FadeOut();
				}
			}

			while (this.AnyProcessing) {
				yield return false;
			}

			yield return true;
		}

		#endregion

		#region ### Fade In ###

		public void FadeAllIn() {
			if (this.WaitForProcessing && this.AnyProcessing) {
				return;
			}

			if (this.task == null || this.task.Current) {
				this.StartCoroutine(this.task = this.RoutineFadeAllIn());
			}
		}

		private IEnumerator<bool> RoutineFadeAllIn() {
			foreach (UIFadeBase x in this.FadeScripts) {
				if (x.isActiveAndEnabled && x.CurrentState == UIFadeBase.FadeStates.FadeOut) {
					x.FadeIn();
				}
			}

			while (this.AnyProcessing) {
				yield return false;
			}

			yield return true;
		}

		#endregion

	}
}