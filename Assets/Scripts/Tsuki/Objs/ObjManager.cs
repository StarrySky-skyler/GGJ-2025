// ********************************************************************************
// @author: Starry Sky
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/01/18 18:01
// @version: 1.0
// @description:
// ********************************************************************************

using System;
using System.Collections;
using Tsuki.Managers;
using Tsuki.Weather;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Tsuki.Objs
{
    public class ObjManager : MonoBehaviour
    {
        public static ObjManager Instance { get; private set; }

        public bool AllowSpawnHurricane { get; set; }       // 是否生成飓风
        public bool AllowSpawnHail { get; set; }        // 是否生成冰雹
        public bool AllowSpawnLightning { get; set; }       // 是否生成闪电

        [Header("预制体")] 
        public GameObject flower;
        public GameObject leaf;
        public GameObject snow;
        public GameObject hurricane;
        public GameObject hail;
        public GameObject lightning;
        
        [Header("配置数据")]
        [Range(1F, 10F)]
        public float spawnInterval;     // 季节特性物生成间隔
        
        private float _timer;
        
        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            StartCoroutine(DelaySpawnHurricane());
            StartCoroutine(DelaySpawnHail());
            StartCoroutine(DelaySpawnLightning());
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

        private IEnumerator DelaySpawnHurricane()
        {
            while (true)
            {
                if (!AllowSpawnHurricane)
                {
                    yield return null;
                    continue;
                }
                SpawnHurricane();
                yield return new WaitForSeconds(WeatherManager.Instance.WeatherData.hurricaneSpawnInterval);
            }
        }

        private IEnumerator DelaySpawnHail()
        {
            while (true)
            {
                if (!AllowSpawnHail)
                {
                    yield return null;
                    continue;
                }
                SpawnHail();
                yield return new WaitForSeconds(WeatherManager.Instance.WeatherData.hailSpawnInterval);
            }
        }

        private IEnumerator DelaySpawnLightning()
        {
            while (true)
            {
                if (!AllowSpawnLightning)
                {
                    yield return null;
                    continue;
                }
                SpawnLightning();
                yield return new WaitForSeconds(WeatherManager.Instance.WeatherData.lightningSpawnInterval);
            }
        }

        /// <summary>
        /// 获取屏幕右上角随机位置
        /// </summary>
        /// <param name="isPick">是否为季节特征物</param>
        /// <returns></returns>
        private static Vector3 GetScreenRandomPos(bool isPick=true)
        {
            float screenWidth = Screen.width;
            float screenHeight = Screen.height;
            if (isPick)
            {
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
            else
            {
                var randomPos = new Vector3(screenWidth, Random.Range(0, screenHeight), 0);
                randomPos = Camera.main.ScreenToWorldPoint(randomPos);
                randomPos.z = 0;
                return randomPos;
            }
        }

        private static Vector3 GetRandomPos()
        {
            float screenWidth = Screen.width;
            float screenHeight = Screen.height;
            var randomPos = new Vector3(Random.Range(0, screenWidth), Random.Range(0, screenHeight), 0);
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

        /// <summary>
        /// 生成落叶
        /// </summary>
        private void SpawnLeaf()
        {
            Vector3 pos = GetScreenRandomPos();
            Instantiate(leaf, pos, Quaternion.identity);
        }

        /// <summary>
        /// 生成雪花
        /// </summary>
        private void SpawnSnow()
        {
            Vector3 pos = GetScreenRandomPos();
            Instantiate(snow, pos, Quaternion.identity);
        }

        /// <summary>
        /// 生成飓风
        /// </summary>
        private void SpawnHurricane()
        {
            Vector3 pos = GetScreenRandomPos(false);
            Instantiate(hurricane, pos, Quaternion.identity);
            AudioManager.Instance.PlaySoundEffects(WeatherType.Hurricane);
        }

        private void SpawnHail()
        {
            Vector3 pos = GetScreenRandomPos();
            Instantiate(hail, pos, Quaternion.identity);
        }

        private void SpawnLightning()
        {
            Vector3 pos = GetRandomPos();
            Instantiate(lightning, pos, Quaternion.identity);
            AudioManager.Instance.PlaySoundEffects(WeatherType.Lightning);
        }
    }
}
