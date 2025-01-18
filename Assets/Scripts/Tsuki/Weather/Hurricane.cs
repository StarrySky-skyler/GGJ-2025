// ********************************************************************************
// @author: Starry Sky
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/01/18 11:01
// @version: 1.0
// @description: 飓风物体挂载脚本
// ********************************************************************************

using System;
using UnityEngine;

namespace Tsuki.Weather
{
    public class Hurricane : MonoBehaviour
    {
        public float speed;
        
        private Rigidbody2D _rigidbody2D;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            _rigidbody2D.velocity = new Vector2(-speed, 0);
            Destroy(gameObject, WeatherManager.Instance.WeatherData.hurricaneDuration);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Player")) return;
            // TODO: 玩家操作反向
            
        }
    }
}
