// ********************************************************************************
// @author: Starry Sky
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/01/18 10:01
// @version: 1.0
// @description: 天气管理器单例
// ********************************************************************************

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using JetBrains.Annotations;
using UnityEngine;

namespace Tsuki.Weather
{
    public class WeatherManager : MonoBehaviour, IWeatherOperate
    {
        public static WeatherManager Instance { get; private set; }

        public Weather_SO WeatherData { get; private set; }

        [Header("预制体")]
        public GameObject fog;      // 雾霾
        public ParticleSystem rain;     // 雨
        
        public ObservableCollection<WeatherType> CurrentWeathers { get; private set; }

        /// <summary>
        /// 当前季节
        /// </summary>
        public Season_SO CurrentSeason
        {
            get => _currentSeason;
            set
            {
                _currentSeason = value;
                OnSeasonChanged?.Invoke(_currentSeason);
            }
        }

        public Action<Season_SO> OnSeasonChanged { get; set; }
        public Action<WeatherType> OnWeatherAdded { get; set; }
        public Action<WeatherType> OnWeatherRemoved { get; set; }
        public Action OnWeatherCleared { get; set; }

        private Season_SO _currentSeason;
        private WeatherHandler _weatherHandler;

        /// <summary>
        /// 获取随机天气
        /// </summary>
        /// <returns></returns>
        public WeatherType GetRandomWeather()
        {
            int totalWeight = CurrentSeason.GetTotalWeight();
            int random = UnityEngine.Random.Range(0, totalWeight);
            var weights = new int[]
            {
                CurrentSeason.hurricaneWeight,
                CurrentSeason.rainWeight,
                CurrentSeason.fogWeight,
                CurrentSeason.lightningWeight,
                CurrentSeason.hailWeight
            };
            int index = -1;
            for (var i = 0; i < 5; i++)
            {
                random -= weights[i];
                if (random > 0) continue;
                index = i;
                break;
            }

            return index switch
            {
                0 => WeatherType.Hurricane,
                1 => WeatherType.Rainy,
                2 => WeatherType.Fog,
                3 => WeatherType.Lightning,
                4 => WeatherType.Hail,
                _ => WeatherType.Sunny
            };
        }
        
        /// <summary>
        /// 添加天气
        /// </summary>
        /// <param name="weatherType"></param>
        /// <param name="duration">持续时间</param>
        public void AddWeather(WeatherType weatherType, float duration)
        {
            if (weatherType == WeatherType.Sunny)
            {
                SetWeatherSunny();
                return;
            }

            CurrentWeathers.Add(weatherType);
            StartCoroutine(DelayRemoveWeather(weatherType, duration));
        }

        /// <summary>
        /// 延时移除天气
        /// </summary>
        /// <param name="weather"></param>
        /// <param name="duration"></param>
        public void RemoveWeather(WeatherType weather, float duration)
        {
            StartCoroutine(DelayRemoveWeather(weather, duration));
        }

        /// <summary>
        /// 立即移除天气
        /// </summary>
        /// <param name="weather"></param>
        public void RemoveWeather(WeatherType weather)
        {
            CurrentWeathers.Remove(weather);
        }

        /// <summary>
        /// 设置为晴天
        /// </summary>
        public void SetWeatherSunny()
        {
            CurrentWeathers.Clear();
        }

        private IEnumerator DelayRemoveWeather(WeatherType weather, float duration)
        {
            yield return new WaitForSeconds(duration);
            CurrentWeathers.Remove(weather);
        }

        private void OnCurrentWeatherChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    foreach (WeatherType weather in e.NewItems)
                    {
                        OnWeatherAdded?.Invoke(weather);
                    }

                    break;
                case NotifyCollectionChangedAction.Remove:
                    foreach (WeatherType weather in e.OldItems)
                    {
                        OnWeatherRemoved?.Invoke(weather);
                    }

                    break;
                case NotifyCollectionChangedAction.Reset:
                    // TODO: 重置天气逻辑，调用Clear方法触发
                    OnWeatherCleared?.Invoke();
                    break;
            }
        }

        private void Awake()
        {
            Instance = this;
            _weatherHandler = new WeatherHandler(Instance);
            // 注册事件
            OnSeasonChanged += _weatherHandler.HandleSeason;
            OnWeatherAdded += _weatherHandler.HandleAddWeather;
            OnWeatherRemoved += _weatherHandler.HandleRemoveWeather;
            // 初始化天气
            CurrentWeathers = new ObservableCollection<WeatherType>();
            fog.SetActive(false);
            rain.Stop();
            WeatherData = Resources.Load<Weather_SO>("Configs/WeatherConfig");
        }

        private void Start()
        {
            // 注册事件
            CurrentWeathers.CollectionChanged += OnCurrentWeatherChanged;
        }
    }
}
