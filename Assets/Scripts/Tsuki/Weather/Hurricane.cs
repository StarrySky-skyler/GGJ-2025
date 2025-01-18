// ********************************************************************************
// @author: Starry Sky
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/01/18 11:01
// @version: 1.0
// @description:
// ********************************************************************************

using System;
using UnityEngine;

namespace Tsuki.Weather
{
    public class Hurricane : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Player")) return;
            // TODO: 玩家操作反向
            
        }
    }
}
