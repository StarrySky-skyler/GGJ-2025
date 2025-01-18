// ********************************************************************************
// @author: Starry Sky
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/01/18 10:01
// @version: 1.0
// @description:
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

        public GameObject fog;      // 雾霾
        
        public ObservableCollection<WeatherType> CurrentWeathers { get; private set; }

        /// <summary>
        /// 当前季节
        /// </summary>
        public SeasonTye CurrentSeason
        {
            get => _currentSeason;
            set
            {
                if (_currentSeason == value) return;
                _currentSeason = value;
                OnSeasonChanged?.Invoke(_currentSeason);
            }
        }

        public Action<SeasonTye> OnSeasonChanged { get; set; }
        public Action<WeatherType> OnWeatherAdded { get; set; }
        public Action<WeatherType> OnWeatherRemoved { get; set; }
        public Action OnWeatherCleared { get; set; }

        private SeasonTye _currentSeason;
        private WeatherHandler _weatherHandler;

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
            CurrentSeason = SeasonTye.Spring;
            CurrentWeathers = new ObservableCollection<WeatherType>();
            fog.SetActive(false);
        }

        private void Start()
        {
            // 注册事件
            CurrentWeathers.CollectionChanged += OnCurrentWeatherChanged;
        }
    }
}
