using UnityEngine;

namespace UI
{
	public class NavButton : Button
	{
		public GameObject target;
		public GameObject source;

		public override void OnClick()
		{
			source.SetActive(false);
			target.SetActive(true);
		}
	}
}
