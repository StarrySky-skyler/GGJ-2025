// ********************************************************************************
// @author: Starry Sky
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/01/19 11:01
// @version: 1.0
// @description:
// ********************************************************************************

using System;
using UnityEngine;

namespace Tsuki.Objs
{
    public class Fish : CollideDeadObj
    {
        public float speed;     // 鱼的速度
        
        private Rigidbody2D _rb;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        protected override void Start()
        {
            base.Start();
            SetStop();
        }

        public void DestorySelf()
        {
            Destroy(gameObject);
        }

        public void SetMove()
        {
            _rb.velocity = Vector2.left * speed;
        }

        public void SetStop()
        {
            _rb.velocity = Vector2.zero;
        }
    }
}
