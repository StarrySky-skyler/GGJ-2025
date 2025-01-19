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
        public Text txtScore;
        public GameObject clockPointer;

        private float _timer;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            // 注册事件
            GameManager.Instance.OnScoreChanged += UpdateScoreUI;
        }

        private void Update()
        {
            _timer += Time.deltaTime;
            if (_timer >= WeatherManager.Instance.WeatherData.seasonDuration * 4) _timer = 0;
            UpdateWeatherUI();
            UpdateSeasonUI();
        }

        /// <summary>
        /// 更新季节UI
        /// </summary>
        /// <param name="season"></param>
        private void UpdateSeasonUI()
        {
            float p = WeatherManager.Instance.WeatherData.seasonDuration * 4;
            p = _timer / p;
            p *= 360;
            clockPointer.transform.localRotation = Quaternion.Euler(0, 0, p);
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
