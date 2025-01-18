// ********************************************************************************
// @author: Starry Sky
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/01/19 00:01
// @version: 1.0
// @description:
// ********************************************************************************

using System;
using UnityEngine;

namespace Tsuki.Objs
{
    public class Bird : CollideDeadObj
    {
        public float speed;     // 小鸟飞行速度
        
        private Rigidbody2D _rb;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        protected override void Start()
        {
            base.Start();
            _rb.velocity = Vector2.left * speed;
        }
    }
}
