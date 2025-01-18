// ********************************************************************************
// @author: Starry Sky
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/01/18 11:01
// @version: 1.0
// @description:
// ********************************************************************************

using System;
using Tsuki.Weather;
using UnityEngine;
using UnityEngine.UI;

namespace Tsuki.Managers
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager Instance { get; private set; }

        [Header("UI配置")] public Text txtWeather;
        public Text txtSeason;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            // 注册事件
            WeatherManager.Instance.OnSeasonChanged += UpdateSeasonUI;
        }

        private void Update()
        {
            UpdateWeatherUI();
        }

        /// <summary>
        /// 更新季节UI
        /// </summary>
        /// <param name="season"></param>
        private void UpdateSeasonUI(SeasonTye season)
        {
            txtSeason.text = "当前季节：";
            switch (season)
            {
                case SeasonTye.Spring:
                    txtSeason.text += "春";
                    break;
                case SeasonTye.Summer:
                    txtSeason.text += "夏";
                    break;
                case SeasonTye.Autumn:
                    txtSeason.text += "秋";
                    break;
                case SeasonTye.Winter:
                    txtSeason.text += "冬";
                    break;
            }
        }

        /// <summary>
        /// 更新天气UI
        /// </summary>
        private void UpdateWeatherUI()
        {
            txtWeather.text = "天气预报：接下来预计是\n";
            if (WeatherManager.Instance.CurrentWeathers.Count == 0) txtWeather.text += "晴天";
            else
            {
                foreach (WeatherType weather in WeatherManager.Instance.CurrentWeathers)
                {
                    switch (weather)
                    {
                        case WeatherType.Hurricane:
                            txtWeather.text += " 飓风";
                            break;
                        case WeatherType.Rainy:
                            txtWeather.text += " 雨天";
                            break;
                        case WeatherType.Fog:
                            txtWeather.text += " 大雾";
                            break;
                        case WeatherType.Lightning:
                            txtWeather.text += " 雷电";
                            break;
                        case WeatherType.Hail:
                            txtWeather.text += " 冰雹";
                            break;
                    }
                }
            }
        }
    }
}
