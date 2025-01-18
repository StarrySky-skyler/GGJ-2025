// ********************************************************************************
// @author: Starry Sky
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/01/18 11:01
// @version: 1.0
// @description:
// ********************************************************************************

using System;
using System.Collections;
using Tsuki.Weather;
using UnityEngine;

namespace Tsuki.Managers
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }

        /// <summary>
        /// 分数
        /// </summary>
        public int score;

        private void Awake()
        {
            Instance = this;
            // 限制最高帧率
            Application.targetFrameRate = 160;
        }

        private void Start()
        {
            WeatherManager.Instance.SetWeatherSunny();
            WeatherManager.Instance.CurrentSeason = SeasonTye.Spring;
            StartCoroutine(SwitchSeason());
        }

        private IEnumerator SwitchSeason()
        {
            while (true)
            {
                // 等待季节时间
                yield return new WaitForSeconds(WeatherManager.Instance.seasonDuration);
                // 切换季节
                WeatherManager.Instance.CurrentSeason = WeatherManager.Instance.CurrentSeason switch
                {
                    SeasonTye.Spring => SeasonTye.Summer,
                    SeasonTye.Summer => SeasonTye.Autumn,
                    SeasonTye.Autumn => SeasonTye.Winter,
                    SeasonTye.Winter => SeasonTye.Spring,
                    _ => WeatherManager.Instance.CurrentSeason
                };
            }
        }
    }
}
