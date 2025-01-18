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
    public class WeatherHandler
    {
        public WeatherManager SWeatherManager { get; private set; }

        public WeatherHandler(WeatherManager weatherManager)
        {
            SWeatherManager = weatherManager;
        }
        
        /// <summary>
        /// 处理添加天气
        /// </summary>
        /// <param name="weatherType"></param>
        public void HandleAddWeather(WeatherType weatherType)
        {
            switch (weatherType)
            {
                case WeatherType.Hurricane:
                    Debug.Log("处理添加飓风天气");
                    break;
                case WeatherType.Rainy:
                    Debug.Log("处理添加雨天");
                    // TODO: 使向上操作变得困难，按两次w等价于一次w
                    break;
                case WeatherType.Fog:
                    Debug.Log("处理添加雾霾天气");
                    SWeatherManager.fog.SetActive(true);
                    break;
                case WeatherType.Lightning:
                    Debug.Log("处理添加雷电天气");
                    // TODO: 范围伤害
                    break;
                case WeatherType.Hail:
                    Debug.Log("处理添加冰雹天气");
                    // TODO: 单体伤害
                    break;
                default:
                    Debug.LogError($"添加未知天气类型{weatherType.ToString()}");
                    break;
            }
        }

        /// <summary>
        /// 处理移除天气
        /// </summary>
        /// <param name="weatherType"></param>
        public void HandleRemoveWeather(WeatherType weatherType)
        {
            switch (weatherType)
            {
                case WeatherType.Hurricane:
                    Debug.Log("处理移除飓风天气");
                    break;
                case WeatherType.Rainy:
                    Debug.Log("处理移除雨天");
                    // TODO: 使向上操作变得困难，按两次w等价于一次w
                    break;
                case WeatherType.Fog:
                    Debug.Log("处理移除雾霾天气");
                    SWeatherManager.fog.SetActive(false);
                    break;
                case WeatherType.Lightning:
                    Debug.Log("处理移除雷电天气");
                    // TODO: 范围伤害
                    break;
                case WeatherType.Hail:
                    Debug.Log("处理移除冰雹天气");
                    // TODO: 单体伤害
                    break;
                default:
                    Debug.LogError($"移除未知天气类型{weatherType.ToString()}");
                    break;
            }
        }

        /// <summary>
        /// 处理季节
        /// </summary>
        /// <param name="seasonType"></param>
        public void HandleSeason(SeasonTye seasonType)
        {
            switch (seasonType)
            {
                case SeasonTye.Spring:
                    Debug.Log("季节切换为春天");
                    // TODO: 掉落花瓣
                    break;
                case SeasonTye.Summer:
                    Debug.Log("季节切换为夏天");
                    // TODO: 光线产生，改变泡泡技能
                    break;
                case SeasonTye.Autumn:
                    Debug.Log("季节切换为秋天");
                    // TODO: 掉落落叶
                    break;
                case SeasonTye.Winter:
                    Debug.Log("季节切换为冬天");
                    // TODO: 掉落雪花
                    break;
                default:
                    Debug.LogError($"未知的季节类型{seasonType}");
                    break;
            }
        }
    }
}
