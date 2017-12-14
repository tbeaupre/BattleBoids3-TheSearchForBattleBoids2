using System.Collections.Generic;
using UnityEngine;

namespace UI.BoidList
{
	public class AttributeList : MonoBehaviour
	{
		public GameObject attributeBarPrefab;
		
		public void Init(List<float> attributes, float maxValue)
		{
			foreach (float value in attributes)
			{
				GameObject bar = Instantiate(attributeBarPrefab);
				bar.transform.SetParent(transform);
				bar.GetComponentInChildren<AttributeBar>().Init(value, maxValue);
			}
		}
	}
}
