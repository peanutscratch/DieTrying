using UnityEngine;
using UnityEngine.UI;

namespace ScoredProductions.UIFade {

	[RequireComponent(typeof(Graphic))]
	public class UIFadeGraphic : UIFadeBase {

		private Graphic GraphicObject;

		public override void Awake() {
			this.GraphicObject = this.GetComponent<Graphic>();
		}

		public override void OnEnable() {
			this.InititateOnEnable(this.GraphicObject);
		}

		public override void FadeOut() {
			this.InitiateFadeOut(this.GraphicObject);
		}

		public override void FadeIn() {
			this.InitiateFadeIn(this.GraphicObject);
		}
	}
}