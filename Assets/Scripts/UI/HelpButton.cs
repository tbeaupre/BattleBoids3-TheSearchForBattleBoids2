using UnityEngine;

namespace UI
{
	public class HelpButton : MonoBehaviour
	{
		public GameObject mainScreen;
		public GameObject helpScreen;
	
		public void OnClick()
		{
			mainScreen.SetActive(false);
			helpScreen.SetActive(true);
		}
	}
}
