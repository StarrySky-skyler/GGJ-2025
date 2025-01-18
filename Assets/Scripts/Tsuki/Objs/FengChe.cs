// ********************************************************************************
// @author: Starry Sky
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/01/18 22:01
// @version: 1.0
// @description:
// ********************************************************************************

using System;
using UnityEngine;

namespace Tsuki.Objs
{
    public class FengChe : MonoBehaviour
    {
        public float lifeTime;
        
        private bool _triggered;

        private void Start()
        {
            Destroy(gameObject, lifeTime);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player") && !_triggered)
            {
                _triggered = true;
                // TODO: 触碰风车，玩家加速
            }
        }
    }
}
