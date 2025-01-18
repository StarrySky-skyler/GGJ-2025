// ********************************************************************************
// @author: Starry Sky
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/01/18 14:01
// @version: 1.0
// @description: 闪电物体挂载脚本
// ********************************************************************************

using System;
using UnityEngine;

namespace Tsuki.Weather
{
    public class Lightning : MonoBehaviour
    {
        private GameObject _damageArea;
        private GameObject _warningArea;

        private float _timer;
        private bool _triggered;
        private bool _collided;
        private bool _damaged;

        private void ActiveWarnArea()
        {
            _damageArea.SetActive(false);
            _warningArea.SetActive(true);
        }

        private void ActiveDamageArea()
        {
            _damageArea.SetActive(true);
            _warningArea.SetActive(false);
        }
        
        private void Awake()
        {
            _damageArea = transform.Find("DamageArea").gameObject;
            _warningArea = transform.Find("WarnArea").gameObject;
        }

        private void Update()
        {
            _timer += Time.deltaTime;
            if (_timer >= WeatherManager.Instance.lightningWarningTime && !_triggered)
            {
                ActiveDamageArea();
                _triggered = true;
                Destroy(gameObject, 0.3f);
            }

            if (_triggered && _collided && !_damaged)
            {
                // TODO: 闪电伤害
                _damaged = true;
            }
        }

        private void OnEnable()
        {
            ActiveWarnArea();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            _collided = other.CompareTag("Player");
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            _collided = !other.CompareTag("Player");
        }
    }
}
