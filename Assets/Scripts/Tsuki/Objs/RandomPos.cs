// ********************************************************************************
// @author: Starry Sky
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/01/18 23:01
// @version: 1.0
// @description:
// ********************************************************************************

using UnityEngine;

namespace Tsuki.Objs
{
    public class RandomPos
    {
        private ObjManager _objManager;
        private float _screenWidth = Screen.width;
        private float _screenHeight = Screen.height;

        public RandomPos(ObjManager objManager)
        {
            _objManager = objManager;
        }

        /// <summary>
        /// 获取屏幕右上角随机位置
        /// </summary>
        /// <param name="isPick">是否为季节特征物</param>
        /// <returns></returns>
        public Vector3 GetScreenRandomRightTopPos()
        {
            int edge = Random.Range(0, 2); // 0为上边缘，1为右边缘
            Vector3 randomPos = edge switch
            {
                0 => new Vector3(Random.Range(_screenWidth / 2, _screenWidth), _screenHeight, 0),
                1 => new Vector3(_screenWidth, Random.Range(_screenHeight / 2, _screenHeight), 0),
                _ => Vector3.zero
            };
            randomPos = Camera.main.ScreenToWorldPoint(randomPos);
            randomPos.z = 0;
            return randomPos;
        }

        /// <summary>
        /// 获取屏幕右边随机点
        /// </summary>
        /// <returns></returns>
        public Vector3 GetRandomRightPos()
        {
            var randomPos = new Vector3(_screenWidth, Random.Range(0, _screenHeight), 0);
            randomPos = Camera.main.ScreenToWorldPoint(randomPos);
            randomPos.z = 0;
            return randomPos;
        }

        /// <summary>
        /// 获取屏幕右半部分顶部随机点
        /// </summary>
        /// <returns></returns>
        public Vector3 GetRandomRightHalfTopPos()
        {
            var randomPos = new Vector3(_screenWidth, Random.Range(_screenHeight / 2, _screenHeight), 0);
            randomPos = Camera.main.ScreenToWorldPoint(randomPos);
            randomPos.z = 0;
            return randomPos;
        }

        /// <summary>
        /// 获取顶部随机点
        /// </summary>
        /// <returns></returns>
        public Vector3 GetRandomTopPos()
        {
            var randomPos = new Vector3(Random.Range(0, _screenWidth), _screenHeight, 0);
            randomPos = Camera.main.ScreenToWorldPoint(randomPos);
            randomPos.z = 0;
            return randomPos;
        }
        
        /// <summary>
        /// 获取全屏随机点
        /// </summary>
        /// <returns></returns>
        public Vector3 GetRandomPos()
        {
            float screenWidth = Screen.width;
            float screenHeight = Screen.height;
            var randomPos = new Vector3(Random.Range(0, screenWidth), Random.Range(0, screenHeight), 0);
            randomPos = Camera.main.ScreenToWorldPoint(randomPos);
            randomPos.z = 0;
            return randomPos;
        }
    }
}
