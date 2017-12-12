using UnityEngine;

namespace UI
{
	public class BackButton : MonoBehaviour {
		public GameObject helpScreen;
		public GameObject mainScreen;
	
		public void OnClick()
		{
			helpScreen.SetActive(false);
			mainScreen.SetActive(true);
		}
	}
}
