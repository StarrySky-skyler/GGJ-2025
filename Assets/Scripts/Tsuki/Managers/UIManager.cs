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
        public Text txtScore;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            // 注册事件
            WeatherManager.Instance.OnSeasonChanged += UpdateSeasonUI;
            GameManager.Instance.OnScoreChanged += UpdateScoreUI;
        }

        private void Update()
        {
            UpdateWeatherUI();
        }

        /// <summary>
        /// 更新季节UI
        /// </summary>
        /// <param name="season"></param>
        private void UpdateSeasonUI(Season_SO season)
        {
            txtSeason.text = "当前季节：";
            switch (season.season)
            {
                case SeasonType.Spring:
                    txtSeason.text += "春";
                    break;
                case SeasonType.Summer:
                    txtSeason.text += "夏";
                    break;
                case SeasonType.Autumn:
                    txtSeason.text += "秋";
                    break;
                case SeasonType.Winter:
                    txtSeason.text += "冬";
                    break;
            }
        }

        /// <summary>
        /// 更新天气UI
        /// </summary>
        private void UpdateWeatherUI()
        {
            txtWeather.text = "天气预报";
            if (WeatherManager.Instance.CurrentWeathers.Count == 0) txtWeather.text += "\n晴天";
            else
            {
                foreach (WeatherType weather in WeatherManager.Instance.CurrentWeathers)
                {
                    switch (weather)
                    {
                        case WeatherType.Hurricane:
                            txtWeather.text += "\n飓风";
                            break;
                        case WeatherType.Rainy:
                            txtWeather.text += "\n雨天";
                            break;
                        case WeatherType.Fog:
                            txtWeather.text += "\n大雾";
                            break;
                        case WeatherType.Lightning:
                            txtWeather.text += "\n雷电";
                            break;
                        case WeatherType.Hail:
                            txtWeather.text += "\n冰雹";
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// 更新分数UI
        /// </summary>
        private void UpdateScoreUI(int score)
        {
            txtScore.text = $"当前分数：{score}";
        }
    }
}
