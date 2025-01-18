// ********************************************************************************
// @author: Starry Sky
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/01/18 12:01
// @version: 1.0
// @description:
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
        ObservableCollection<WeatherType> CurrentWeathers { get; }
        SeasonTye CurrentSeason { get; set; }
        [CanBeNull] Action<SeasonTye> OnSeasonChanged { get; set; }
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
