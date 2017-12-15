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

                attributes.Speed,
                attributes.Mass,
                attributes.Size_x,
                attributes.Size_y,
                attributes.Size_z,
				attributes.Bounciness,
				attributes.Fear,
                attributes.Cohesion,

                attributes.Push_strength,
				attributes.Push_delay,
                attributes.Jump_strength,
                attributes.Jump_delay,
                attributes.Color

        };
			gameObject.GetComponentInChildren<AttributeList>().Init(values, maxValue);
		}
	}
}
