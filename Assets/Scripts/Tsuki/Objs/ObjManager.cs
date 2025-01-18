// ********************************************************************************
// @author: Starry Sky
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/01/18 18:01
// @version: 1.0
// @description:
// ********************************************************************************

using System;
using Tsuki.Weather;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Tsuki.Objs
{
    public class ObjManager : MonoBehaviour
    {
        public static ObjManager Instance { get; private set; }

        [Header("预制体")] 
        public GameObject flower;
        public GameObject leaf;
        public GameObject snow;
        
        [Header("配置数据")]
        [Range(1F, 10F)]
        public float spawnInterval;     // 季节特性物生成间隔
        
        private float _timer;
        
        private void Awake()
        {
            Instance = this;
        }

        private void Update()
        {
            _timer += Time.deltaTime;
            if (_timer >= spawnInterval)
            {
                _timer = 0;
                switch (WeatherManager.Instance.CurrentSeason.season)
                {
                    case SeasonType.Spring:
                        SpawnFlower();
                        break;
                    case SeasonType.Summer:
                        break;
                    case SeasonType.Autumn:
                        SpawnLeaf();
                        break;
                    case SeasonType.Winter:
                        SpawnSnow();
                        break;
                }
            }
        }

        /// <summary>
        /// 获取屏幕右上角随机位置
        /// </summary>
        /// <returns></returns>
        private static Vector3 GetScreenRandomPos()
        {
            float screenWidth = Screen.width;
            float screenHeight = Screen.height;

            int edge = Random.Range(0, 2);      // 0为上边缘，1为右边缘
            Vector3 randomPos = edge switch
            {
                0 => new Vector3(Random.Range(screenWidth / 2, screenWidth), screenHeight, 0),
                1 => new Vector3(screenWidth, Random.Range(screenHeight / 2, screenHeight), 0),
                _ => Vector3.zero
            };
            randomPos = Camera.main.ScreenToWorldPoint(randomPos);
            randomPos.z = 0;
            return randomPos;
        }

        /// <summary>
        /// 生成花瓣
        /// </summary>
        private void SpawnFlower()
        {
            Vector3 pos = GetScreenRandomPos();
            Instantiate(flower, pos, Quaternion.identity);
        }

        private void SpawnLeaf()
        {
            Vector3 pos = GetScreenRandomPos();
            Instantiate(leaf, pos, Quaternion.identity);
        }

        private void SpawnSnow()
        {
            Vector3 pos = GetScreenRandomPos();
            Instantiate(snow, pos, Quaternion.identity);
        }
    }
}
