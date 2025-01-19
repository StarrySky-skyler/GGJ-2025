// ********************************************************************************
// @author: Starry Sky
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/01/19 14:01
// @version: 1.0
// @description:
// ********************************************************************************

using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Tsuki.UI.StartScene
{
    public class UIManager : MonoBehaviour
    {
        public Image imgScreenMask;
        public Image imgCG;

        private void Start()
        {
            imgCG.gameObject.SetActive(false);
        }

        public void BtnPlayClicked()
        {
            imgScreenMask.DOFade(1F, 1F).OnComplete(() =>
            {
                imgCG.gameObject.SetActive(true);
                imgScreenMask.DOFade(0F, 1F).OnComplete(() =>
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                });
            });
        }
    }
}
