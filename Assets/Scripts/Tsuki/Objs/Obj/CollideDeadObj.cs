// ********************************************************************************
// @author: Starry Sky
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/01/18 23:01
// @version: 1.0
// @description:
// ********************************************************************************

using System;
using UnityEngine;

namespace Tsuki.Objs
{
    public class CollideDeadObj : AutoDestoryObj
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Player")) return;
            // TODO: 玩家死亡
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (!other.gameObject.CompareTag("Player")) return;
            // TODO: 玩家死亡
        }
    }
}
