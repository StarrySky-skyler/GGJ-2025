// ********************************************************************************
// @author: Starry Sky
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/01/19 10:01
// @version: 1.0
// @description:
// ********************************************************************************

using System;
using System.Collections.Generic;
using DG.Tweening;
using Tsuki.Weather;
using UnityEngine;
using UnityEngine.UI;

namespace Tsuki.UI
{
    public class ImgBackground : MonoBehaviour
    {
        public List<Sprite> bgList;
        
        private Image _img;

        private void Awake()
        {
            _img = GetComponent<Image>();
        }

        private void Start()
        {
            WeatherManager.Instance.OnSeasonChanged += ChangeBg;
        }

        private void ChangeBg(Season_SO season)
        {
            _img.DOFade(0, 1f).OnComplete(() =>
            {
                _img.sprite = season.season switch
                {
                    SeasonType.Spring => bgList[0],
                    SeasonType.Summer => bgList[1],
                    SeasonType.Autumn => bgList[2],
                    SeasonType.Winter => bgList[3],
                    _ => _img.sprite
                };
                _img.DOFade(1, 1f);
            });
        }
    }
}
