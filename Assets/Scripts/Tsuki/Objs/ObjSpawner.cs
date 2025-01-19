// ********************************************************************************
// @author: Starry Sky
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/01/18 23:01
// @version: 1.0
// @description:
// ********************************************************************************

using System;
using System.Collections;
using Tsuki.Managers;
using Tsuki.Weather;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace Tsuki.Objs
{
    public class ObjSpawner
    {
        private ObjManager _objManager;
        private RandomPos _randomPos;

        public ObjSpawner(ObjManager objManager, RandomPos randomPos)
        {
            _objManager = objManager;
            _randomPos = randomPos;
        }

        /// <summary>
        /// 生成花瓣
        /// </summary>
        public void SpawnFlower()
        {
            Vector3 pos = _randomPos.GetScreenRandomRightTopPos();
            Object.Instantiate(_objManager.flower, pos, Quaternion.identity);
        }

        /// <summary>
        /// 生成落叶
        /// </summary>
        public void SpawnLeaf()
        {
            Vector3 pos = _randomPos.GetScreenRandomRightTopPos();
            Object.Instantiate(_objManager.leaf, pos, Quaternion.identity);
        }

        /// <summary>
        /// 生成雪花
        /// </summary>
        public void SpawnSnow()
        {
            Vector3 pos = _randomPos.GetScreenRandomRightTopPos();
            Object.Instantiate(_objManager.snow, pos, Quaternion.identity);
        }

        /// <summary>
        /// 生成飓风
        /// </summary>
        public void SpawnHurricane()
        {
            Vector3 pos = _randomPos.GetRandomRightPos();
            Object.Instantiate(_objManager.hurricane, pos, Quaternion.identity);
            AudioManager.Instance.PlaySoundEffects(WeatherType.Hurricane);
        }

        public void SpawnHail()
        {
            Vector3 pos = _randomPos.GetRandomTopPos();
            GameObject h = _objManager.hail[Random.Range(0, _objManager.hail.Count)];
            Object.Instantiate(h, pos, Quaternion.identity);
        }

        public void SpawnLightning()
        {
            Vector3 pos = _randomPos.GetRandomPos();
            Object.Instantiate(_objManager.lightning, pos, Quaternion.identity);
            AudioManager.Instance.PlaySoundEffects(WeatherType.Lightning);
        }

        public void SpawnFengChe()
        {
            Vector3 pos = _randomPos.GetRandomPos();
            Object.Instantiate(_objManager.fengChe, pos, Quaternion.identity);
        }

        public void SpawnTengWan()
        {
            var pos = new Vector3(Screen.width, Screen.height, 0);
            pos = Camera.main.ScreenToWorldPoint(pos);
            pos.z = 0;
            Object.Instantiate(_objManager.tengWan, pos, Quaternion.identity);
        }

        public void SpawnBird()
        {
            Vector3 pos = _randomPos.GetRandomRightHalfTopPos();
            Object.Instantiate(_objManager.bird, pos, Quaternion.identity);
            AudioManager.Instance.PlaySoundEffects(WeatherType.Hurricane);
        }

        public void SpawnFish()
        {
            Vector3 pos = _randomPos.GetRandomFishPos();
            Object.Instantiate(_objManager.fish, pos, Quaternion.identity);
        }

        public void SpawnRabbit()
        {
            Vector3 pos = _randomPos.GetRandomRabbitPos();
            GameObject rabbit = _objManager.rabbit[Random.Range(0, _objManager.rabbit.Count)];
            Object.Instantiate(rabbit, pos, Quaternion.identity);
        }

        public void SpawnSongShu()
        {
            Vector3 pos = _randomPos.GetRandomRabbitPos();
            Object.Instantiate(_objManager.songShu, pos, Quaternion.identity);
        }

        public void SpawnBush()
        {
            Vector3 pos = _randomPos.GetRandomRabbitPos();
            switch (WeatherManager.Instance.CurrentSeason.season)
            {
                case SeasonType.Spring:
                    Object.Instantiate(_objManager.springBush, pos, Quaternion.identity);
                    break;
                case SeasonType.Summer:
                    Object.Instantiate(_objManager.summerBush, pos, Quaternion.identity);
                    break;
                case SeasonType.Autumn:
                    Object.Instantiate(_objManager.autumnBush, pos, Quaternion.identity);
                    break;
                case SeasonType.Winter:
                    Object.Instantiate(_objManager.winterBush, pos, Quaternion.identity);
                    break;
            }
        }

        public void SpawnLight()
        {
            if (WeatherManager.Instance.CurrentSeason.season != SeasonType.Summer) return;
            Vector3 pos = _randomPos.GetCenterPos();
            Object.Instantiate(_objManager.lights[Random.Range(0, _objManager.lights.Count)], pos,
                Quaternion.Euler(0, 0, Random.Range(0, 90)));
        }

        public IEnumerator DelaySpawn(float interval, Action spawnAction)
        {
            while (true)
            {
                yield return new WaitForSeconds(interval);
                spawnAction();
            }
        }

        public IEnumerator DelaySpawnHurricane()
        {
            while (true)
            {
                if (!_objManager.AllowSpawnHurricane)
                {
                    yield return null;
                    continue;
                }

                SpawnHurricane();
                yield return new WaitForSeconds(WeatherManager.Instance.WeatherData.hurricaneSpawnInterval);
            }
        }

        public IEnumerator DelaySpawnHail()
        {
            while (true)
            {
                if (!_objManager.AllowSpawnHail)
                {
                    yield return null;
                    continue;
                }

                SpawnHail();
                yield return new WaitForSeconds(WeatherManager.Instance.WeatherData.hailSpawnInterval);
            }
        }

        public IEnumerator DelaySpawnLightning()
        {
            while (true)
            {
                if (!_objManager.AllowSpawnLightning)
                {
                    yield return null;
                    continue;
                }

                SpawnLightning();
                yield return new WaitForSeconds(WeatherManager.Instance.WeatherData.lightningSpawnInterval);
            }
        }
    }
}
