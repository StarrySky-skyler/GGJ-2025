// ********************************************************************************
// @author: Starry Sky
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/01/18 16:01
// @version: 1.0
// @description:
// ********************************************************************************

using UnityEngine;

namespace Tsuki.Weather
{
    [CreateAssetMenu(fileName = "SeasonConfig", menuName = "Weather/New Season Config", order = 1)]
    public class Season_SO : ScriptableObject
    {
        public SeasonType season;
        [Header("各天气概率权重")]
        [Range(0F, 100F)] public int hurricaneWeight; // 飓风权重
        [Range(0F, 100F)] public int rainWeight; // 雨权重
        [Range(0F, 100F)] public int fogWeight;     // 雾霾权重
        [Range(0F, 100F)] public int lightningWeight; // 雷权重
        [Range(0F, 100F)] public int hailWeight; // 冰雹权重

        /// <summary>
        /// 获取总权重
        /// </summary>
        /// <returns></returns>
        public int GetTotalWeight()
        {
            return hurricaneWeight + rainWeight + fogWeight + lightningWeight + hailWeight;
        }
    }
}
