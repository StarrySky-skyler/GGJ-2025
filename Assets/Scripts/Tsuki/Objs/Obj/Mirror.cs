﻿// ********************************************************************************
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
    public class Mirror : AutoDestoryObj
    {
        private bool _triggered;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Player")) return;
            if (!_triggered)
            {
                // TODO: 触发镜子，改变颜色
                _triggered = true;
            }
        }
    }
}
