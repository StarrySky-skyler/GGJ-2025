// ********************************************************************************
// @author: Starry Sky
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/01/18 12:01
// @version: 1.0
// @description: 当前天气季节操作接口
// ********************************************************************************

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using JetBrains.Annotations;

namespace Tsuki.Weather
{
    public interface IWeatherOperate
    {
        Weather_SO WeatherData { get; }
        ObservableCollection<WeatherType> CurrentWeathers { get; }
        Season_SO CurrentSeason { get; set; }
        [CanBeNull] Action<Season_SO> OnSeasonChanged { get; set; }
        [CanBeNull] Action<WeatherType> OnWeatherAdded { get; set; }
        [CanBeNull] Action<WeatherType> OnWeatherRemoved { get; set; }
        [CanBeNull] Action OnWeatherCleared { get; set; }
        /// <summary>
        /// 添加天气
        /// </summary>
        /// <param name="weatherType"></param>
        /// <param name="duration"></param>
        public void AddWeather(WeatherType weatherType, float duration);
        
        /// <summary>
        /// 延时移除天气
        /// </summary>
        /// <param name="weather"></param>
        /// <param name="duration"></param>
        public void RemoveWeather(WeatherType weather, float duration);
        
        /// <summary>
        /// 立即移除天气
        /// </summary>
        /// <param name="weather"></param>
        public void RemoveWeather(WeatherType weather);
        
        /// <summary>
        /// 设置天气为晴天
        /// </summary>
        public void SetWeatherSunny();
    }
}
