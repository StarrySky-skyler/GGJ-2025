// ********************************************************************************
// @author: Starry Sky
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/01/19 14:01
// @version: 1.0
// @description:
// ********************************************************************************

using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Tsuki.UI.StartScene
{
    public class UIManager : MonoBehaviour
    {
        public Image imgScreenMask;
        public Image imgCG;
        
        public List<Sprite> listCG;

        private void Start()
        {
            imgCG.gameObject.SetActive(false);
        }

        public void BtnPlayClicked()
        {
            imgScreenMask.DOFade(1F, 1F).OnComplete(() =>
            {
                imgCG.gameObject.SetActive(true);
                imgCG.GetComponent<PlayableDirector>().Play();
            });
        }

        public void LoadNextScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        public void CGReceiver(int index)
        {
            imgCG.sprite = listCG[index];
        }
    }
}
