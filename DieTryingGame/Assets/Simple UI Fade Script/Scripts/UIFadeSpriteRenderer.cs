using UnityEngine;

namespace ScoredProductions.UIFade {

	[RequireComponent(typeof(SpriteRenderer))]
	public class UIFadeSpriteRenderer : UIFadeBase {

		private SpriteRenderer SpriteRendererObject;

		public override void Awake() {
			this.SpriteRendererObject = this.GetComponent<SpriteRenderer>();
		}

		public override void OnEnable() {
			this.InititateOnEnable(this.SpriteRendererObject);
		}

		public override void FadeOut() {
			this.InitiateFadeOut(this.SpriteRendererObject);
		}

		public override void FadeIn() {
			this.InitiateFadeIn(this.SpriteRendererObject);
		}
	}
}