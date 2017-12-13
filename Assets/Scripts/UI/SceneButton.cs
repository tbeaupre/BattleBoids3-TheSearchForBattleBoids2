using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
	public class SceneButton : Button
	{
		[SerializeField] private string target;

		public override void OnClick()
		{
			SceneManager.LoadScene(target);
		}
	}
}
