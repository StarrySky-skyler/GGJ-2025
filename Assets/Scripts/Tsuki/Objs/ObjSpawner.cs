// ********************************************************************************
// @author: Starry Sky
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/01/18 23:01
// @version: 1.0
// @description:
// ********************************************************************************

using System.Collections;
using Tsuki.Managers;
using Tsuki.Weather;
using UnityEngine;

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
        private void SpawnHurricane()
        {
            Vector3 pos = _randomPos.GetRandomRightPos();
            Object.Instantiate(_objManager.hurricane, pos, Quaternion.identity);
            AudioManager.Instance.PlaySoundEffects(WeatherType.Hurricane);
        }

        private void SpawnHail()
        {
            Vector3 pos = _randomPos.GetRandomTopPos();
            GameObject h = _objManager.hail[Random.Range(0, _objManager.hail.Count)];
            Object.Instantiate(h, pos, Quaternion.identity);
        }

        private void SpawnLightning()
        {
            Vector3 pos = _randomPos.GetRandomPos();
            Object.Instantiate(_objManager.lightning, pos, Quaternion.identity);
            AudioManager.Instance.PlaySoundEffects(WeatherType.Lightning);
        }

        private void SpawnFengChe()
        {
            Vector3 pos = _randomPos.GetRandomPos();
            Object.Instantiate(_objManager.fengChe, pos, Quaternion.identity);
        }

        private void SpawnTengWan()
        {
            var pos = new Vector3(Screen.width, Screen.height, 0);
            pos = Camera.main.ScreenToWorldPoint(pos);
            pos.z = 0;
            Object.Instantiate(_objManager.tengWan, pos, Quaternion.identity);
        }

        private void SpawnBird()
        {
            Vector3 pos = _randomPos.GetRandomRightHalfTopPos();
            Object.Instantiate(_objManager.bird, pos, Quaternion.identity);
            AudioManager.Instance.PlaySoundEffects(WeatherType.Hurricane);
        }

        public IEnumerator DelaySpawnBird()
        {
            while (true)
            {
                yield return new WaitForSeconds(_objManager.birdSpawnInterval);
                SpawnBird();
            }
        }

        public IEnumerator DelaySpawnTengWan()
        {
            while (true)
            {
                yield return new WaitForSeconds(_objManager.tengWanSpawnInterval);
                SpawnTengWan();
            }
        }

        public IEnumerator DelaySpawnFengChe()
        {
            while (true)
            {
                yield return new WaitForSeconds(_objManager.fengCheSpawnInterval);
                SpawnFengChe();
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
