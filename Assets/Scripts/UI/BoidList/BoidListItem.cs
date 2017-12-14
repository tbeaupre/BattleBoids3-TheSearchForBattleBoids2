using System.Collections.Generic;
using UnityEngine;

namespace UI.BoidList
{
	public class BoidListItem : MonoBehaviour
	{
		public BoidAttributes attributes { get; private set; }
		
		public void Init(BoidAttributes attributes, float maxValue)
		{
			this.attributes = attributes;
			List<float> values = new List<float>()
			{
				attributes.Agression,
				attributes.Bounciness,
				attributes.Fear,
				attributes.Mass,
				attributes.Speed,
				attributes.Strength,
				attributes.TurnSpeed
			};
			gameObject.GetComponentInChildren<AttributeList>().Init(values, maxValue);
		}
	}
}
