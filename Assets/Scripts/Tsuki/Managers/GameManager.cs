// ********************************************************************************
// @author: Starry Sky
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/01/18 11:01
// @version: 1.0
// @description:
// ********************************************************************************

using System;
using System.Collections;
using JetBrains.Annotations;
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
        public int Score
        {
            get => _score;
            set
            {
                _score = value;
                OnScoreChanged?.Invoke(_score);
            }
        }
        
        [CanBeNull] public Action<int> OnScoreChanged;

        private int _score;

        private void Awake()
        {
            Instance = this;
            // 限制最高帧率
            Application.targetFrameRate = 160;
        }

        private void Start()
        {
            WeatherManager.Instance.SetWeatherSunny();
            WeatherManager.Instance.CurrentSeason = Resources.Load<Season_SO>("Configs/Seasons/SpringConfig");
            // 轮换季节
            StartCoroutine(SwitchSeason());
            // 添加天气
            StartCoroutine(AddRandomSeason());
        }

        private IEnumerator SwitchSeason()
        {
            while (true)
            {
                // 等待季节时间
                yield return new WaitForSeconds(WeatherManager.Instance.WeatherData.seasonDuration);
                // 切换季节
                WeatherManager.Instance.CurrentSeason = WeatherManager.Instance.CurrentSeason.season switch
                {
                    SeasonType.Spring => Resources.Load<Season_SO>("Configs/Seasons/SummerConfig"),
                    SeasonType.Summer => Resources.Load<Season_SO>("Configs/Seasons/AutumnConfig"),
                    SeasonType.Autumn => Resources.Load<Season_SO>("Configs/Seasons/WinterConfig"),
                    SeasonType.Winter => Resources.Load<Season_SO>("Configs/Seasons/SpringConfig"),
                    _ => WeatherManager.Instance.CurrentSeason
                };
            }
        }

        private IEnumerator AddRandomSeason()
        {
            while (true)
            {
                yield return new WaitForSeconds(WeatherManager.Instance.WeatherData.weatherAddInterval);
                WeatherType newWeather = WeatherManager.Instance.GetRandomWeather();
                float duration = UnityEngine.Random.Range(3F, 10F);
                switch (newWeather)
                {
                    case WeatherType.Sunny:
                        break;
                    case WeatherType.Hurricane:
                        duration = WeatherManager.Instance.WeatherData.hurricaneDuration;
                        break;
                    case WeatherType.Rainy:
                        duration = WeatherManager.Instance.WeatherData.rainDuration;
                        break;
                    case WeatherType.Fog:
                        duration = WeatherManager.Instance.WeatherData.fogDuration;
                        break;
                    case WeatherType.Lightning:
                        duration = WeatherManager.Instance.WeatherData.lightningDuration;
                        break;
                    case WeatherType.Hail:
                        duration = WeatherManager.Instance.WeatherData.hailDuration;
                        break;
                }

                WeatherManager.Instance.AddWeather(newWeather, duration);
            }
        }
    }
}
