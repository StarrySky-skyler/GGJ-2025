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

        private SeasonTye _currentSeason;

        /// <summary>
        /// 添加天气
        /// </summary>
        /// <param name="weatherType"></param>
        /// <param name="duration">持续时间</param>
        public void AddWeather(WeatherType weatherType, float duration)
        {
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
                        WeatherHandler.HandleWeather(weather);
                    }

                    break;
                case NotifyCollectionChangedAction.Remove:
                    // TODO: 移除天气逻辑
                    break;
                case NotifyCollectionChangedAction.Reset:
                    // TODO: 重置天气逻辑，调用Clear方法触发
                    break;
                default:
                    break;
            }
        }

        private void Awake()
        {
            Instance = this;
            // 注册事件
            OnSeasonChanged += WeatherHandler.HandleSeason;
            CurrentWeathers.CollectionChanged += OnCurrentWeatherChanged;
            // 初始化天气
            CurrentSeason = SeasonTye.Spring;
            CurrentWeathers = new ObservableCollection<WeatherType>();
        }
    }
}
