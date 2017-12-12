using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class StartButton : MonoBehaviour
    {
        public void OnClick()
        {
            SceneManager.LoadScene("battle");
        }
    }
}
