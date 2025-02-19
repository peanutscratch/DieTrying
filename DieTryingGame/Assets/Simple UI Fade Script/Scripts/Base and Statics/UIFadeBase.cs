using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ScoredProductions.UIFade {

	[DisallowMultipleComponent]
	public abstract class UIFadeBase : MonoBehaviour {

		[Tooltip("Speed the item fades.")]
		[Header("Item Fade Speed.")]
		public float Speed = 1;

		[Tooltip("Fade animation to perform when enabled or when the scene is loaded.")]
		[Header("Starting Fade Operation")]
		public FadeStates FadeOnStart = FadeStates.No_Action;

		[Header("Fade Complete Event")]
		public UnityEvent OnProcessComplete;

		public enum FadeStates {
			FadeOut,
			FadeIn,
			No_Action
		}

		/// <summary>
		/// Value to identify when the script is currently working
		/// </summary>
		public bool Processing { get; protected set; }

		/// <summary>
		/// Current fade state
		/// </summary>
		public FadeStates CurrentState { get; protected set; } = FadeStates.No_Action;

		protected IEnumerator<bool> task;

		protected Color OriginalColour;

		// Start is called before the first frame update
		private void Start() {
			UIFadeScript.RegisterObject(this);

			this.OnEnable();
		}

		public abstract void Awake();

		public abstract void OnEnable();

		public abstract void FadeIn();

		public abstract void FadeOut();

		public void ToggleFade() {
			switch (this.CurrentState) {
				case FadeStates.FadeOut:
					this.FadeIn();
					break;
				case FadeStates.FadeIn:
					this.FadeOut();
					break;
			}
		}

		protected IEnumerator CheckProcessing() {
			while (this.task != null && !this.task.Current) {
				this.Processing = true;
				yield return null;
			}

			this.Processing = false;
			this.task = null;
			this.OnProcessComplete.Invoke();
		}

		#region ### OnEnabled ###

		protected void InititateOnEnable(SpriteRenderer SpriteRendererObject) {
			if (SpriteRendererObject != null) {
				SpriteRendererObject.color = this.ProcessOnEnable(SpriteRendererObject.color);
			}
		}

		protected void InititateOnEnable(Graphic GraphicObject) {
			if (GraphicObject != null) {
				GraphicObject.color = this.ProcessOnEnable(GraphicObject.color);
			}
		}

		private Color ProcessOnEnable(Color color) {
			if (this.OriginalColour == Color.clear) {
				if (color != null) {
					this.OriginalColour = color;
				} else {
					return Color.clear;
				}
			}

			switch (this.FadeOnStart) {
				case FadeStates.FadeIn:
					this.FadeIn();
					this.CurrentState = FadeStates.FadeIn;
					break;
				case FadeStates.FadeOut:
					if (color != null) {
						color = Color.clear;
						this.CurrentState = FadeStates.FadeOut;
					}
					break;
			}

			return color;
		}

		#endregion

		#region ### Fade Out ###

		protected void InitiateFadeOut(SpriteRenderer SpriteRendererObject) {
			if (UIFadeScript.GlobalLock || this.Processing) {
				return;
			}

			this.CurrentState = FadeStates.FadeOut;

			if (SpriteRendererObject != null && SpriteRendererObject.enabled) {
				this.OriginalColour = SpriteRendererObject.color;
				this.StartCoroutine(this.task = UIFadeScript.FadeImage(SpriteRendererObject, this.OriginalColour, true, this.Speed));
				this.StartCoroutine(this.CheckProcessing());
			}
		}

		protected void InitiateFadeOut(Graphic GraphicObject) {
			if (UIFadeScript.GlobalLock || this.Processing) {
				return;
			}

			this.CurrentState = FadeStates.FadeOut;

			if (GraphicObject != null && GraphicObject.enabled) {
				this.OriginalColour = GraphicObject.color;
				this.StartCoroutine(this.task = UIFadeScript.FadeImage(GraphicObject, this.OriginalColour, true, this.Speed));
				this.StartCoroutine(this.CheckProcessing());
			}
		}

		#endregion

		#region ### Fade In ###

		protected void InitiateFadeIn(SpriteRenderer SpriteRendererObject) {
			if (UIFadeScript.GlobalLock || this.Processing) {
				return;
			}

			this.CurrentState = FadeStates.FadeIn;

			if (SpriteRendererObject != null && SpriteRendererObject.enabled) {
				this.StartCoroutine(this.task = UIFadeScript.FadeImage(SpriteRendererObject, this.OriginalColour, false, this.Speed));
				this.StartCoroutine(this.CheckProcessing());
			}
		}

		protected void InitiateFadeIn(Graphic GraphicObject) {
			if (UIFadeScript.GlobalLock || this.Processing) {
				return;
			}

			this.CurrentState = FadeStates.FadeIn;

			if (GraphicObject != null && GraphicObject.enabled) {
				this.StartCoroutine(this.task = UIFadeScript.FadeImage(GraphicObject, this.OriginalColour, false, this.Speed));
				this.StartCoroutine(this.CheckProcessing());
			}
		}

		#endregion
	}
}