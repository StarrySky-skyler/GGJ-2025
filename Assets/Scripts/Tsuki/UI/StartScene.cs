// ********************************************************************************
// @author: Starry Sky
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/01/19 14:01
// @version: 1.0
// @description:
// ********************************************************************************

using UnityEngine;
using UnityEngine.SceneManagement;

namespace Tsuki.UI
{
    public class StartScene : MonoBehaviour
    {
        public void BtnPlayClicked()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
