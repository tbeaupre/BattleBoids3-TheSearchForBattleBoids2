using System.ComponentModel;
using UnityEngine;

namespace UI.BoidList
{
	public class AttributeBar : MonoBehaviour {
		public void Init(float value, float maxValue)
		{
			RectTransform outer = gameObject.GetComponentInParent<RectTransform>();
			RectTransform inner = gameObject.GetComponent<RectTransform>();
			float max = outer.rect.height;
			
			inner.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, value / maxValue * max);
		}
	}
}
