// ********************************************************************************
// @author: Starry Sky
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/01/18 18:01
// @version: 1.0
// @description:
// ********************************************************************************

using Tsuki.Weather;
using UnityEngine;
using System.Collections.Generic;

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
        public List<GameObject> hail;
        public GameObject lightning;
        public GameObject fengChe;
        public GameObject tengWan;
        public GameObject bird;
        public GameObject fish;
        public List<GameObject> rabbit;
        public GameObject songShu;
        public GameObject springBush;
        public GameObject summerBush;
        public GameObject autumnBush;
        public GameObject winterBush;

        [Header("配置数据")] [Range(1F, 10F)] public float spawnInterval; // 季节特性物生成间隔
        [Range(1F, 10F)] public float fengCheSpawnInterval; // 风车生成间隔
        [Range(1F, 10F)] public float tengWanSpawnInterval; // 藤蔓生成间隔
        [Range(1F, 10F)] public float birdSpawnInterval; // 鸟生成间隔
        [Range(1F, 10F)] public float fishSpawnInterval; // 鱼生成间隔
        [Range(1F, 10F)] public float rabbitSpawnInterval; // 兔生成间隔
        [Range(1F, 10F)] public float songShuSpawnInterval; // 松鼠生成间隔
        [Range(1F, 10F)] public float bushSpawnInterval; // 灌木丛生成间隔

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
            StartCoroutine(_objSpawner.DelaySpawn(fengCheSpawnInterval, _objSpawner.SpawnFengChe));
            StartCoroutine(_objSpawner.DelaySpawn(tengWanSpawnInterval, _objSpawner.SpawnTengWan));
            StartCoroutine(_objSpawner.DelaySpawn(birdSpawnInterval, _objSpawner.SpawnBird));
            StartCoroutine(_objSpawner.DelaySpawn(fishSpawnInterval, _objSpawner.SpawnFish));
            StartCoroutine(_objSpawner.DelaySpawn(rabbitSpawnInterval, _objSpawner.SpawnRabbit));
            StartCoroutine(_objSpawner.DelaySpawn(songShuSpawnInterval, _objSpawner.SpawnSongShu));
            StartCoroutine(_objSpawner.DelaySpawn(bushSpawnInterval, _objSpawner.SpawnBush));
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
