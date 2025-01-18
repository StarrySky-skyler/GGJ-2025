// ********************************************************************************
// @author: Starry Sky
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/01/18 15:01
// @version: 1.0
// @description:
// ********************************************************************************

using UnityEngine;

namespace Tsuki.Weather
{
    [CreateAssetMenu(fileName = "WeatherConfig", menuName = "Weather/New Weather Config", order = 0)]
    public class Weather_SO : ScriptableObject
    {
        [Header("配置数据")]
        public float lightningWarningTime; // 闪电预警时间
        [Range(0.1F, 10F)]
        public float hailSpeed;     // 冰雹下落速度
        [Header("持续时间")]
        [Range(1F, 10F)] public float hurricaneDuration;     // 风持续时间
        [Range(1F, 10F)] public float rainDuration;     // 雨持续时间
        [Range(1F, 10F)] public float fogDuration;     // 雾持续时间
        [Range(1F, 10F)] public float lightningDuration;     // 雷持续时间
        [Range(1F, 10F)] public float hailDuration;     // 冰雹持续时间
        [Range(3F, 30F)] public float seasonDuration;       // 季节持续时间
        [Header("天气添加间隔")]
        [Range(1F, 10F)] public float weatherAddInterval;       // 天气添加间隔

        [Header("各季节数据")]
        public Season_SO springData;
        public Season_SO summerData;
        public Season_SO autumnData;
        public Season_SO winterData;
    }
}
