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
                case WeatherType.Hurricane:
                    Debug.Log("处理飓风天气");
                    break;
                case WeatherType.Rainy:
                    Debug.Log("处理雨天");
                    // TODO: 使向上操作变得困难，按两次w等价于一次w
                    break;
                case WeatherType.Fog:
                    Debug.Log("处理雾霾天气");
                    // TODO: 使整个画面模糊
                    break;
                case WeatherType.Lightning:
                    Debug.Log("处理雷电天气");
                    // TODO: 范围伤害
                    break;
                case WeatherType.Hail:
                    Debug.Log("处理冰雹天气");
                    // TODO: 单体伤害
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
