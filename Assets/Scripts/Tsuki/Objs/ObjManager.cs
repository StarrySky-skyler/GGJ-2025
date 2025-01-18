// ********************************************************************************
// @author: Starry Sky
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/01/18 18:01
// @version: 1.0
// @description:
// ********************************************************************************

using Tsuki.Weather;
using UnityEngine;

namespace Tsuki.Objs
{
    public class ObjManager : MonoBehaviour
    {
        public static ObjManager Instance { get; private set; }

        public bool AllowSpawnHurricane { get; set; } // 是否生成飓风
        public bool AllowSpawnHail { get; set; } // 是否生成冰雹
        public bool AllowSpawnLightning { get; set; } // 是否生成闪电

        [Header("预制体")] public GameObject flower;
        public GameObject leaf;
        public GameObject snow;
        public GameObject hurricane;
        public GameObject hail;
        public GameObject lightning;
        public GameObject fengChe;

        [Header("配置数据")] [Range(1F, 10F)] public float spawnInterval; // 季节特性物生成间隔
        [Range(1F, 10F)] public float fengCheSpawnInterval; // 风车生成间隔

        private float _timer;
        private RandomPos _randomPos;
        private ObjSpawner _objSpawner;

        private void Awake()
        {
            Instance = this;
            _randomPos = new RandomPos(this);
            _objSpawner = new ObjSpawner(this, _randomPos);
        }

        private void Start()
        {
            StartCoroutine(_objSpawner.DelaySpawnHurricane());
            StartCoroutine(_objSpawner.DelaySpawnHail());
            StartCoroutine(_objSpawner.DelaySpawnLightning());
            StartCoroutine(_objSpawner.DelaySpawnFengChe());
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
                        _objSpawner.SpawnFlower();
                        break;
                    case SeasonType.Summer:
                        break;
                    case SeasonType.Autumn:
                        _objSpawner.SpawnLeaf();
                        break;
                    case SeasonType.Winter:
                        _objSpawner.SpawnSnow();
                        break;
                }
            }
        }
    }
}
