// ********************************************************************************
// @author: Starry Sky
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/01/19 13:01
// @version: 1.0
// @description:
// ********************************************************************************

using UnityEngine;

namespace Tsuki.Objs
{
    /// <summary>
    /// 光线枚举
    /// </summary>
    public enum LightType
    {
        Red = 1,
        Green,
        Blue
    }
    
    public class Light : AutoDestoryObj
    {
        public LightType lightType;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Player")) return;
            // TODO: 玩家获得光线
        }
    }
}
