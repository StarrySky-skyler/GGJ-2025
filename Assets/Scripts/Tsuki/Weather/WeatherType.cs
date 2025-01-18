// ********************************************************************************
// @author: Starry Sky
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/01/18 10:01
// @version: 1.0
// @description:
// ********************************************************************************

namespace Tsuki.Weather
{
    public enum WeatherType
    {
        /// <summary>
        /// 晴天
        /// </summary>
        Sunny,
        
        /// <summary>
        /// 飓风，区域操作反向
        /// </summary>
        Hurricane,
        
        /// <summary>
        /// 雨天，给一个向下的力，使向上移动变得困难（两次w等价于先前一次w）
        /// </summary>
        Rainy,
        
        /// <summary>
        /// 雾霾，使整个画面模糊
        /// </summary>
        Fog,
        
        /// <summary>
        /// 闪电，范围伤害
        /// </summary>
        Lightning,
        
        /// <summary>
        /// 冰雹，单体伤害
        /// </summary>
        Hail
    }

    public enum SeasonTye
    {
        /// <summary>
        /// 春天，掉落花瓣
        /// </summary>
        Spring,
        
        /// <summary>
        /// 夏天，光线产生，改变泡泡技能
        /// </summary>
        Summer,
        
        /// <summary>
        /// 秋天，掉落落叶
        /// </summary>
        Autumn,
        
        /// <summary>
        /// 冬天，掉落雪花
        /// </summary>
        Winter
    }
}
