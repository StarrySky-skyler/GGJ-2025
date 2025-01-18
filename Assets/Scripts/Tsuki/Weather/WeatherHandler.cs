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
using UnityEngine;

namespace Tsuki.Weather
{
    public static class WeatherHandler
    {
        /// <summary>
        /// 处理天气
        /// </summary>
        /// <param name="weatherType"></param>
        public static void HandleWeather(WeatherType weatherType)
        {
            switch (weatherType)
            {
                case WeatherType.Sunny:
                    Debug.Log("处理晴天");
                    break;
                case WeatherType.Hurricane:
                    Debug.Log("处理飓风天气");
                    break;
                case WeatherType.Rainy:
                    Debug.Log("处理雨天");
                    break;
                case WeatherType.Fog:
                    Debug.Log("处理雾霾天气");
                    break;
                case WeatherType.Lightning:
                    Debug.Log("处理雷电天气");
                    break;
                case WeatherType.Hail:
                    Debug.Log("处理冰雹天气");
                    break;
                default:
                    Debug.LogError($"未知天气类型{weatherType.ToString()}");
                    break;
            }
        }

        /// <summary>
        /// 处理季节
        /// </summary>
        /// <param name="seasonType"></param>
        public static void HandleSeason(SeasonTye seasonType)
        {
            switch (seasonType)
            {
                case SeasonTye.Spring:
                    Debug.Log("季节切换为春天");
                    break;
                case SeasonTye.Summer:
                    Debug.Log("季节切换为夏天");
                    break;
                case SeasonTye.Autumn:
                    Debug.Log("季节切换为秋天");
                    break;
                case SeasonTye.Winter:
                    Debug.Log("季节切换为冬天");
                    break;
                default:
                    Debug.LogError($"未知的季节类型{seasonType}");
                    break;
            }
        }
    }
}
